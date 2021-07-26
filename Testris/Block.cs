using System;
using System.Collections.Generic;
using System.Text;

namespace Testris
{
    enum BLOCKDIR
    {
        BD_T,
        BD_R,
        BD_B,
        BD_L,
        BD_MAX,
    }

    enum BLOCKTYPE
    {
        BT_I,
        BT_L,
        BT_J,
        BT_Z,
        BT_S,
        BT_T,
        BT_O,
        BT_MAX,
    }
    partial class Block
    {
        TETRISSCREEN TScreen = null;
        ACCSCREEN AccScreen = null;

        int X = 0;
        int Y = 0;
        BLOCKDIR Dir = BLOCKDIR.BD_T;
        string[][] Arr = null;
        Random newRandom = new Random();

        BLOCKTYPE CurBlockType = BLOCKTYPE.BT_I;
        BLOCKDIR CurDirType = BLOCKDIR.BD_T;



        public Block(TETRISSCREEN _TScreen, ACCSCREEN _AccScreen)
        {
            AccScreen = _AccScreen;
            TScreen = _TScreen;
            DataInit();
            RandomBlockSet();
            SettingBlock(CurBlockType, CurDirType);
        }

        public void SetAccScreen()
        {
            for (int y = 0; y < 4; ++y)
            {
                for (int x = 0; x < 4; ++x)
                {
                    if ("■" == Arr[y][x])
                    {
                        AccScreen.SetBlock(Y + y - 1, X + x, Arr[y][x]);

                    }
                }
            }
        }

        public void Reset()
        {
            RandomBlockSet();
            X = 0;
            Y = 1;
            SettingBlock(CurBlockType, CurDirType);
        }

       
        public bool DownCheck()
        {

            for (int y = 0; y < 4; ++y)
            {
                for (int x = 0; x < 4; ++x)
                {
                    if ("■" == Arr[y][x])
                    {
                        if (AccScreen.Y == Y + y || true == AccScreen.IsBlock( Y + y, x + X, "■"))
                        {
                            SetAccScreen();
                            Reset();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Down()
        {
            if (true == DownCheck())
            {
                return;
            }

            Y += 1;


        }


        public void RandomBlockSet()
        {
            int RandomBlock = newRandom.Next((int)BLOCKTYPE.BT_I, (int)BLOCKTYPE.BT_MAX);
            CurBlockType = (BLOCKTYPE)RandomBlock;

        }

        private void SettingBlock(BLOCKTYPE _Type, BLOCKDIR _Dir)
        {
            Arr = AllBlock[(int)_Type][(int)_Dir];
        }

        public void Input()
        {
            if (true == Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        X -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        X += 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Down();
                        
                        
                        break;
                    case ConsoleKey.UpArrow:
                        --CurDirType;
                        if (0 > CurDirType)
                        {
                            CurDirType = BLOCKDIR.BD_L;
                        }
                        SettingBlock(CurBlockType, CurDirType);
                        break;
                    default:
                        break;
                }
            }
        }

        public void Move()
        {
            Input();

            for (int y = 0; y < 4; ++y)
            {
                for (int x = 0; x < 4; ++x)
                {
                    if (Arr[y][x] == "□")
                    {
                        continue;
                    }
                    TScreen.SetBlock(Y + y, X + x, Arr[y][x]);
                }
            }

        }

    }
}
