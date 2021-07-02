using System;

class FightUnit
{
    protected string name = "NONE";
    protected int AT = 10;
    protected int HP = 50;
    protected int MAXHP = 100;

    public void StatusRender()
    {

        Console.WriteLine("------------------");
        Console.WriteLine(name + "의 능력치");
        Console.WriteLine("공격력 : " + AT);
        Console.Write("HP : " + HP);
        Console.WriteLine(" / " + MAXHP);
        Console.WriteLine("------------------");

    }

    public bool IsLive()
    {
       
        return HP >= 0;

    }

    public void Damage(FightUnit _OtherUnit)
    {
        while(IsLive() || _OtherUnit.IsLive())
        {
            HP -= _OtherUnit.AT;
            Console.Write(name + "이");
            Console.WriteLine(_OtherUnit.AT + "만큼의 피해를 입었습니다.");
            Console.ReadKey();
            if (IsLive() && _OtherUnit.IsLive())
            {
                _OtherUnit.HP -= AT;
                Console.Write(_OtherUnit.name + "이");
                Console.WriteLine(AT + "만큼의 피해를 입었습니다.");
                Console.ReadKey();
            }
            else
            {
                if (HP <= 0)
                {
                    Console.WriteLine("결판이 났습니다.");
                    Console.WriteLine(name + "의 패배입니다.");
                    Console.ReadKey();
                }
                else if (_OtherUnit.HP <= 0)
                {
                    Console.WriteLine("결판이 났습니다.");
                    Console.WriteLine(_OtherUnit.name + "의 패배입니다.");
                    Console.ReadKey();
                }
                return;
            }

        }
        
        
        
    }
}


class Player : FightUnit
{    
    public void Heal()
    {
        if(HP < 91)
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
            HP = 100;

            Console.Clear();
            Console.WriteLine("체력이 최대치입니다.");
            Console.Write("HP : " + HP);
            Console.WriteLine(" / " + MAXHP);
            Console.ReadKey();

        }
    }
    
    public Player()
    {
        name = "플레이어";
    }

    

}



class Monster : FightUnit
{
    public Monster()
    {
        name = "몬스터";
        AT = 5;
    }


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
        static void Field(Player _player)
        {
            
            Monster newMonster = new Monster();

            while (true)
            {
                Console.Clear();
                _player.StatusRender();
                newMonster.StatusRender();
                Console.WriteLine("1.싸운다");
                Console.WriteLine("2.런한다");
                Console.ReadKey();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                       
                        newMonster.Damage(_player);
                       
                        break;
                    case ConsoleKey.D2:
                        return;
                    default:
                        break;
                }
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
            Player newPlayer = new Player();


            while (true)
            {
                
                STARTSELECT SelectCheck = StartSelect();

                switch (SelectCheck)
                {
                    case STARTSELECT.SELECTTOWN:
                        Town(newPlayer);
                        break;
                    case STARTSELECT.SELECTFILED:
                        Field(newPlayer);
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


