using ConsoleTextGame.Converters;
using ConsoleTextGame.GameObject.Menu;
using ConsoleTextGame.GameObject.Table;

//var gm = new Menu("m1", "Выберите вариант", new List<MenuItem>()
//{
//    new MenuItem("1","Посчитать 2+2", ()=>{ Console.Clear(); Console.WriteLine("4"); } ),
//    new MenuItem("2","Вывести Hello, World!",()=>{ Console.Clear(); Console.WriteLine("Hello, World"); })
//});

//gm.OpenMenu();
//Console.ReadKey();

var table = new List<ITableRow<string>>();
var r1 = new TableRow<string>(new List<string>() { "1", "12", "13", "14" }, StandartTableCharacterSet.Instance);
var r2 = new TableRow<string>(new List<string>() { "2", "22", "23", "34" }, StandartTableCharacterSet.Instance);
var r3 = new TableRow<string>(new List<string>() { "3", "32", "33", "34" }, StandartTableCharacterSet.Instance);
table.Add(r1);
table.Add(r2);
table.Add(r3);
Console.WriteLine("Pafos Matrix");
var gTable = new Table<string>("123", table);
gTable.PrintTable();

