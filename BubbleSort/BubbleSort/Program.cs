using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberInputs = string.Empty;
            var sortObject = new BubbleSort();
            
            Console.WriteLine("Enter a comma separated list of numbers that will be sorted:");
            numberInputs = Console.ReadLine();
            sortObject.numbers = numberInputs.Split(',').Select(double.Parse).ToList();
            
            Console.WriteLine("Your input was {0}", numberInputs);
            sortObject.Sort();
            Console.WriteLine("Your sorted items are:");
            sortObject.DisplayList();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Class that will contain a list of input numbers and the methods to handle the sorting
    /// </summary>
    public class BubbleSort
    {
        public List<double> numbers { get; set; } 

        public BubbleSort()
        {
            // ensure an empty list is created
            numbers = new List<double>();
        }

        /// <summary>
        /// Handles the swap of two number
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Swap(ref double x, ref double y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// The actual bubble sort method
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i+1; j < numbers.Count; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        // sets temp values to pass by reference
                        var num1 = numbers[i];
                        var num2 = numbers[j];
                        Swap(ref num1,ref num2);
                        // re-assign the numbers
                        numbers[i] = num1;
                        numbers[j] = num2;
                    }
                }
            }
        }
        /// <summary>
        /// Parses the numbers property to determine if the numbers are in ascending order
        /// </summary>
        /// <param name="index">Optional integer, used typically only for the recursive calls</param>
        /// <returns></returns>
        public Boolean IsSorted(int index = 0)
        {
            if (index== numbers.Count - 1)
            {
                return true;
            } else if (numbers[index] < numbers[index+1])
            {
                return IsSorted(index + 1);
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Simple method for displaying the list of numbers
        /// </summary>
        public void DisplayList()
        {
            foreach (var num in numbers)
            {
                Console.Write(num.ToString() + ' ',0,num.ToString().Length);
            }
        }
    }
}
