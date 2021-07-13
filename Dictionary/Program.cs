using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> NewDic = new Dictionary<string, int>();

            NewDic.Add("일입니다", 1);
            NewDic.Add("이입니다", 2);
            NewDic.Add("멀까요", 8941);

            string Key = "멀까요";

            if (true == NewDic.ContainsKey(Key))
            {
                Console.WriteLine(NewDic[Key]);
            }
            

        }
    }
}
