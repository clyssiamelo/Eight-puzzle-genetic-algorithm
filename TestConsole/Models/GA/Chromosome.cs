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
            ushort[,] novoEstado = ToArrayBidimensional(this.val);

            // Converter array para matriz | converter o estado atual em uma matriz


            while (contadorMovimentos < numeroDeMovimento)
            {
                int movimento = 0;
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


            ushort[] novoEstadoGerado = ToArray(novoEstado);

            return new Chromosome(novoEstadoGerado);
        }

        public override void Crossover(IChromosome pair)
        {

        }

        public ushort[,] ToArrayBidimensional(ushort[] estado)
        {
            int totalQuadrados = estado.Length;
            ushort[,] novoEstado = new ushort[3, 3];

            int contador = 0;

            for (int i = 0; i < novoEstado.GetLength(0); i++)
            {
                for (int j = 0; j < novoEstado.GetLength(1); j++)
                {
                    novoEstado[i, j] = estado[contador];
                    contador++;
                }
            }

            return novoEstado;
        }
        // Converter matriz para array
        public static ushort[] ToArray(ushort[,] estado)
        {

            int totalQuadrados = estado.GetLength(0) * estado.GetLength(1);
            ushort[] arrNoAtual = new ushort[totalQuadrados];
            int contAux = 0;

            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    arrNoAtual[contAux] = estado[i, j];
                    contAux++;
                }
            }
            return arrNoAtual;
        }

    }
}
