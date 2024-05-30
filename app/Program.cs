using System;
using Service;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            BigONotationPactice();
        }

        public static void BigONotationPactice()
        {
            //ConstantTime();
            //ExponentialTime();
            //LogarithmicTime();
            LinearithmicTime();
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