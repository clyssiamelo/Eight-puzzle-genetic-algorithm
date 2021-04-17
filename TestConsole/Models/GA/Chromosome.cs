using AForge.Genetic;
using System;

namespace TestConsole.Models.GA
{
    internal class Chromosome : PermutationChromosome
    {
        public Chromosome(ushort[] estado) : base(estado.Length)
        {
            this.val = estado;
        }

        public Chromosome(int length) : base(length)
        {
        }

        public override IChromosome CreateNew()
        {
            var random = new Random();            

            int numeroDeMovimento = random.Next(10);
            
            int contadorMovimentos = 0;           
            ushort[,] novoEstado; // Converter array para matriz | converter o estado atual em uma matriz

            while (contadorMovimentos < numeroDeMovimento)
            {               
                int movimento = 0;
                while (true)
                {
                    movimento = random.Next(4);
                    if (MovimentoPossivel(movimento))
                        break;
                }

                switch (movimento)
                {
                    case 0: // Mover para cima
                        break;
                    case 1: // Mover para direita
                        break;
                    case 2: // Mover para baixo
                        break;
                    case 3: // Mover para esquerda
                        break;
                    default:
                        break;
                }
            }

            // Converter matriz para array
            ushort[] novoEstadoGerado = new ushort[20];

            return new Chromosome(novoEstadoGerado);       
        }        

        public override void Crossover(IChromosome pair)
        {

        }
    }
}
