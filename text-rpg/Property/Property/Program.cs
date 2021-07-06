using System;

namespace Property
{

    class Player
    {
        int HP = 100;
       public int AT = 20;

        public int proAT
        {
            get
            {
                return AT;
                
            }
            set
            {
                AT = value;
            }
        }
    }
    class Program
    {

        

        static void Main(string[] args)
        {
            Player newPlayer = new Player();
            newPlayer.proAT = 150;

            Console.WriteLine(newPlayer.AT);
        }
    }
}
