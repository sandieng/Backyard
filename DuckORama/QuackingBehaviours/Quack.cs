using System;

namespace DuckORama
{
    public class Quack : IQuackBehaviour
    {
        void IQuackBehaviour.Quack()
        {
            Console.WriteLine("I am a real duck that can quack!");
        }
    }
}
