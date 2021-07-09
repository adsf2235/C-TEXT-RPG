using System;

namespace Inventory_3rd
{
    class Item
    {
        int gold;
        string name;
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inven PInven = new Inven(5, 3);

            while (true)
            {
                Console.Clear();
                PInven.Render();
                Console.ReadKey();
            }
        }
    }
}
