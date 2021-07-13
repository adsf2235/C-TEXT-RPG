using System;

namespace Node
{
    class List<T>
    {
        
    }

    class Zone
    {
        public string Name = "None";
        public List<Zone> LinkZone = new List<Zone>();

        public Zone(string _name)
        {
            Name = _name;
        }


        public Zone Update()
        {
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("이곳은" + Name + "입니다");
                Console.WriteLine("이동할수 있는 장소 리스트.");
                for (int i = 0; i < LinkZone.Count; i++)
                {
                    
                }
            }
        }
    }


    class Node<T>
    {
       public T Data;
        public Node<T> Next = null;
        public Node<T> Prev = null;

        public Node(T _Data)
        {
            Data = _Data;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            

            Zone newZone = new Zone("태초마을");
            Zone newZone1 = new Zone("초보사냥터");
            Zone newZone2 = new Zone("중급사냥터");
            Zone newZone3 = new Zone("중급마을");
            Zone newZone = new Zone("태초마을");

        }
    }
}
