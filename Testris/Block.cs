using System;
using System.Collections.Generic;
using System.Text;

namespace Testris
{

    enum BLOCKTYPE
    {
        BT_I,
        BT_L,
        BT_J,
        BT_Z,
        BT_S,
        BT_T,
        BT_O,
    }
    class Block
    {
        TETRISSCREEN TScreen = null;

        int X = 0;
        int Y = 0;


            
        public Block(TETRISSCREEN _TScreen)
        {
            TScreen = _TScreen;
        }

        public void Input()
        {
            if (true == Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        X -= 1;
                        break;
                    case ConsoleKey.D:
                        X += 1;
                        break;
                    case ConsoleKey.S:
                        Y += 1;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Move()
        {
            Input();
            TScreen.SetBlock(Y, X, TBLOCK.WALL);
        }

    }
}
