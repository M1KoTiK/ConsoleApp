using ConsoleTextInterface.Storage.Converters;
using ConsoleTextInterface;
using ConsoleTextInterface.DataBase.HotelDB;
using ConsoleTextInterface.DataBase.HotelDB.Models;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

//var gm = new Menu("m1", "Выберите вариант", new List<MenuItem>()
//{
//    new MenuItem("1","Посчитать 2+2", ()=>{ Console.Clear(); Console.WriteLine("4"); } ),
//    new MenuItem("2","Вывести Hello, World!",()=>{ Console.Clear(); Console.WriteLine("Hello, World"); })
//});

//gm.OpenMenu();
//Console.ReadKey();

//var table = new List<ITableRow<string>>();
//var r1 = new TableRow<string>(new List<string>() { "Что-то", "Красота", "Изящество", "Жопка" }, StandartTableCharacterSet.Instance);
//var r2 = new TableRow<string>(new List<string>() { "10/10", "10/10", "8/10", "3/10" }, StandartTableCharacterSet.Instance);
//var r3 = new TableRow<string>(new List<string>() { "10/10", "2/10", "5/10", "3/10" }, StandartTableCharacterSet.Instance);
//table.Add(r1);
//table.Add(r2);
//table.Add(r3);
//Console.WriteLine("Pafos Matrix");
//var gTable = new Table<string>("123", table);
//gTable.PrintTable();

var storage = HotelStorageContext.Instance;
storage.FillStorageRandomHotels(10);
var fileInfo = new FileInfo(storage.StorageFilePath);
fileInfo.CopyTo("C:\\Users\\User\\Desktop\\HotelStorage.txt", true);
var tables = storage.ReadTables();
Console.ReadKey();
//[DllImport("user32.dll")]
//static extern bool SetCursorPos(int X, int Y);
//var rnd = new Random();

//for (int i = 0; i < 100; i++)
//{
//    SetCursorPos(rnd.Next(500), rnd.Next(500));
//    Thread.Sleep(100);
//}