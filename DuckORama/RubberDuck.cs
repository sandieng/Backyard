namespace DuckORama
{
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            FlyBehaviour = new FlyNoWay();
            QuackBehaviour = new Squeak();
        }

        public override void DisplayInfo()
        {
            System.Console.WriteLine("I am a Rubber Duck.");
        }
    }
}
