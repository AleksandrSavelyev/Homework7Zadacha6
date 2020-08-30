using System;
using System.Globalization;

namespace Homework7Zadacha6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("игра \"быки и коровы\"");
            int ranNum = Randomaizer();
            Console.WriteLine("компьютер загадал четырёхзначное число попробуйте отгадать его");
            int attem = PlayGame(ranNum);
            Console.WriteLine($"ПОЗДРАВЛЯЕМ!!!\nвы отгадали число {ranNum} с {attem} попытки");
        }
        static int Randomaizer ()
        {            
            Random ran = new Random();
            int ranNum = ran.Next(1000, 9999);
            string x = Convert.ToString(ranNum);
            for(int i=0;i<x.Length;i++)
            {
                for(int j=0;j<x.Length;j++)
                {
                    byte num1 = Convert.ToByte(x[j]);
                    byte num2 = Convert.ToByte(x[i]);
                    if(num1!=num2)
                    { 
                    }
                    else if(i==j)
                    {
                        continue;
                    }
                    else
                    {
                        return Randomaizer();
                    }
                }
            }
            return ranNum;
        }
        static int InputNum()
        {
            Console.Write("введите число:\t");
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch
            {
                return InputNum();
            }
            if(num>1000 & num<9999)
            {
                string x = Convert.ToString(num);
                for (int i = 0; i < x.Length; i++)
                {
                    for (int j = 0; j < x.Length; j++)
                    {
                        byte num1 = Convert.ToByte(x[j]);
                        byte num2 = Convert.ToByte(x[i]);
                        if (num1 != num2)
                        {
                        }
                        else if (i == j)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("неверное число повторите ввод");
                            return InputNum();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("неверное число повторите ввод");
                return InputNum();
            }
            return num;
        }
        static int CheckBull(int ran,int read)
        {
            int bull = 0;
            string a = Convert.ToString(ran);
            string b = Convert.ToString(read);
            for(int i=0;i<a.Length;i++)
            {
                for(int j=0;j<b.Length;j++)
                {
                    if(i==j)
                    {
                        continue;
                    }
                    else if(a[j]==b[i])
                    {
                        bull += 1;
                    }                   
                }
            }
            return bull;
        }
        static int CheckCow(int ran,int read)
        {
            int cow = 0;
            string a = Convert.ToString(ran);
            string b = Convert.ToString(read);
            for(int i=0;i<a.Length;i++)
            {
                if (a[i] == b[i])
                {
                    cow += 1;
                }
            }
            return cow;
        }
        static int PlayGame(int ran)
        {
            int attem = 1;
            int read = InputNum();
            if(read==ran)
            {
                return attem;
            }
            else
            {
                int bull = CheckBull(ran, read);
                Console.WriteLine("быки: "+bull);
                int cow = CheckCow(ran, read);
                Console.WriteLine("коровы: "+cow);
            }
            
            return PlayGame(ran)+attem;
        }
    }
}
