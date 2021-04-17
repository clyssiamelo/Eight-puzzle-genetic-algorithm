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
            ushort[,] novoEstado = Utils.ToArrayBidimensional(this.val);

            while (contadorMovimentos < numeroDeMovimento)
            {
                int movimento;
                while (true)
                {
                    movimento = random.Next(4);
                    if (Movimento.MovimentoEhPossivel(movimento, novoEstado))
                        break;
                }

                switch (movimento)
                {
                    case 0: // Mover para cima
                        Movimento.GerarPossibilidadeCima(novoEstado, out novoEstado);
                        break;

                    case 1: // Mover para direita
                        Movimento.GerarPossibilidadeDireita(novoEstado, out novoEstado);
                        break;
                    case 2: // Mover para baixo
                        Movimento.GerarPossibilidadeBaixo(novoEstado, out novoEstado);
                        break;
                    case 3: // Mover para esquerda
                        Movimento.GerarPossibilidadeEsquerda(novoEstado, out novoEstado);
                        break;
                }
            }

            ushort[] novoEstadoGerado = Utils.ToArray(novoEstado);

            return new Chromosome(novoEstadoGerado);
        }

        public override void Crossover(IChromosome pair)
        {

        }

    }
}
