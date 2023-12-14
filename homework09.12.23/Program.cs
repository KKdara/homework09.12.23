using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace homework09._12._23
{
    internal class Program
    {
        static void CountNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + ":" + i);
            }
        }
        static int CalculateSquare(int number)
        {
            return number * number;
        }
        static void CalculateFactorial(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            Console.WriteLine("Factorial of number:" + factorial);
        }
        static async Task CalculateFactorialAsync(int number)
        {
            await Task.Run(() => CalculateFactorial(number));
            Thread.Sleep(8000);

        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Thread thread1 = new Thread(CountNumbers);
            Thread thread2 = new Thread(CountNumbers);
            Thread thread3 = new Thread(CountNumbers);
            thread1.Name = "First thread";
            thread2.Name = "Second thread";
            thread3.Name = "Third thread";
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Thread.Sleep(5000);

            Console.WriteLine("\nTask 2");
            Console.WriteLine("Enter a number:");
            string input = Console.ReadLine();
            bool res = int.TryParse(input, out int number);
            if (res)
            {
                Console.WriteLine("Square of number:" + CalculateSquare(number));
                await CalculateFactorialAsync(number);
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }

            Console.WriteLine("\nTask 3");
            Refl obj = new Refl();
            Type type = obj.GetType();
            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine("Method: " +  method.Name);
            }
            
            Console.WriteLine("(Press any key to continue work)");
            Console.ReadKey();
        }
    }
}
