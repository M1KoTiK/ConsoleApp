using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Table
{
    public interface ITableRow<T>
    {
        public ICollection<T> Row { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void PrintInTop();

        /// <summary>
        /// Отрисовка таблицы с краями 
        /// c разделениями от предыдущей строки
        /// </summary>
        public void PrintInMiddle();

        /// <summary>
        /// 
        /// </summary>
        public void PrintInBottom();
    }
}
