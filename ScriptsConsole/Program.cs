using System;
using System.Collections.Generic;

namespace ScriptsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Script 1: Números del 0 al 100, aumentando de 3 en 3 ===");
            Console.WriteLine();
            PrintNumbers();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("=== Script 2: Combinaciones de cadenas ===");
            Console.WriteLine();
            string[] inputs = { "hat", "abc", "Zu6" };
            PrintAllCombinations(inputs);

            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        
        static void PrintNumbers(int current = 0)
        {
            if (current > 100)
                return;

            Console.Write(current);

            
            if (current + 3 <= 100)
                Console.Write(", ");

            
            PrintNumbers(current + 3);
        }

        
        static List<string> GetAllCombinations(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new List<string>();

            if (input.Length == 1)
                return new List<string> { input };

            var result = new List<string>();

            
            char firstChar = input[0];

            
            var restCombinations = GetAllCombinations(input.Substring(1));

            
            foreach (var combination in restCombinations)
            {
                
                for (int i = 0; i <= combination.Length; i++)
                {
                    
                    string newCombination = combination.Substring(0, i) + firstChar + combination.Substring(i);
                    result.Add(newCombination);
                }
            }

            return result;
        }

        
        static void PrintAllCombinations(string[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                var combinations = GetAllCombinations(inputs[i]);
                Console.WriteLine($"{i + 1} {string.Join(",", combinations)}");
            }
        }
    }
}
