using System;

namespace DuckORama
{
    public abstract class Duck
    {
        public IFlyBehaviour FlyBehaviour { get; set; }
        public IQuackBehaviour QuackBehaviour { get; set; }

        public void Fly()
        {
            FlyBehaviour.Fly();
        }

        public void Quack()
        {
            QuackBehaviour.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("I am gliding across the water....");
        }

        public void SetFlyBehaviour(IFlyBehaviour flyBehaviour)
        {
            FlyBehaviour = flyBehaviour;
        }

        public void SetQuackBehaviour(IQuackBehaviour quackBehaviour)
        {
            QuackBehaviour = quackBehaviour;
        }

        public abstract void DisplayInfo();
    }
}
