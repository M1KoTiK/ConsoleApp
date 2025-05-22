using ConsoleApp.DataBase.HotelDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.DataBase.HotelDB;
using ConsoleApp.ConsoleObject.Table.CharSet;
using ConsoleApp.ConsoleObject.Table.TableRows;

namespace ConsoleApp.ConsoleObject.Table.TableRows.CustomRows;
public class HotelRow : TableRow
{
    public Hotel Hotel { get; }
    public HotelRow(Hotel hotel, ITableCharSet? characterSet = null) : base(ConvertHotelToRow(hotel), characterSet)
    {
        Hotel = hotel;
    }
    private static IList<object> ConvertHotelToRow(Hotel hotel)
    {
        return new List<object>
        {
            hotel.Id,
            hotel.Name,
            hotel.City,
            hotel.Capacity,
            hotel.Price.ToString("F2"),
        };
    }

}
