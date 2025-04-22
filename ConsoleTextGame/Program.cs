using ConsoleTextGame.Converters;
using ConsoleTextGame.GameObject.Menu;

var gm = new Menu("m1", "Выберите вариант", new List<MenuItem>()
{
    new MenuItem("1","Посчитать 2+2", ()=>{ Console.Clear(); Console.WriteLine("4"); } ),
    new MenuItem("2","Вывести Hello, World!",()=>{ Console.Clear(); Console.WriteLine("Hello, World"); })
});

gm.OpenMenu();
Console.ReadKey();

