namespace task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArgumentOutOfRangeException ex1 = new ArgumentOutOfRangeException();
            DivideByZeroException ex2 = new DivideByZeroException();
            TimeoutException ex3 = new TimeoutException();
            FileNotFoundException ex4 = new FileNotFoundException();
            MyException ex5 = new MyException();
            Exception[] MyKollectionException = new Exception[5] { ex1, ex2, ex3, ex4, ex5 };

            foreach (Exception e in MyKollectionException)
            {
                try
                {
                    throw e;
                }

                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }

    internal class MyException : Exception
    {
        string missage;
        public MyException() : base("Некоректный формат")
        { }

    }
}
