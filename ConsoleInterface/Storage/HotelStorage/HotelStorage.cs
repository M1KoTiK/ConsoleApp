using ConsoleApp.DataBase.HotelDB.Models;
using ConsoleApp.Storage.Converters.Hotel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataBase.HotelDB
{
    public class HotelStorage : IStorage<Hotel>
    {
        public readonly List<string> names = new List<string>
        {
            "Гранд Отель Европа",
            "Метрополь",
            "Балчуг Кемпински",
            "Ритц Карлтон Москва",
            "Four Seasons Москва",
            "Арарат Парк Хаятт",
            "Лотте Отель",
            "Космос",
            "Измайлово",
            "Хилтон Москва Ленинградская",
            "Шератон Палас",
            "Азимут Отель",
            "Коринтия Невский Палас",
            "Октябрьская",
            "Хаятт Ридженси Екатеринбург",
            "Марриотт Новый Арбат"
        };

        public readonly List<string> сities = new List<string>
        {
            "Москва",
            "Санкт-Петербург",
            "Сочи",
            "Казань",
            "Калининград",
            "Краснодар",
            "Владивосток",
            "Екатеринбург",
            "Нижний Новгород",
            "Грозный",
            "Ростов-на-Дону",
            "Самара",
            "Уфа",
            "Новосибирск",
            "Ялта"
        };

        public static HotelStorage Instance = new HotelStorage();
        public string StorageFilePath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage\\HotelStorage\\HotelStorage.txt");
        public Hotel GenerateHotel()
        {
            var random = new Random();
            var price = random.NextDouble() * 2000;
            var capacity = random.Next(100, 200);
            var name = names[random.Next(names.Count - 1)];
            var city = сities[random.Next(сities.Count - 1)];
            var hotel = new Hotel()
            {
                Name = name,
                City = city,
                Capacity = capacity,
                Price = price
            };
            return hotel;
            
        }
        public void FillStorageRandomHotels(int count)
        {
            Clear();
            var random = new Random();

            for (var i = 0; i < count; i++)
            {
                var price = random.NextDouble() * 2000;
                var capacity = random.Next(100, 200);
                var name = names[random.Next(names.Count - 1)];
                var city = сities[random.Next(сities.Count - 1)];
                var hotel = new Hotel()
                {
                    Name = name,
                    City = city,
                    Capacity = capacity,
                    Price = price
                };
                WriteTable(hotel);
            }
        }

        public void DeleteTable(Hotel table)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "TempHotelStorage.txt"); ;
            using var reader = new StreamReader(StorageFilePath);
            using var writer = new StreamWriter(tempPath);
            while (reader.ReadLine() is { } line)
            {
                var hotelInLine = HotelConverter.Instance.Deserialize(line);
                if (!(hotelInLine.Id == table.Id))
                {
                    writer.WriteLine(line);
                }
            }
        }

        public IEnumerable<Hotel> ReadTables(int count = -1)
        {
            var outputList = new List<Hotel>();
            using var reader = new StreamReader(StorageFilePath);
            if (count < 0)
            {
                count = int.MaxValue;
            }
            var currentCount = 0;
            while (reader.ReadLine() is { } line)
            {
                if (currentCount > count)
                {
                    return outputList;
                }
                outputList.Add(HotelConverter.Instance.Deserialize(line));
                currentCount++;
            }
            return outputList;
        }
        public void WriteTables(IEnumerable <Hotel> hotels) 
        { 
            foreach(var hotel in hotels)
            {
                WriteTable(hotel);
            }
        }
        public void WriteTable(Hotel table)
        {
            using var writer = new StreamWriter(StorageFilePath, append: true);
            writer.WriteLine(HotelConverter.Instance.Serialize(table));
        }

        public void Clear()
        {
            File.WriteAllText(StorageFilePath, string.Empty);
        }
    }
}
