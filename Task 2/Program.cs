using System.Collections.Immutable;
using System.Runtime.Intrinsics.Arm;
using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        static int x = 0;
        static string[] LastNamesCollections;
        public delegate void MyDelegate(int a);
        static void Main(string[] args)
        {
            LastNamesCollections = new string[5] { "Bubnov", "Aisenko", "Ditiev", "Cedov", "Erems" };
            NumberReader numberReader = new NumberReader();
            numberReader.OnRead += ShowNumber;

            do
            {
                try
                {
                    numberReader.Read();
                    x = NumberReader.GetX() ;                   
                }

                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception) 
                {
                    Console.WriteLine("Введено некоректное значение");
                }
            }
            while (x == 0);
            Console.WriteLine("Конец");
        }
        static void ShowNumber(int number)
        {
            switch (number)
            {
                case 1:
                    Array.Sort(LastNamesCollections);
                    foreach (string s in LastNamesCollections)
                        Console.WriteLine(s);
                    break;
                case 2:
                    Array.Sort(LastNamesCollections);
                    Array.Reverse(LastNamesCollections);
                    foreach (string k in LastNamesCollections)
                        Console.WriteLine(k);
                    break;
            }
        }

    }

    class NumberReader
    {
        public delegate void ReadDelegate(int a);
        public event ReadDelegate OnRead;
        public static int number;
        public void Read()
        {
            Console.WriteLine("Введите число 1 или 2");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2)
            {
                throw new MyException ();
            }
            GetNumber(number);
        }

        protected virtual void GetNumber(int number)
        {
            OnRead?.Invoke(number);
        }

        public static int GetX()
        {
            int x = 1;
            return x;
        }
    }

    class MyException : Exception
    {
        public MyException() : base("Вы ввели недопустимую цифру")
        { 
        
        }
    }


}
