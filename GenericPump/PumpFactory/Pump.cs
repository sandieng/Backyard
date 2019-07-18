using System;

namespace PumpFactory
{
    public class Pump : Base, IPump
    {
        public Pump(string pumpName, string remoteUrl) : base(pumpName, remoteUrl)
        {
        }

        public void Start()
        {
            var name = System.Reflection.Assembly.GetExecutingAssembly().FullName;

            Console.WriteLine($"{PumpName} Pump started");
            // TODO: Do what you need to do here
            // Maybe call some fetching method
            // Then maybe call some update method
            // Then update the database that the pump has ended
        }

        private void Fetch()
        {
            Console.WriteLine("Fetching data");
        }

        private void Update()
        {
            Console.WriteLine("Updating data");
        }
    }
}