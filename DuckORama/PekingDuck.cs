using System;

namespace DuckORama
{
    public class PekingDuck : Duck
    {
        public PekingDuck()
        {
            FlyBehaviour = new FlyWithWings();
            QuackBehaviour = new Quack();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("I am a Peking Duck. Delicious ....");
        }
    }
}
