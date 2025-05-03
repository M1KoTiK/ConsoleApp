using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Table
{
    public interface ITableCharacterSet
    {
        string LeftTopCorner { get; set; }
        string RightTopCorner { get; set; }
        string LeftBottomCorner { get; set; } 
        string RightBottomCorner { get; set; } 
        string TopBottomBorder { get; set; } 
        string LeftRightBorderOrSeparator { get; set; }
        string RightSeparatorBorder { get; set; }
        string LeftSeparatorBorder { get; set; }
        public string MiddleSeparator { get; set; }

        public string BottomSeparator { get; set; } 

        public string TopSeparator { get; set; }  
    }
}
