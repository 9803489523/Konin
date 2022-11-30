using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konin
{
    /*
     * класс, реализующий функции нечеткого поиска
     */  
    internal class Haming
    {
        /*
         * получение позиции строки с помощью расстояния Хэминга
         * input - исходная строка
         * pattern - подстрока
         * k - расстояние редактирования (в данной функции процент отличий)
         */ 
        public int SearchPosition(string input, string pattern, double k)
        {
            if (k < 0 || k > 1)
                throw new ArgumentException("Неверное расстояние редактирования", "k");

            int inputLength = input.Length;
            int patternLength = pattern.Length;

            for (int i = 0; i <= inputLength - patternLength; i++)
            {
                /*
                 * расстояние Хэминга
                 */
                int distance = 0;
                for (int j = 0; j < patternLength; j++)
                {
                    if (input[i + j] != pattern[j])
                    {
                        distance++;
                    }
                }
                if (distance <= k * patternLength) return i;
            }
            return -1;
        }

        /*
         * получение результате в виде (позиция, подстрока)
         * input - исходная строка
         * pattern - подстрока
         * k - расстояние редактирования (в данной функции процент отличий)
         */
        public Result FuzzySearch(string input, string pattern, double k)
        {
            int pos = SearchPosition(input, pattern, k);
            if (pos == -1)
                return new Result(-1,"error");
            else
            {
                string res=input.Substring(pos,pattern.Length);
                return new Result(pos,res);
            }           
        }

        /*
         * вывод в консоль результатов
         */
        public void print()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine("Введите подстроку: ");
            string pattern = Console.ReadLine();
            Console.WriteLine("Введите расстояние редактирования: ");
            int symbol = int.Parse(Console.ReadLine());
            if (symbol > pattern.Length)
            {
                Console.WriteLine("Ошибка, расстояние редактирования больше расстояния подстроки!");
                print();
            }
            else
            {
                Result rez = FuzzySearch(str, pattern, (double)((double)symbol/pattern.Length));
                if (rez.Position != -1)
                    Console.WriteLine("{0} {1}", rez.Position, rez.Substring);
                else
                    Console.WriteLine("Нет такой подстроки с заданным расстоянием редактирования");
            }
        }
    }
}
