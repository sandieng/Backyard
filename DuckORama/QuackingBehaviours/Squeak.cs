using System;

namespace DuckORama
{
    public class Squeak : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("I am not a real duck. I can only squeak ....");
        }
    }
}
