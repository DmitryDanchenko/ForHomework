
using homeWork3;
using System.Diagnostics;

string s = null;
var c = F.Get;
var stopWatch = new Stopwatch();
//собственный механизм сериализации
stopWatch.Start();
for (int i = 0; i < 1000000; i++)
{
    s = c.ToCsv(c);
}
stopWatch.Stop();
Console.WriteLine("Собственный механизм сериализации: " + stopWatch.Elapsed);
stopWatch.Reset();
Console.WriteLine(s);
Console.WriteLine();
c.WriteInFile(c.ToCsv(c));

//замер: время вывода в консоль
stopWatch.Start();
Console.WriteLine(c.ToCsv(c));
stopWatch.Stop();
Console.WriteLine("Время вывода информации в консоль: " + stopWatch.Elapsed);
stopWatch.Reset();
Console.WriteLine();

//сериализация с помощью средств Newtonsoft
stopWatch.Start();
for (int i = 0; i < 1000000; i++)
{
    Newtonsoft.Json.JsonConvert.SerializeObject(c);
}
stopWatch.Stop();
Console.WriteLine("Механизм сериализации Newtonsoft: " + stopWatch.Elapsed);
stopWatch.Reset();
Console.WriteLine();

//десериализация с помощью средств Newtonsoft
var des = Newtonsoft.Json.JsonConvert.SerializeObject(c);
stopWatch.Start();
for (int i = 0; i < 1000000; i++)
{
    Newtonsoft.Json.JsonConvert.DeserializeObject(des);
}
stopWatch.Stop();
Console.WriteLine("Механизм десериализации Newtonsoft: " + stopWatch.Elapsed);
stopWatch.Reset();
Console.WriteLine(des);
Console.WriteLine();

//собственная реализация десериализации
stopWatch.Start();
for (int i = 0; i < 1000; i++)
{
    var a = c.ReadFile();
}
stopWatch.Stop();
Console.WriteLine("Механизм десериализации из файла: " + stopWatch.Elapsed);
stopWatch.Reset();

Console.ReadLine();
