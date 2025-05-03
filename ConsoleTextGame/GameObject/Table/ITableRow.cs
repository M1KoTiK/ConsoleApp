using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Table
{
    public interface ITableRow<T>
    {
        public IList<T> Row { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void PrintTopLine();

        /// <summary>
        /// Отрисовка таблицы с краями 
        /// c разделениями от предыдущей строки
        /// </summary>
        public void PrintElementLine();

        public void PrintSeparatorLine();

        /// <summary>
        /// 
        /// </summary>
        public void PrintBottomLine();
    }
}
