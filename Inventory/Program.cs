using System;

namespace Inventory
{
    class Program
    {
        class Item
        {
            int AT;
            public int Gold;
            public string name;

            public Item(string _name, int _Gold)
            {
                Gold = _Gold;
                name = _name;
            }
        }

        class Inven
        {
            Item[] ArrayItem;
            int ItemX;
            int SelectIndex = 0;





            public Inven(int _X, int _Y)
            {
                if (1 > _X)
                {
                    _X = 1;
                }
                if (1 > _Y)
                {
                    _Y = 1;
                }

                ArrayItem = new Item[_X * _Y];
                ItemX = _X;




            }

            public void Render()
            {

                for (int i = 0; i < ArrayItem.Length; i++)
                {


                    if (i != 0 && 0 == i % ItemX)
                    {
                        Console.WriteLine("");
                    }

                    if (i == SelectIndex)
                    {
                        Console.Write("▣");
                    }
                    else if (ArrayItem[i] == null)
                    {
                        Console.Write("□");
                    }
                    else
                    {
                        Console.Write("■");
                    }


                }
                Console.WriteLine("");


                if (ArrayItem[SelectIndex] != null)
                {

                    Console.WriteLine("현재 선택한 아이템");
                    Console.WriteLine("이름 : " + ArrayItem[SelectIndex].name);
                    Console.WriteLine("가격 : " + ArrayItem[SelectIndex].Gold);
                }
                else
                {
                    Console.WriteLine("비어있는 슬롯입니다");
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.RightArrow:
                        if (SelectIndex >= ArrayItem.Length - 1)
                        {
                            SelectIndex = ArrayItem.Length - 1;

                        }
                        else
                        {
                            SelectIndex += 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (SelectIndex <= 0)
                        {
                            SelectIndex = 0;

                        }
                        else
                        {
                            SelectIndex -= 1;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectIndex <= 5)
                        {
                            

                        }
                        else
                        {
                            SelectIndex -= 5;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectIndex >= ArrayItem.Length - 5)
                        {
                            

                        }
                        else
                        {
                            SelectIndex += 5;
                        }
                        break;

                }

            }

            public void ItemIn(Item _Item)
            {
                int index = 0;

                for (int i = 0; i < ArrayItem.Length; i++)
                {
                    if (ArrayItem[i] == null)
                    {
                        index = i;
                        break;
                    }

                }
                ArrayItem[index] = _Item;

            }

            public void ItemIn(Item _Item, int _Order)
            {
                int index = 0;

                index = _Order;
                ArrayItem[index] = _Item;
            }


        }



        static void Main(string[] args)
        {

            Inven newInven = new Inven(5, 3);


            newInven.ItemIn(new Item("철검", 500));
            newInven.ItemIn(new Item("갑옷", 1000));
            newInven.ItemIn(new Item("포션", 200), 5);

            while (true)
            {
                Console.Clear();
                newInven.Render();

            }







        }
    }
}
