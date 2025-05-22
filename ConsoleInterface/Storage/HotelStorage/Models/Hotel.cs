using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataBase.HotelDB.Models
{
    public class Hotel : IEntry
    {
        public Hotel() { }
        public Hotel(string name, string city, int capacity, double price)
        {
            Name = name;
            City = city;
            Capacity = capacity;
            Price = price;
        }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Capacity { get; set; } = 0;
        public double Price { get; set; } = double.NaN;
        public string Id { get; init; } = Guid.NewGuid().GetHashCode().ToString("x").Substring(0, 4);
    }
}
