using System;
using System.Collections.Generic;

namespace SomeQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            test testob = new test()
            {
                id=123,
                name="hong son",
                addrress="quang tri",
                phonenum=0982,
            };

            Console.WriteLine(testob);
        }
    }
}
