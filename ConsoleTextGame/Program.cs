using ConsoleTextGame.Converters;
using ConsoleTextGame.GameObject.Menu;
using ConsoleTextGame.GameObject.Table;

var gm = new Menu("m1", "Выберите вариант", new List<MenuItem>()
{
    new MenuItem("1","Посчитать 2+2", ()=>{ Console.Clear(); Console.WriteLine("4"); } ),
    new MenuItem("2","Вывести Hello, World!",()=>{ Console.Clear(); Console.WriteLine("Hello, World"); })
});

gm.OpenMenu();
Console.ReadKey();

var table = new List<ITableRow<string>>();
table.Add(new TableRow<string>(new List<string>() { "!23", "!2332323234234", "!23", "!23" }, StandartTableCharacterSet.Instance));
var gTable = new Table<string>("123", table);
gTable.PrintTable();

