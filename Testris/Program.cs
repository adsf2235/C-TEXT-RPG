using System;
using System.Collections.Generic;

namespace Testris
{

   
    class Program
    {
        static void Main(string[] args)
       {
            TETRISSCREEN NewSC = new TETRISSCREEN(10, 15, true); ;
            ACCSCREEN NewASC = new ACCSCREEN(NewSC);
            Block newBlock = new Block(NewSC,NewASC);

            while (true)
            {
                for (int i = 0; i < 100000000; i++)
                {
                    int a = 0;
               }

                Console.Clear();
                NewSC.Render();
                
                NewSC.Clear();
                NewASC.Render();
               // NewASC.DestroyCheck();
                newBlock.Move();
                

            }
            

        } 
    }
}
