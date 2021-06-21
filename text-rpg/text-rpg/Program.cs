using System;

class Player
{
    int AT = 10;
    int HP = 50;
    int MAXHP = 100;

    public void StatusRender()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("공격력 : " + AT);
        Console.Write("HP : " + HP);
        Console.WriteLine(" / " + MAXHP);
        Console.WriteLine("------------------");
    }

    public void Heal()
    {
        if(HP < 100)
        {
            HP += 10;

            Console.Clear();
            Console.WriteLine("체력이 회복되었습니다.");
            Console.Write("HP : " + HP);
            Console.WriteLine(" / " + MAXHP);
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("체력이 최대치입니다.");
            Console.ReadKey();

        }
    }

    

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
            Console.WriteLine("2.사냥터");
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
        }

        static void Town(Player _Player)
        {
            

            while (true)
            {
                Console.Clear();
                _Player.StatusRender();
                Console.WriteLine("");
                Console.WriteLine("마을에서 무슨일을 하시겠습니까?");
                Console.WriteLine("1.HP를 회복한다.");
                Console.WriteLine("2.무기를 강화한다.");
                Console.WriteLine("3.나간다.");
                Console.ReadKey();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        _Player.Heal();
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        return;
                    default:
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            

           
            while (true)
            {
                Player newPlayer = new Player();
                STARTSELECT SelectCheck = StartSelect();

                switch (SelectCheck)
                {
                    case STARTSELECT.SELECTTOWN:
                        Town(newPlayer);
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
