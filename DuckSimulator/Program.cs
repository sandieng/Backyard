using DuckORama;
using System;

namespace DuckSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Duck-O-Rama Duck Simulator v1.0");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();


            Duck pekingDuck = new PekingDuck();
            pekingDuck.DisplayInfo();
            pekingDuck.Fly();
            pekingDuck.Quack();
            pekingDuck.Swim();

            Console.WriteLine();

            Duck rubberDuck = new RubberDuck();
            rubberDuck.DisplayInfo();
            rubberDuck.Fly();
            rubberDuck.Quack();
            rubberDuck.Swim();

            Console.WriteLine();


            Console.WriteLine("Something strange happened. A rubber duck that can FLY.");
            rubberDuck.SetFlyBehaviour(new FlyWithWings());
            rubberDuck.DisplayInfo();
            rubberDuck.Fly();
            rubberDuck.Quack();
            rubberDuck.Swim();

            Console.ReadKey();
        }
    }
}
