using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Table
{
    public class StandartTableCharacterSet : ITableCharacterSet
    {   
        public string LeftTopCorner { get; set; } = "┌";
        public string RightTopCorner { get; set; } = "┐";
        public string LeftBottomCorner { get; set; } = "└";
        public string RightBottomCorner { get; set; } = "┘";
        public string TopBottomBorder { get; set; } = "─";
        public string LeftRightBorder { get; set; } = "│";
        public string RightSeparatorBorder { get; set; } = "┤";
        public string LeftSeparatorBorder { get; set; } = "├";

        public string MiddleSeparator { get; set; } = "┼";

        public string BottomSeparator { get; set; } = "┴";

        public string TopSeparator { get; set; } = "┬";

        public static ITableCharacterSet Instance => new StandartTableCharacterSet();
    }
}
