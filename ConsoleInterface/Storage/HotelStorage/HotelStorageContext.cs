using ConsoleTextInterface.DataBase.HotelDB.Models;
using ConsoleTextInterface.Storage.Converters.Hotel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextInterface.DataBase.HotelDB
{
    public class HotelStorageContext : StorageContext<HotelModel>
    {
        public static HotelStorageContext Instance = new HotelStorageContext();
        public string StorageFilePath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage\\HotelStorage\\HotelStorage.txt");

        public void FillStorageRandomHotels(int count)
        {
            Clear();
            var random = new Random();
            List<string> names = new List<string>
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
                "Украина (Radisson)",
                "Хилтон Москва Ленинградская",
                "Шератон Палас",
                "Азимут Отель",
                "Золотое Кольцо",
                "Пекин",
                "Санкт-Петербург",
                "Коринтия Невский Палас",
                "Октябрьская",
                "Хаятт Ридженси Екатеринбург",
                "Марриотт Новый Арбат"
            };
            List<string> сities = new List<string>
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
            for (var i = 0; i < count; i++)
            {
                var price = random.NextDouble() * 2000;
                var capacity = random.Next(100, 200);
                var name = names[random.Next(names.Count-1)];
                var city = сities[random.Next(сities.Count - 1)];
                var hotel = new HotelModel()
                {
                    Name = name,
                    City = city,
                    Capacity = capacity,
                    Price = price
                };
                WriteTable(hotel);
            }



        }

        public void DeleteTables(IEnumerable<HotelModel> tables)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<HotelModel> ReadTables(int count = -1)
        {
            var outputList = new List<HotelModel>();
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

        public void WriteTables(IEnumerable<HotelModel> tables)
        {
            using var writer = new StreamWriter(StorageFilePath, append: true);

            foreach (var hotel in tables)
            {
                writer.WriteLine(HotelConverter.Instance.Serialize(hotel));
            }
        }

        public void WriteTable(HotelModel table)
        {
            WriteTables(Enumerable.Repeat(table, 1));
        }

        public void Clear()
        {
            File.WriteAllText(StorageFilePath, string.Empty);
        }
    }
}
