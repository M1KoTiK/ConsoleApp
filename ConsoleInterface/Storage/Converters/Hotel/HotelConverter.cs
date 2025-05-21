using ConsoleTextInterface.DataBase.HotelDB.Models;
using ConsoleTextInterface.Storage.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextInterface.Storage.Converters.Hotel
{
    public class HotelConverter : IConverter<HotelModel>
    {
        public static HotelConverter Instance = new HotelConverter();
        public HotelModel Deserialize(string value)
        {   
            if (value == null || value == string.Empty)
            {
                return new HotelModel();
            }

            var values = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return new HotelModel() { Id = values[0].Trim(), Name = values[1].Trim(), City = values[2].Trim(), Capacity = int.Parse(values[3].Trim()), Price = double.Parse(values[4].Trim() + values[5].Trim()) };
        }

        public string Serialize(HotelModel value)
        {
            return $"{value.Id}, {value.Name}, {value.City}, {value.Capacity}, {value.Price.ToString("N5")}";
        }
    }

}
