using System;

namespace DuckORama
{
    public class FlyWithWings : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("Flap flap flap ...");
        }
    }
}
