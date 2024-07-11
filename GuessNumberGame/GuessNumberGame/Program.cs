// See https://aka.ms/new-console-template for more information

var number = new Random().Next(0,10);
Console.WriteLine(number.ToString());

Console.WriteLine("Try guess number");

while (true)
{
    var userNumber = Convert.ToInt32(Console.ReadLine());
    if (userNumber != number)
    {
        Console.WriteLine($"You're wrong, it's not {userNumber} \nplease try again");
        continue;
    }

    Console.WriteLine($"You're right, it's real {number}");
    break;
}
