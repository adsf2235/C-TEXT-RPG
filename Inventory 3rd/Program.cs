using System;

namespace Inventory_3rd
{
    class Item
    {
        int aGold;
        string aName;

        public Item(string _name, int _gold)
        {
            aName = _name;
            aGold = _gold;
        }

        public int gold
        {
            get
            {
                return aGold;
            }

        }

        public string name
        {
            get
            {
                return aName;
            }
        }
    }

    class Inven
    {
        Item[] ArrItem;
        int XIndex;
        int SelectIndex = 0;
        int CheckIndex = 0;

        public Inven(int _X, int _Y)
        {
            if (_X < 1)
            {
                _X = 1;
            }

            if (_Y < 1)
            {
                _Y = 1;
            }
            ArrItem = new Item[_X * _Y];
            XIndex = _X;

        }

        public bool OverCheck(int _CheckIndex)
        {
            if (_CheckIndex >= ArrItem.Length)
            {
                return false;
            }
            if (_CheckIndex < 0)
            {
                return false;
            }
            return true;
        }

        public void RightMove()
        {

            CheckIndex += 1;
            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }

        }
        public void LeftMove()
        {

            CheckIndex -= 1;
            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }

        }
        public void UpMove()
        {

            CheckIndex -= XIndex;
            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }

        }
        public void DownMove()
        {

            CheckIndex += XIndex;
            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }

        }

        public void Render()
        {
            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (i != 0 && i % XIndex == 0)
                {
                    Console.WriteLine("");

                }

                if (i == SelectIndex)
                {
                    Console.Write("▣");
                }
                else if (ArrItem[i] != null)
                {
                    Console.Write("■");
                }
                else
                {
                    Console.Write("□");
                }
               
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("현재 선택한아이템");
            if (ArrItem[SelectIndex] != null)
            {
                Console.WriteLine("이름 : " + ArrItem[SelectIndex].name);
                Console.WriteLine("가격 : " + ArrItem[SelectIndex].gold);
            }
            else
            {
                Console.WriteLine("비어있습니다.");
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
            PInven.ItemIn(new Item("철검", 400));
            PInven.ItemIn(new Item("갑옷", 1400));
            PInven.ItemIn(new Item("철검", 400), 569);

            while (true)
            {
                Console.Clear();
                PInven.Render();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        PInven.LeftMove();
                        break;
                    case ConsoleKey.RightArrow:
                        PInven.RightMove();
                        break;
                    case ConsoleKey.UpArrow:
                        PInven.UpMove();
                        break;
                    case ConsoleKey.DownArrow:
                        PInven.DownMove();
                        break;
                }

            }
        }
    }
}
