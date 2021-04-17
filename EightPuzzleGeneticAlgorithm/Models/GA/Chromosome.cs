using AForge.Genetic;
using System;

namespace EightPuzzleGeneticAlgorithm.Models.GA
{
    internal class Chromosome : PermutationChromosome
    {
        public ushort[] EstadoInicial { get; set; }

        public Chromosome(int length, ushort[] estadoInicial) : base(length)
        {
            EstadoInicial = estadoInicial;
        }

        public override IChromosome CreateNew()
        {
            Console.WriteLine("Estou criando um novo estado inicial");
            return new Chromosome(EstadoInicial.Length, EstadoInicial);
        }

        public override void Generate()
        {
            base.Generate();
        }

        public override void Mutate()
        {
            base.Mutate();
        }

        public override void Crossover(IChromosome pair)
        {
            base.Crossover(pair);
        }
    }
}
