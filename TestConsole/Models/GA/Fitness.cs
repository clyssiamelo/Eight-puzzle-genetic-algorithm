using AForge.Genetic;
using System;

namespace TestConsole.Models.GA
{
    public class Fitness : IFitnessFunction
    {
        public double Evaluate(IChromosome chromosome)
        {
            return new Random().Next(20);
        }
    }
}
