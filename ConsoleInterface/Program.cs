using ConsoleApp.Storage.Converters;
using ConsoleApp;
using ConsoleApp.DataBase.HotelDB;
using ConsoleApp.DataBase.HotelDB.Models;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using ConsoleApp.ConsoleObject.Table;
using ConsoleApp.ConsoleObject.Menu;
using ConsoleApp.ConsoleObject.Table.TableRows.CustomRows;
using ConsoleApp.ConsoleObject.Table.TableRows;
using System.Runtime.CompilerServices;
using ConsoleApp.DataBase;
namespace Program;
class Program
{
    static HotelStorage storage = HotelStorage.Instance;

    static Menu choiceSortField = new Menu("choiceSortField", "Выберите по какому полю сортировать", new List<MenuItem>()
    {
        new MenuItem("1","Название", ()=>{ var ordered = storage.ReadTables().OrderBy(h => h.Name); WriteSorted(ordered); } ),
        new MenuItem("2","Город",()=>{ var ordered = storage.ReadTables().OrderBy(h => h.City); WriteSorted(ordered);}),
        new MenuItem("3","Вместимость",()=>{ var ordered = storage.ReadTables().OrderBy(h => h.Capacity); WriteSorted(ordered); }),
        new MenuItem("4","Цена",()=>{ var ordered = storage.ReadTables().OrderBy(h => h.Price); WriteSorted(ordered); }),
    });

    static Menu startMenu = new Menu("startMenu", "Выберите вариант", new List<MenuItem>()
    {
        new MenuItem("1","Вывод", ()=>{ PrintAllHotel(); } ),
        new MenuItem("2","Выход",()=>{ Environment.Exit(0);}),
        new MenuItem("3","Добавление",()=>{ AddHotel(); }),
        new MenuItem("4","Удаление",()=>{ DeleteHotel(); }),
        new MenuItem("5","Сортировка",()=>{ Console.Clear(); choiceSortField.Print(); choiceSortField.Execute(); }),
        new MenuItem("6","Фильтрация",()=>{ Filter(); }),
        new MenuItem("7","Поднять цену",()=>{ ChangePrice(); })
    });

    public static void Main()
    {
        storage.FillStorageRandomHotels(10);
        ExecuteStartMenu();
    }

    static void ChangePrice()
    {
        double dPercent;
        string percent;
        do
        {
            percent = Ask("Введите процент на который надо поднять цену");
        } while (double.TryParse(percent, out dPercent) == false);
        var hotels = storage.ReadTables();
        foreach (var hotel in hotels)
        {
            hotel.Price *= dPercent;
        }
        storage.Clear();
        storage.WriteTables(hotels);
        Console.WriteLine($"Цена поднята на {dPercent} процентов");
        Console.ReadKey();
        ExecuteStartMenu(true);
    }

    static void Filter()
    { 
        int iCapacity;
        string capacity;
        do
        {
            capacity = Ask("Введите вместимость желаемую вместимость. Будут выведены отели с большей вместимостью");
        }
        while (int.TryParse(capacity, out iCapacity) == false);
        var filtered = storage.ReadTables().Where(h => h.Capacity > iCapacity);
        if (filtered.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine($"Нету отелей с вместимостью больше чем {iCapacity}");
            Console.ReadKey();
            ExecuteStartMenu(true);
            return;
        }
        var table = new Table("HotelTable", new List<ITableRow>(filtered.Select(entry => new HotelRow(entry))));
        table.Print();
        Console.ReadKey();
        Console.Clear();
        ExecuteStartMenu();
    }
    static void WriteSorted(IEnumerable<Hotel> ordered)
    {
        storage.Clear(); 
        storage.WriteTables(ordered);
        Console.WriteLine("Отсортировано!");
        Console.ReadKey(); 
        ExecuteStartMenu(true);
    }
    static void ExecuteStartMenu(bool needClear = false)
    {  
        if (needClear)
        {
            Console.Clear();
        }
        startMenu.Print();
        startMenu.Execute();
    }
    static void DeleteHotel()
    {
        var Id = Ask("Введите Id удаляемого отеля");
        storage.DeleteTable(new Hotel() { Id = Id});
        Console.WriteLine($"Запись с id {Id} удалена");
        Console.ReadKey();
        ExecuteStartMenu(true);
    }
    static void AddHotel()
    {
        Console.Clear();
        var name = Ask("Введите название отеля");
        Console.Clear();
        var city = Ask("Введите город отеля");
        Console.Clear();
        var capacity = Ask("Введите вместимость отеля");
        int iCapacity;
        while (int.TryParse(capacity, out iCapacity) == false)
        {
            capacity = Ask("Введите вместимость отеля. (Формат int)");
        }
        Console.Clear();
        var price = Ask("Введите стоимость отеля");
        double dPrice;
        while (double.TryParse(price, out dPrice) == false)
        {
            price = Ask("Введите вместимость отеля. (Формат double)");
        }
        Console.Clear();
        storage.WriteTable(new Hotel(name, city, iCapacity, dPrice));
        Console.WriteLine("Отель записан");
        Console.ReadKey();
        Console.Clear();
        ExecuteStartMenu();
    }
    static string Ask(string askText)
    {
        Console.Clear();
        Console.WriteLine(askText);
        var answer = Console.ReadLine();
        while (answer == null || answer == string.Empty)
        {
            Console.WriteLine("Вы ничего не ввели. Попробуйте снова");
            Console.WriteLine(askText);
            answer = Console.ReadLine();
        }
        return answer;
    }
    static void PrintAllHotel()
    {
        Console.Clear();
        var entries = storage.ReadTables();
        var table = new Table("HotelTable", new List<ITableRow>(entries.Select(entry => new HotelRow(entry))));
        table.Print();
        Console.ReadKey();
        Console.Clear();
        ExecuteStartMenu();
       
    }
}