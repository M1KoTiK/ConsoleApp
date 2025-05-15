using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextInterface.DataBase.HotelDB.Models
{
    public class HotelModel : TableModel
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Capacity { get; set; } = 0;
        public double Price { get; set; } = double.NaN;
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
    }
}
