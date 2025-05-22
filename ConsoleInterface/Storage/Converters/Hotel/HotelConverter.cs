using ConsoleApp.DataBase.HotelDB.Models;
using ConsoleApp.Storage.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Storage.Converters.Hotel
{
    public class HotelConverter : IConverter<DataBase.HotelDB.Models.Hotel>
    {
        public static HotelConverter Instance = new HotelConverter();
        public DataBase.HotelDB.Models.Hotel Deserialize(string value)
        {   
            if (value == null || value == string.Empty)
            {
                return new DataBase.HotelDB.Models.Hotel();
            }

            var values = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return new DataBase.HotelDB.Models.Hotel() { Id = values[0].Trim(), Name = values[1].Trim(), City = values[2].Trim(), Capacity = int.Parse(values[3].Trim()), Price = double.Parse(values[4].Trim() +","+ values[5].Trim()) };
        }

        public string Serialize(DataBase.HotelDB.Models.Hotel value)
        {
            return $"{value.Id}, {value.Name}, {value.City}, {value.Capacity}, {value.Price.ToString("N5")}";
        }
    }

}
 