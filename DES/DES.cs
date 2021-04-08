using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class DES
    {
        DataTransfers transfers = new DataTransfers(); // функции по преобращование данных
        TableDES table = new TableDES(); // хранит все таблицы
        Random random = new Random();
        private const int sizeBlock = 64; // размер блока
        private const int sizeSymbol = 8; // размер одного символа 
        private const int shiftKey = 2; // сдвиг ключа 
        private const int countRounds = 16; // количество раундов
        List<string> blocks; // блоки текста

        private int countEmtyBit = 0; // количество добавленных элементов

        public List<string> encr(string _basisText)
        {
            blocks = new List<string>();
            string basisText = _basisText;
            string basisKey = generKey(); // генерация ключа из 64 бит
            string keyCD = permutations(basisKey, table.arrayG); // ключ после преобразования G (56 бит)
            string keyH = string.Empty; // ключ после преобразования H (48 бит)       

            basisText = stringAddLength(basisText); // добавление недостоющий символов до блока
            basisText = transfers.stringToBinary(basisText, sizeSymbol); // перевод строки в двоичный формат
            blocks = stringDivisionIntoBlocks(basisText); // деление строки на блоки

            // Начальная перестановка IP
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i] = permutations(blocks[i], table.arrayIP);
            }
            // 16 раундов фукнции фейстеля
            for (int i = 0; i < countRounds; i++)
            {
                keyCD = keyNextRound(keyCD); // циклический сдвиг для дальнейшего образования ключей
                keyH = permutations(keyCD, table.arrayH); // образование ключа матрицей H
                for (int j = 0; j < blocks.Count; j++)
                {
                    blocks[j] = encrOneRound(blocks[j], keyH);
                }
            }
            // Конечная перестановка IP-1
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i] = permutations(blocks[i], table.arrayIP_1);
            }

            string result = string.Empty;
            for (int i = 0; i < blocks.Count; i++)
            {
                result += blocks[i];
            }

            // сборка результатов для отправки
            List<string> answer = new List<string>();
            answer.Add(transfers.binaryToString(result, sizeSymbol));
            answer.Add(transfers.binaryToString(keyCD, sizeSymbol));
            answer.Add(transfers.binaryToString(basisKey, sizeSymbol));
            return answer;
        }

        public string dec(string _basisText, string _key)
        {
            blocks = new List<string>();
            string basisText = _basisText;
            string keyCD = transfers.stringToBinary(_key, sizeSymbol); // перевод ключа в бинарник
            string keyH = permutations(keyCD, table.arrayH); // получения 16 ключа расшифровки

            basisText = transfers.stringToBinary(basisText, sizeSymbol); // перевод текста в бинарник
            blocks = stringDivisionIntoBlocks(basisText); // деление текста на блоки

            // Начальная перестановка IP
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i] = permutations(blocks[i], table.arrayIP);
            }
            // 16 раундов фукнции фейстеля
            for (int i = 0; i < countRounds; i++)
            {
                for (int j = 0; j < blocks.Count; j++)
                {
                    blocks[j] = decOneRound(blocks[j], keyH);
                }
                keyCD = keyPrevRound(keyCD);
                keyH = permutations(keyCD, table.arrayH);
            }

            // Конечная перестановка IP-1
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i] = permutations(blocks[i], table.arrayIP_1);
            }

            string result = string.Empty;
            for (int i = 0; i < blocks.Count; i++)
            {
                result += blocks[i];
            }
            result = transfers.binaryToString(result, sizeSymbol);
            return stringDeleteSuperfluous(result);
        }

        // шифрование DES один раунд
        private string encrOneRound(string str, string key)
        {
            string L = str.Substring(0, str.Length / 2);
            string R = str.Substring(str.Length / 2, str.Length / 2);

            string newL = R;
            string newR = xor(L, f(R, key));

            return newL + newR;
        }

        // расшифровка DES один раунд
        private string decOneRound(string str, string key)
        {
            string L = str.Substring(0, str.Length / 2);
            string R = str.Substring(str.Length / 2, str.Length / 2);

            string newR = L;
            string newL = xor(R, f(L, key));

            return newL + newR;
        }

        // XOR двух строк с двоичными данными
        private string xor(string str1, string str2)
        {
            string result = string.Empty;

            for (int i = 0; i < str1.Length; i++)
            {
                bool a = Convert.ToBoolean(Convert.ToInt32(str1[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(str2[i].ToString()));
                if (a ^ b)
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        // шифрующая функция f
        private string f(string str, string key)
        {
            string strE = permutations(str, table.arrayE); // стало 48 бит
            string strXor = xor(strE, key);
            List<string> blocksB = stringDivisionIntoBlocks(strXor, 6); // делим на 8 блоков размеров 6 бит
            string strS = string.Empty;
            // по концу цикла становится 32 бит
            for (int i = 0; i < blocksB.Count; i++)
            {
                blocksB[i] = divisionS(blocksB[i], i);
                strS += blocksB[i];
            }
            string result = permutations(strS, table.arrayP);  // преобразование P
            return result;
        }

        // функция S(1)...S(8)
        private string divisionS(string blocks, int nomer)
        {
            string newBlocks = string.Empty;
            int column = transfers.fromBinary((blocks[0].ToString() + blocks[5].ToString()));
            int row = transfers.fromBinary((blocks[1].ToString() + blocks[2].ToString() + blocks[3].ToString() + blocks[4].ToString()));
            newBlocks = Convert.ToString(table.arrayAllS[nomer, column, row], 2).PadLeft(4, '0');
            return newBlocks; // 4 бита
        }

        // функция расширения E, перестановок P, IP, IP-1, G, H
        private string permutations(string blocks, int[] arrayIndexs)
        {
            string newBlocks = string.Empty;
            for (int i = 0; i < arrayIndexs.Length; i++)
            {
                newBlocks += blocks[arrayIndexs[i] - 1];
            }
            return newBlocks;
        }


        // ключ для следующего раунда(циклический сдвиг <<)
        private string keyNextRound(string key)
        {
            string C = key.Substring(0, key.Length / 2);
            string D = key.Substring(key.Length / 2, key.Length / 2);

            for (int i = 0; i < shiftKey; i++)
            {
                C = C + C[0];
                C = C.Remove(0, 1);

                D = D + D[0];
                D = D.Remove(0, 1);
            }
            return C + D;
        }

        // ключ предыдущего раунда(циклический сдвиг >>)
        private string keyPrevRound(string key)
        {
            string C = key.Substring(0, key.Length / 2);
            string D = key.Substring(key.Length / 2, key.Length / 2);

            for (int i = 0; i < shiftKey; i++)
            {
                C = C[C.Length - 1] + C;
                C = C.Remove(C.Length - 1);

                D = D[D.Length - 1] + D;
                D = D.Remove(D.Length - 1);
            }
            return C + D;
        }

        // генерация ключа 64 бит
        private string generKey()
        {
            string key = string.Empty;
            for (int i = 0; i < 64; i++)
            {
                if (random.Next(100) < 50)
                {
                    key += "1";
                }
                else
                {
                    key += "0";
                }
            }
            return key;
        }

        // добавить символы в строку до размера блока
        private string stringAddLength(string str)
        {
            while (((str.Length * sizeSymbol) % sizeBlock) != 0)
            {
                countEmtyBit++;
                str += "0";
            }

            return str;
        }

        // удаление лишних символов
        private string stringDeleteSuperfluous(string str)
        {
            return str.Remove(str.Length - countEmtyBit, countEmtyBit);
        }

        // деление строки на блоки
        private List<string> stringDivisionIntoBlocks(string str, int value = sizeBlock)
        {
            List<string> blocks = new List<string>();

            for (int i = 0; i < str.Length / value; i++)
            {
                blocks.Add(str.Substring(i * value, value));
            }
            return blocks;
        }

    }
}
