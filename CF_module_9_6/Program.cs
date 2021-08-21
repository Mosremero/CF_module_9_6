using System;
using System.Collections.Generic;

namespace CF_module_9_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Exception> listOfException = new();
            listOfException.Add(new MyException("Собственное исключение"));
            listOfException.Add(new FormatException());
            listOfException.Add(new IndexOutOfRangeException());
            listOfException.Add(new DivideByZeroException());
            listOfException.Add(new ArgumentOutOfRangeException());

            foreach (Exception exc in listOfException)
            {
                try
                {
                    throw exc;
                }
                catch
                {
                    Console.WriteLine(exc);
                }
            }
        }
    }

    public class MyException : Exception
    {
        public MyException()
        {}
        public MyException(string message) : base(message)
        {}
    }



}
