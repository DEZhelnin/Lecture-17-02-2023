using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._02._23_lecture
{
   public class SeqSummator//класс для подсчета суммы в одном потоке
    {
        private long _maxValue;
        public long? Result
        {
            get;
            set;
        }
        public SeqSummator(long maxVal)//конструктор класса
        {
            _maxValue = maxVal;
        }
        public void Sum()//метод подсчета суммы
        {
            long s = 0;
            for (long i = 0; i < _maxValue; i++)
            {
                s+=i;
            }
            Result = s;
        }
    }
}
