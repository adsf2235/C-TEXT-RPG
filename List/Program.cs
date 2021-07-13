using System;
using System.Collections.Generic;

namespace List
{
   class Item
    {

    }

    class Zone
    {
        public string Name = "None";
        public List<Zone> LinkZone = new List<Zone>();

        public Zone Update()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("이곳은 " + Name + "입니다");
                Console.WriteLine("이동할수 있는 장소 리스트");
                for (int i = 0; i < LinkZone.Count; i++)
                {
                    Console.WriteLine((i + 1).ToString() +"." + LinkZone[i].Name);
                }
               int Number = (int)Console.ReadKey().Key;
                Number -= 49;
                return LinkZone[Number];
            }
        }
        public Zone(string _Name)
        {
            Name = _Name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Zone NewZone0 = new Zone("태초마을");
            Zone NewZone1 = new Zone("초보사냥터");
            Zone NewZone2 = new Zone("중급사냥터");
            Zone NewZone3 = new Zone("중급마을");
            Zone NewZone4 = new Zone("고급사냥터");


            NewZone0.LinkZone.Add(NewZone1);
            NewZone0.LinkZone.Add(NewZone2);

            NewZone1.LinkZone.Add(NewZone3);
            NewZone2.LinkZone.Add(NewZone3);
            NewZone3.LinkZone.Add(NewZone4);

            Zone StartZone = NewZone0;
            while (true)
            {
                StartZone = StartZone.Update();
            }
        }
    }
}
