using System;

namespace Inventory2
{
    class Item
    {
        public int Gold;
        public string name;

        public Item(string _name, int _Gold)
        {
            name = _name;
            Gold = _Gold;
        }
    }

    class Inven
    {
        Item[] ArrInt;
        int XIndex;
        int SelectIndex;


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
            ArrInt = new Item[_X * _Y];

          XIndex = _X;

        }

       
        public void RightMove()
        {
            if (SelectIndex >= ArrInt.Length -1)
            {
              
            }
            else
            {
                SelectIndex += 1;
            }
           
        }
        public void LeftMove()
        {
            if (SelectIndex <= 0)
            {

            }
            else
            {
                SelectIndex -= 1;
            }

        }
        public void UpMove()
        {
            if (SelectIndex <= XIndex )
            {

            }
            else
            {
                SelectIndex -= XIndex;
            }

        }
        public void DownMove()
        {
            if (SelectIndex >= ArrInt.Length - XIndex)
            {

            }
            else
            {
                SelectIndex += XIndex;
            }

        }

        public void ItemIn(string _name, int _Gold)
        {
            int index = 0;
           
            for (int i = 0; i < ArrInt.Length; i++)
            {if(ArrInt[i] == null)
                {
                    index = i;
                    break;
                }               
            }
            ArrInt[index] = new Item(_name, _Gold);
        }

        public void ItemIn(string _name, int _Gold, int _Order)
        {
            int index = 0;

            if(_Order >= ArrInt.Length - 1)
            {
                index = ArrInt.Length - 1;
            }else if (_Order <= 0)
            {
                index = 0;
            }
            else
            {
                index = _Order;
            }
            
            ArrInt[index] = new Item(_name, _Gold);
        }



        public void Render()
        {
            for (int i = 0; i < ArrInt.Length; i++)
            {
                if(i != 0 && i % XIndex == 0)
                {
                    Console.WriteLine("");
                }

                if (SelectIndex == i)
                {
                    Console.Write("★");
                }
                else if (ArrInt[i] == null)
                {
                    Console.Write("○");
                }
                else
                {
                    Console.Write("●");
                }
               
            }

            if(ArrInt[SelectIndex] != null)
            {
                Console.WriteLine("");
                Console.WriteLine("현재 선택한 아이템");
                Console.WriteLine("이름 : " + ArrInt[SelectIndex].name);
                Console.WriteLine("가격 : " + ArrInt[SelectIndex].Gold);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("비어있는 칸입니다");
            }
            

        }



    }


    class Program
    {


        static void Main(string[] args)
        {

            Inven PInven = new Inven(5, 3);
            PInven.ItemIn("철검", 500);
            PInven.ItemIn("검", 500);
            PInven.ItemIn("철", 500);
            PInven.ItemIn("똥", 850, 10);
            PInven.ItemIn("똥", 850, 250);

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
                    case ConsoleKey.DownArrow:
                        PInven.DownMove();
                        break;
                    case ConsoleKey.UpArrow:
                        PInven.UpMove();
                        break;

                }
                
            }

        }
    }
}
