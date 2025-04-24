using ConsoleTextGame.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Table
{
    public class TableRow<T> : ITableRow<T>
    {
        public ICollection<T> Row { get; set; }
        private ITableCharacterSet characterSet;
        public TableRow(ICollection<T> row, ITableCharacterSet characterSet)
        {
            Row = row;
            this.characterSet = characterSet;
            foreach (var item in row)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                symbolsCount.Add(item.ToString().Length);
            }

        }

        private List<int> symbolsCount = new List<int>();


        public void PrintInTop()
        {
            PrintHeaderLine();
        }

        public void PrintInMiddle()
        {
            throw new NotImplementedException();
        }

        public void PrintInBottom()
        {
            throw new NotImplementedException();
        }

        private void PrintHeaderLine()
        {
            Console.Write(characterSet.LeftTopCorner);
            for(int i = 0; i < symbolsCount.Count; i++)
            {
                var lenght = symbolsCount[i];
                if (i < symbolsCount.Count - 1)
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.TopSeparator);
                }
                else
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.RightTopCorner);
                }
            }
        }
    }
}
