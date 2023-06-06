using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._02._23_lecture
{
    public delegate void FinishDelegate(); //delegate является типом данных
                                          //По работе схож с указателем на функцию в C++
    public class ParSummator// класс для подсчета суммы с помощью распараллеливания
    {
        private long _maxValue;
        private object? locker = new();
        public long? Result
        {
            get;
            set;
        }
        public event FinishDelegate Finish; //создаем событие
                                            //по объявлению это похоже на поле
                                            //если стоит слово event, то мы можем добваить не одну, 
                                            //а несколько указателей на функции
        public ParSummator(long maxVal) //конструктор класса
        {
            _maxValue = maxVal;
        }
        public void Sum()//метод подсчета суммы с распараллеливанием 
        {
            Result = 0;
            var threadCount = 8;//кол-во потоков
            var counter = 0;//счетчик, нужный для проверки, что отработали все потоки
            for (int tn = 0; tn < threadCount; tn++)
            {
                var t = new Thread(tn =>
                {
                    var s = 0L;
                    for (int i = 1 + (int)tn; i < _maxValue; i += threadCount)
                    {
                        s += i;
                    }
                    lock (locker)
                    {
                        Result += s;
                        counter++; //увеличиваем счетчик после того как поток вернул значение
                        if (counter == threadCount ) Finish(); //вызываем Finish, если отработали все потоки
                    }
                    
                });
                t.Start(tn);
            }
          
        }
    }
}

