using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Shiphrator
{
    class Cryptograph
    {
        public FileData Encrypt(FileData file, ulong resultKey)
        {
            FileData resFile;
            resFile = EncryptDecryptSubstitution(file, resultKey);
            resFile = EncryptPermutation(resFile, resultKey);
            return resFile;
        }

        public FileData Decrypt(FileData file, ulong resultKey)
        {
            FileData resFile;
            resFile = DecryptPermutation(file, resultKey);
            resFile = EncryptDecryptSubstitution(resFile, resultKey);
            return resFile;
        }

        private FileData EncryptDecryptSubstitution(FileData file, ulong resultKey)
        {
            ulong[] resData = new ulong[file.data.Length];
            byte[] resModuleData = new byte[file.moduleData.Length];
            for (int x=0; x< file.data.Length;x++)
            {
                resData[x] = file.data[x] ^ resultKey;
                if ((file.data[x] ^ resultKey) == resultKey)
                {
                    resData[x] ^= resultKey;
                }
            }
            byte byteKey = (byte)resultKey;
            for (int x=0; x< file.moduleData.Length;x++)
            {
                resModuleData[x] = (byte)(file.moduleData[x] ^ byteKey);
            }
            return new FileData(resData, resModuleData);
        }

        private FileData EncryptPermutation(FileData file, ulong resultKey)
        {
            if (file.data.Length < 10)
            {
                return file;
            }
            ulong[] resData = new ulong[file.data.Length];
            int columnLength = 0;
            int lineLength = 0;
            int counter = 0;
            FindLineColumnLengths(resData,resultKey, ref columnLength, ref lineLength);
            ulong[,] dataTable = new ulong[columnLength, lineLength];
            int[] LeftIndexZerro;
            if (file.data.Length % columnLength!=0)
            {
                LeftIndexZerro = new int[columnLength - (file.data.Length % columnLength)];
            }
            else
                LeftIndexZerro = new int[0];
            for (int x = 0; x < LeftIndexZerro.Length; x++)
            {
                LeftIndexZerro[x] = columnLength - x - 1;
            }
            for (int x=0; x<= lineLength-1;x++)
            {
                for (int y = 0; y <= columnLength-1; y++)
            	{
                    if (counter<file.data.Length)
                    {
            		    dataTable[y,x] = file.data[counter];
                        counter++;
                    }
            	}
            }
            counter = 0;
            int couLeftIndex = LeftIndexZerro.Length - 1;

            for (int x=0; x<= columnLength-1;x++)
            {
                for (int y = 0; y <= lineLength - 1; y++)
            	{
                    if (couLeftIndex > 0)
                        if (LeftIndexZerro[couLeftIndex] == x && y == lineLength - 1)
                        {
                            couLeftIndex--;
                            continue;
                        }
                    if (counter<file.data.Length)
                    {
            		    resData[counter] = dataTable[x,y];
                        counter++;
                    }
            	}
            }
            return new FileData(resData, file.moduleData);
        }

        private FileData DecryptPermutation(FileData file, ulong resultKey)
        {
            if (file.data.Length <10)
            {
                return file;
            }
            ulong[] resData = new ulong[file.data.Length];
            int columnLength = 0;
            int lineLength = 0;
            int counter = 0;
            FindLineColumnLengths(resData,resultKey, ref columnLength, ref lineLength);

            ulong[,] dataTable = new ulong[columnLength, lineLength];
            int[] LeftIndexZerro;
            if (file.data.Length % columnLength!=0)
            {
                LeftIndexZerro = new int[columnLength - (file.data.Length % columnLength)];
            }
            else
                LeftIndexZerro = new int[0];
            for (int x = 0; x < LeftIndexZerro.Length; x++)
            {
                LeftIndexZerro[x] = columnLength - x - 1;
            }
            int couLeftIndex = LeftIndexZerro.Length - 1;

            for (int x = 0; x <= columnLength - 1; x++)
            {
                for (int y = 0; y <= lineLength-1; y++)
                {
                    if (couLeftIndex > 0)
                        if (LeftIndexZerro[couLeftIndex] == x && y == lineLength - 1)
                        {
                            couLeftIndex--;
                            dataTable[x, y] = 0;
                            continue;
                        }
                    if (counter < file.data.Length)
                    {
                        dataTable[x, y] = file.data[counter];
                        counter++;
                    }
                }
            }
            counter = 0;
            couLeftIndex = LeftIndexZerro.Length - 1;

            for (int x = 0; x <= lineLength-1; x++)
            {
                for (int y = 0; y <= columnLength-1; y++)
                {
                    if (couLeftIndex > 0)
                        if (LeftIndexZerro[couLeftIndex] == x && y == lineLength - 1)
                        {
                            break;
                        }
                    if (counter < resData.Length)
                    {
                        resData[counter] = dataTable[y, x];
                        counter++;
                    }
                }
            }
            return new FileData(resData, file.moduleData);
        }

        private static void FindLineColumnLengths(ulong[] Data,ulong keyResult, ref int columnLength, ref int lineLength)
        {
            if (keyResult % 10 != 0 && keyResult % 10 != 1)
            {
                columnLength = (int)(keyResult % 10);
            }
            else
                columnLength = 2;
            if (Data.Length % columnLength == 0)
            {
                lineLength = Data.Length / columnLength;
            }
            else
                if (Data.Length / columnLength != 0)
                {
                    lineLength = (Data.Length / columnLength) + 1;
                }
                else
                    lineLength = 2;
        }

 
    }
   }

