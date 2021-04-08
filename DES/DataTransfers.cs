using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class DataTransfers
    {
        // перевод строки в двоичный формат
        public string stringToBinary(string str, int sizeSymbol)
        {
            string result = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                string binCode = Convert.ToString(str[i], 2);
                while (binCode.Length < sizeSymbol)
                {
                    binCode = "0" + binCode;
                }
                result += binCode;
            }
            return result;
        }

        // перевод из двоичных данных в строку
        public string binaryToString(string str, int sizeSymbol)
        {
            string output = string.Empty;

            while (str.Length > 0)
            {
                string binCode = str.Substring(0, sizeSymbol);

                int a = 0;
                int degree = binCode.Length - 1;

                foreach (char c in binCode)
                {
                    a += Convert.ToInt32(c.ToString()) * (int)Math.Pow(2, degree--);
                }

                output += ((char)a).ToString();
                str = str.Remove(0, sizeSymbol);
            }

            return output;
        }

        // перевод двочиного числа в 10-чное число
        public int fromBinary(string str)
        {
            int big = 0;
            foreach (var c in str)
            {
                big <<= 1;
                big += c - '0';
            }

            return big;
        }
    }
}
