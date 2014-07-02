using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Shiphrator
{
    public delegate void FileEncryptedDelegate(object sender);
    public delegate void FilesEncryptedFinishedDelegate(object sender);

    public class Engine
    {
        Cryptograph cryptograph;
        ulong keyResult; 

        public string[] FilesFullNames {get;private set;}
        public string[] FilesSafeNames { get; private set; }
        public string OutputDirectory { get; private set; }
        public bool DeleteFilesAfterConvert {get;set;}

        public event FileEncryptedDelegate FileEncrypted;
        public event FilesEncryptedFinishedDelegate FilesEncryptedFinished;

        public Engine()
        {
            cryptograph = new Cryptograph();
        }
        public Engine(string[] filesFullNames, string[] filesSafeNames, string outputDirectory, string key)
        {
            KeyKreator keyKreator = new KeyKreator(key);
            keyResult = keyKreator.ConvertKey();
            this.OutputDirectory = outputDirectory;
            this.FilesSafeNames = filesSafeNames;
            this.FilesFullNames = filesFullNames;
            cryptograph = new Cryptograph();
        }

        public void ChangeOptions(string[] filesFullNames,string[] filesSafeNames,string outputDirectory,string key)
        {
            KeyKreator keyKreator = new KeyKreator(key);
            keyResult = keyKreator.ConvertKey();
            this.OutputDirectory = outputDirectory;
            this.FilesSafeNames = filesSafeNames;
            this.FilesFullNames = filesFullNames;
        }

        public void Encrypt()
        {
            for (int y = 0; y < FilesFullNames.Length; y++)
            {
                if (!File.Exists(FilesFullNames[y]))
                {
                    MessageBox.Show("Один из файлов не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FilesEncryptedFinished(this);
                    return;
                }
            }
            for (int y=0; y< FilesFullNames.Length;y++)
            {
                using (FileStream fs = new FileStream(FilesFullNames[y], FileMode.Open))
                {
                    BinaryReader br = new BinaryReader(fs);
                    ulong NumLongsInFile = (ulong)(fs.Length / 8);
                    int module = (int)fs.Length % 8;
                    ulong[] fileDataArr = new ulong[NumLongsInFile];
                    byte[] moduleData = new byte[module];
                    for (ulong x = 0; x < NumLongsInFile; x++)
                    {
                        fileDataArr[x] = br.ReadUInt64();
                    }
                    for (int x = 0; x < module; x++)
                    {
                        moduleData[x] = br.ReadByte();
                    }
                    FileData filedata = cryptograph.Encrypt(new FileData(fileDataArr, moduleData), keyResult);
                    string fileNewFullName = OutputDirectory + @"\"+FilesSafeNames[y].Remove(FilesSafeNames[y].LastIndexOf("."))+".shphr";
                    using (FileStream fswriter = new FileStream(fileNewFullName, FileMode.Create))
                    {
                        BinaryWriter bw = new BinaryWriter(fswriter);
                        char[] fileExtension = FilesSafeNames[y].Substring(
                            FilesSafeNames[y].LastIndexOf("."),
                            FilesSafeNames[y].Length - FilesSafeNames[y].LastIndexOf(".")).ToCharArray();
                        int extensionLength = fileExtension.Length;
                        bw.Write(extensionLength);
                        bw.Write(fileExtension);
                        for (ulong x = 0; x < NumLongsInFile; x++)
                        {
                            bw.Write(filedata.data[x]);
                        }
                        for (int x = 0; x < module; x++)
                        {
                            bw.Write(filedata.moduleData[x]);
                        }
                    }
                    FileEncrypted(this);
                }
                if (DeleteFilesAfterConvert)
                {
                    File.Delete(FilesFullNames[y]);
                }
            }
            FilesEncryptedFinished(this);
        }

        public void Decrypt()
        {
            for (int y = 0; y < FilesFullNames.Length; y++)
            {
                if (!File.Exists(FilesFullNames[y]))
                {
                    MessageBox.Show("Один из файлов не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FilesEncryptedFinished(this);
                    return;
                }
                if (FilesFullNames[y].Substring(FilesFullNames[y].LastIndexOf("."))!=".shphr")
            	{
                    MessageBox.Show("Один из файлов не является зашифрованным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FilesEncryptedFinished(this);
                    return;
                }
            }
            for (int y = 0; y < FilesFullNames.Length; y++)
            {
                
                using (FileStream fs = new FileStream(FilesFullNames[y], FileMode.Open))
                {
                    BinaryReader br = new BinaryReader(fs);
                    int extensionLength = br.ReadInt32();
                    char[] extensionChars = br.ReadChars(extensionLength);
                    String fileExtension = new String(extensionChars);
                    ulong NumLongsInFile = (ulong)(fs.Length - 4 - extensionChars.Length) / 8;
                    ulong[] fileDataArr = new ulong[NumLongsInFile];
                    int module = (int)(fs.Length - 4 - extensionChars.Length) % 8;
                    byte[] moduleData = new byte[module];

                    for (ulong x = 0; x < NumLongsInFile; x++)
                    {
                        fileDataArr[x] = br.ReadUInt64();
                    }
                    for (int x = 0; x < module; x++)
                    {
                        moduleData[x] = br.ReadByte();
                    }
                    FileData filedata = cryptograph.Decrypt(new FileData(fileDataArr, moduleData), keyResult);
                    string fileNewFullName = OutputDirectory + @"\" + FilesSafeNames[y].Substring(0,FilesSafeNames[y].LastIndexOf(".")) + fileExtension;
                    using (FileStream fswriter = new FileStream(fileNewFullName, FileMode.Create))
                    {
                        BinaryWriter bw = new BinaryWriter(fswriter);
                        for (ulong x = 0; x < NumLongsInFile; x++)
                        {
                            bw.Write(filedata.data[x]);
                        }
                        for (int x = 0; x < module; x++)
                        {
                            bw.Write(filedata.moduleData[x]);
                        }
                    }
                }
                FileEncrypted(this);
                if (DeleteFilesAfterConvert)
                {
                    File.Delete(FilesFullNames[y]);
                }
            }
            FilesEncryptedFinished(this);
        }

        private void OnFileEncrypted()
        {
            if (FileEncrypted!=null)
            {
                FileEncrypted(this);
            }
        }
        private void OnFilesEncryptedFinished()
        {
            if (FilesEncryptedFinished != null)
            {
                FilesEncryptedFinished(this);
            }
        }
    }
}
