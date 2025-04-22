using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Menu
{
    public class Menu : GameElement, GameCollectionElement<MenuItem>
    {
        public string Header { get; set; }
        public string RequestTitle { get; set; } = "Выберите ответ";
        public Menu(string id, string header, IEnumerable<MenuItem> gameMenuItems) : base(id)
        {
            Header = header;
            PrintAction = () =>
            {
                Console.WriteLine(Header);
                foreach (var item in Items)
                {
                    item.Print();
                }
            };
            ExecuteAction = () =>
            {
                Console.WriteLine(RequestTitle);
                var Answer = Console.ReadLine();
                foreach (var item in Items) 
                {
                    if (item.Id == Answer)
                    {
                        item.Execute();
                    }
                }
            };
            items = new List<MenuItem>();
            Add(gameMenuItems);
        }
        public void OpenMenu()
        {
            Print();
            Execute();
        }
        public override string Description => "Меню";

        private List<MenuItem> items;


        public IEnumerable<MenuItem> Items => items;

        public void Clear()
        {
            items.Clear();
        }

        public bool Add(MenuItem item)
        {
            items.Add(item);
            return true;
        }

        public bool Add(IEnumerable<MenuItem> addedItems)
        {
            foreach (MenuItem item in addedItems)
            {
                items.Add(item);
            }
            return true;
        }
        public void SetMarkerForItems(string marker)
        {
            foreach(var item in items)
            {
                item.Marker = marker;
            }
        }
    }
}
