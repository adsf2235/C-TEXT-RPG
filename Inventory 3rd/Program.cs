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
        string name;
        bool IsSelected = true;
        


        public Inven(int _X, int _Y, string _name)
        {
            name = _name;
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

        public Item BuyCheck()
        {
            return ArrItem[SelectIndex];
        }

        public void Buy(Inven _inven)
        {
            if (IsSelected)
            {
                if (ArrItem[SelectIndex] != null)
                {
                    Console.Clear();
                    Console.WriteLine(ArrItem[SelectIndex].name + "을 구매하였습니다");
                    Console.WriteLine("금액은 " + ArrItem[SelectIndex].gold + "입니다");
                    _inven.ItemIn(BuyCheck());
                    ArrItem[SelectIndex] = null;
                    Console.ReadKey();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("선택된 아이템이 없습니다");
                    Console.ReadKey();
                }
            }
            
        }
        
     
            
        

      

        public void Sale()
        {
            if (IsSelected)
            { if(ArrItem[SelectIndex] != null)
                {
                    Console.Clear();
                    Console.WriteLine("판매 완료하였습니다. " + ArrItem[SelectIndex].gold + "의 수익을 얻었습니다.");
                    ArrItem[SelectIndex] = null;
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("선택된 물건이 없습니다.");
                    Console.ReadKey();
                }
                
                
            }
        }

        public void Toggle_IsSelected()
        {
            IsSelected = !IsSelected;
            SelectIndex = 0;
            CheckIndex = 0;
        }
      

        public void ChangeInven()
        {

        }



        public bool OverCheck(int _CheckIndex)
        {
            if (_CheckIndex < 0 || _CheckIndex >= ArrItem.Length)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void RightMove()
        {

            CheckIndex += 1;
            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }
            else
            {
                CheckIndex -= 1;
            }



        }
        public void LeftMove()
        {

            CheckIndex -= 1;
            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }
            else
            {
                CheckIndex += 1;
            }

        }
        public void UpMove()
        {

            CheckIndex -= XIndex;
            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }
            else
            {
                CheckIndex += XIndex;
            }

        }
        public void DownMove()
        {
            CheckIndex += XIndex;

            if (true == OverCheck(CheckIndex))
            {
                SelectIndex = CheckIndex;
            }
            else
            {
                CheckIndex -= XIndex;
            }




        }

        public void Render()
        {
            Console.WriteLine("");
            Console.WriteLine(name + "의 인벤토리");
            Console.WriteLine("");

            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (i != 0 && i % XIndex == 0)
                {
                    Console.WriteLine("");

                }

                if (IsSelected)
                {
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
                else
                {
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
            Console.WriteLine("");
            
            Console.WriteLine("현재 선택한아이템");
            if (IsSelected)
            {
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
            Inven PInven = new Inven(5, 3, "플레이어");
            PInven.ItemIn(new Item("철검", 400));
            PInven.ItemIn(new Item("갑옷", 1400));
            PInven.ItemIn(new Item("철검", 400), 569);

            Inven Store = new Inven(5, 3, "상점");
            Store.ItemIn(new Item("철검", 400));
            Store.ItemIn(new Item("HP포션", 20));
            Store.ItemIn(new Item("MP포션", 30));
            Store.ItemIn(new Item("리볼버", 1000));
            Store.ItemIn(new Item("바주카", 25000));
            Store.Toggle_IsSelected();

            while (true)
            {
                Console.Clear();
                PInven.Render();
                Store.Render();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("인벤토리 전환 : Space Bar");
                Console.WriteLine("판매 / 구매 : G");

                switch (Console.ReadKey().Key)
                {
                    
                    case ConsoleKey.LeftArrow:
                        PInven.LeftMove();
                        Store.LeftMove();
                        break;
                    case ConsoleKey.RightArrow:
                        PInven.RightMove();
                        Store.RightMove();
                        break;
                    case ConsoleKey.UpArrow:
                        PInven.UpMove();
                        Store.UpMove();
                        break;
                    case ConsoleKey.DownArrow:
                        PInven.DownMove();
                        Store.DownMove();
                        break;
                    case ConsoleKey.Spacebar:
                        PInven.Toggle_IsSelected();
                        Store.Toggle_IsSelected();
                        break;
                    case ConsoleKey.G:
                        PInven.Sale();
                        Store.Buy(PInven);
                        
                        break;
                        
                }
                
            }
        }
    }
}
