using System;

class Player
{

}

class Monster
{

}

enum STARTSELECT
{
    SELECTTOWN,
    SELECTFILED,
    NONESELECT
}

namespace text_rpg
{
    class Program
    {
        static STARTSELECT StartSelect()
        {
            Console.Clear();
            Console.WriteLine("1.마을");
            Console.WriteLine("2. 사냥터");
            Console.WriteLine("어디로 가시겠습니까?");
            ConsoleKeyInfo CKI = Console.ReadKey();
            Console.WriteLine("");

            switch (CKI.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("마을로 이동합니다");
                    Console.ReadKey();
                    return STARTSELECT.SELECTTOWN;
                case ConsoleKey.D2:
                    Console.WriteLine("사냥터로 이동합니다");
                    Console.ReadKey();
                    return STARTSELECT.SELECTFILED;
                default:
                    Console.WriteLine("잘못된 선택입니다");
                    Console.ReadKey();
                    return STARTSELECT.NONESELECT;

            }

            static void Town()
            {
                Console.WriteLine("마을에서 무슨일을 하시겠습니까?");
            }

            
        }
        static void Main(string[] args)
        {
            while (true)
            {
               STARTSELECT SelectCheck = StartSelect();

                switch (SelectCheck)
                {
                    case STARTSELECT.SELECTTOWN:
                        Town();
                        break;
                    case STARTSELECT.SELECTFILED:
                        break;
                    case STARTSELECT.NONESELECT:
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
