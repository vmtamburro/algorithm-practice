using System;
using Service;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Class1();
            string message = service.GetMessage();
            Console.WriteLine(message);
        }
    }
}