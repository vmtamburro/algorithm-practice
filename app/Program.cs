using System;
using Service;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            //BigONotationPactice();
            //HashTablePractice();
            //HourGlassSum();
            //RotateLeft();
            MinimumBribes();
        }


        private static void MinimumBribes()
        {
            // var arr = new List<int> {4, 1, 2, 3};
            // var arr = new List<int> {1, 2, 3, 5, 4, 6, 7, 8};
            //var arr = new List<int>{2, 5, 1, 3, 4};

            var arr = new List<int> { 2, 1, 5, 3, 4 };
            MinBribes.minimumBribes(arr);
        }

        private static void RotateLeft()
        {
            List<int> arr = new List<int> { 1, 2, 3, 4, 5 };
            var newArr = LeftRotation.rotLeft(arr, 4);
        }

        private static void HourGlassSum()
        {
            List<List<int>> arr = new List<List<int>>
            {
                new List<int>{ 1, 1, 1, 0, 0, 0 },
                new List<int>{ 0, 1, 0, 0, 0, 0 },
                new List<int>{ 1, 1, 1, 0, 0, 0 },
                new List<int>{ 0, 0, 2, 4, 4, 0 },
                new List<int>{ 0, 0, 0, 2, 0, 0 },
                new List<int>{ 0, 0, 1, 2, 4, 0 }
            };

            int maxHourglassSum = global::HourGlassSum.hourglassSum(arr);
            Console.WriteLine("Maximum hourglass sum is: " + maxHourglassSum);
        }

        public static void HashTablePractice()
        {
            var HashTableExample = new HashTableExample();
            HashTableExample.Test();
        }

        public static void BigONotationPactice()
        {
            ConstantTime();
            ExponentialTime();
            LogarithmicTime();
            LinearithmicTime();
            FactorialTime();
        }

        private static void FactorialTime()
        {
            int[] arr = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

            var FactorialTime = new FactorialTime();
            FactorialTime.GeneratePermutations(arr.ToList(), 1, 10);
        }

        private static void LinearithmicTime()
        {
            int[] arr = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

            var LinearithmicTime = new LinearithmicTime();
            LinearithmicTime.MergeSort(arr);
        }

        private static void LogarithmicTime()
        {
            int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var LogarithmicTime = new LogarithmicTime();
            LogarithmicTime.BinarySearch(arr, 3);
        }


        private static void ConstantTime()
        {
            int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var constantTime = new ConstantTime();
            constantTime.GetFirstElement(arr);
        }

        private static void ExponentialTime()
        {
            var exponentialTime = new ExponentialTime();
            exponentialTime.Fibonacci(10);
        }
    }
}