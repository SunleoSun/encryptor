using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shiphrator
{
    class KeyKreator
    {

        byte[] byteString;
        int numLongsInString;
        int moduleBytes;

        public KeyKreator(string keyString)
        {
            this.byteString = Encoding.GetEncoding(1251).GetBytes(keyString);
            numLongsInString = this.byteString.Length / 8;
            moduleBytes = this.byteString.Length % 8;
        }

        public ulong ConvertKey()
        {
            ulong result = 0;
            ulong tempLong = 0;
            int counter = 1;
            tempLong = byteString[0];
            for (int x = 1; x < byteString.Length; x++)
            {
                if (counter<9)
                {
                    tempLong += WriteToLong(8 * counter, byteString[x]);
                    counter++;
                }
                else
                {
                    counter = 1;
                    result ^= tempLong;
                    tempLong = byteString[x];
                }
            }
            if (moduleBytes!=0)
            {
                result ^= tempLong;
            }
            return result;
        }

        private ulong WriteToLong(int bitShift, byte byteData)
        {
            ulong result = 0;
            for (int x=0; x< 8;x++)
            {
                if ((byteData & (byte)Math.Pow(2, x)) != 0)
            	{
                    result += (ulong)Math.Pow(2, bitShift + x);
            	}
            }
            return result;
        }
    }
}
