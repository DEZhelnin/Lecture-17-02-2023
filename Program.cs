using _17._02._23_lecture;
using System.Diagnostics;


var ps = new ParSummator(1000000000);
var ss = new SeqSummator(1000000000);
var sw = Stopwatch.StartNew();//из пакета system.diagnostics
void ShowResult()
{
    sw.Stop();

    Console.WriteLine("{0} за {1} мс", ps.Result, sw.ElapsedMilliseconds);

}
ss.Sum();
sw.Stop();
Console.WriteLine("{0} за {1} мс",ss.Result,sw.ElapsedMilliseconds);

ps.Finish += ShowResult; //добавили ссылку на функцию ShowResult (подписываемся на событие) 
sw.Restart();                            
ps.Sum();
//Console.WriteLine("{0} за {1} мс", ps.Result, sw.ElapsedMilliseconds);
