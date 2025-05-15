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


    }
}
