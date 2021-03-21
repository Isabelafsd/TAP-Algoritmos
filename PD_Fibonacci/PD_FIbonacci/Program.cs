using System;

namespace PD_FIbonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Posição de Fibonacci: ");
            int n = int.Parse(Console.ReadLine());
            //Console.WriteLine("Valor: " + Fib(n));
            Console.WriteLine("Valor: " + fib_PD(n));
            Console.ReadKey();
        }

        static double Fib(int n) {
            if (n <= 2)
                return 1;
            return Fib(n - 1) + Fib(n - 2); 
        }
        static double fib_PD(int n) {
            int[] memory = new int[n + 1]; 
            memory[1] = 1; 
            memory[2] = 1;
            for (int i = 3; i <= n; i++)
            { 
                memory[i] = memory[i - 1] + memory[i - 2]; 
            } 
            return memory[n]; 
        }
    }
}
