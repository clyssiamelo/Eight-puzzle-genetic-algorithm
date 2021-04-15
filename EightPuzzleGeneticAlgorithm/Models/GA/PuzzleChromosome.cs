using AForge.Genetic;

namespace EightPuzzleGeneticAlgorithm.Models.GA
{
    internal class PuzzleChromosome : PermutationChromosome
    {        
        public PuzzleChromosome(int length) : base(length)
        {
        }

        public override IChromosome CreateNew()
        {
            return base.CreateNew();
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
