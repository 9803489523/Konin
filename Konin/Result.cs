using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konin
{
    /*
     * класс для вывода результатов
     * position - позиция подстроки в строке
     * substring - найденная в результате нечеткого поиска подстрока
     */ 
    internal class Result
    {
        private int position;

        private string substring;

        public Result(int position, string substring)
        {
            this.position = position;
            this.substring = substring;
        }

        public int Position { 
            get { 
                return position; 
            }
            set { 
                position = value; } 
        }
        public string Substring { 
            get { 
                return substring; 
            } 
            set { 
                substring = value; 
            } 
        }
    }
}
