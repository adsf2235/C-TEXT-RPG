using System;
using System.Collections.Generic;

namespace Testris
{

   
    class Program
    {
        static void Main(string[] args)
        {
            TETRISSCREEN NewSC = new TETRISSCREEN(10, 15);
            Block newBlock = new Block(NewSC);

            while (true)
            {
                for (int i = 0; i < 100000000; i++)
                {
                    int a = 0;
               }

                Console.Clear();
                NewSC.Render();
                NewSC.Clear();
                newBlock.Move();
                

            }
            

        } 
    }
}
