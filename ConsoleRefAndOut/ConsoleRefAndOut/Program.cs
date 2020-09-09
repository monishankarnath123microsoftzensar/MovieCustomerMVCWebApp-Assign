using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRefAndOut
{
    //both ref and out keyword can be passed as parameter to any method
    class RefAndOut
    {
        public static int Test(ref int x)//here x is now a reference type
        {
            return x=x*x;
        }
        public static int Test1(int x)
        {
            return x =x*x;
        }
        public static int Test2(out int x)// out keyword is also passed by reference
        {
            x = 11;
            return x = x * x;
        }
        public static int Test3(in int x)
        {
            return x * x;
        }

    }
    
    class Program
    {
        static List<int> MyList = new List<int>();
        static void FillValues()
        {
            MyList.Add(1);
            MyList.Add(2);
            MyList.Add(3);
            MyList.Add(4);
            MyList.Add(5);
        }
        static void Main(string[] args)
        {
            int age = 22;
            //int outVal;
            int a = 3;
            int[,] arr = new int[5, 2] { { 0, 0 }, { 1, 2 }, { 2, 5 }, { 3, 8 }, { 7, 9 } };
            FillValues();
            Console.WriteLine("Ref Eg: "+ RefAndOut.Test(ref age));
            Console.WriteLine("Normal Eg: " + RefAndOut.Test1(10));
            Console.WriteLine("Out Eg: " + RefAndOut.Test2(out age));
            Console.WriteLine("in Eg: " + RefAndOut.Test3(in a));
            Console.WriteLine("--------Twodimentional array");
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    Console.WriteLine($"a[{i},{j}] = {arr[i,j]}");
                }
            }
            Console.WriteLine("-------Yield Example-------");
            foreach (var item in Filter())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------Yield Running Total-------");
            foreach (var item in RunningTotal())
            {
                Console.WriteLine(item);
            }
            
            Console.Read();
            
        }
        static IEnumerable<int> RunningTotal()
        {
            int runningTotal = 0;
            foreach (var item in MyList)
            {
                runningTotal += item;
                yield return (runningTotal);

            }
        }
        static IEnumerable<int> Filter()
        {
            foreach (var item in MyList)
            {
                if (item > 3)
                {
                    yield return item;
                }

            }
        }
    }
    
}
//ref keyword passes arguments by reference. This means any changes made to the arguments or parameter in the method will be reflected in the variable of the calling method