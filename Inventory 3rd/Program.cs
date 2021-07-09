using System;

namespace Inventory_3rd
{
    class Item
    {
        int gold;
        string name;

        public Item(string _name, int _gold)
        {
            name = _name;
            gold = _gold;
        }
    }

    class Inven
    {
        Item[] ArrItem;
        int XIndex;

        public Inven(int _X, int _Y)
        {
            if(_X < 1)
            {
                _X = 1;
            }

            if (_Y <1)
            {
                _Y = 1;
            }
            ArrItem = new Item[_X * _Y];
            XIndex = _X;

        }

        public void Render()
        {
            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (i !=0 && i % XIndex == 0 )
                {
                    Console.WriteLine("");

                }

                if (ArrItem[i] != null)
                {
                    Console.Write("■");
                }
                else
                {
                    Console.Write("□");
                }
            }
            
        }

        public void ItemIn(Item item)
        {
            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (ArrItem[i] == null)
                {
                    ArrItem[i] = item;
                    break;
                }
            }
            
        }

        public void ItemIn(Item item, int _Order)
        {
            if (_Order <= 0)
            {
                _Order = 0;

            }
            if (_Order >= ArrItem.Length)
            {
                _Order = ArrItem.Length - 1;
            }
            if (ArrItem[_Order] != null)
            {
                ItemIn(item);
            }
            else
            {
                ArrItem[_Order] = item;
            }
        }
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inven PInven = new Inven(5, 3);
            PInven.ItemIn(new Item("철검",400));
            PInven.ItemIn(new Item("갑옷", 1400));
            PInven.ItemIn(new Item("철검", 400),569);

            while (true)
            {
                Console.Clear();
                PInven.Render();
                Console.ReadKey();
            }
        }
    }
}
