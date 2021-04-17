using AForge.Genetic;
using TestConsole.Models.GA;
using System;

namespace TestConsole.Models
{
    public class PuzzleSolver
    {
        public int n { get; set; } = 3;

        public void Resolver()
        {
            int numeroMaximoIteracoes = 10000;

            // Estados
            ushort[] estadoInicial = new ushort[] { 1, 5, 3, 4, 2, 6, 7, 8, 0 };
            ushort[] estadoObjetivo = new ushort[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0 };

            int numeroDiferencas = CompararNumeroDiferencas(ToArrayBidimensional(estadoInicial), ToArrayBidimensional(estadoObjetivo));

            var chromosome = new Chromosome(estadoInicial);
            var fitnessFuncao = new Fitness(estadoObjetivo);
            var selecao = new RouletteWheelSelection();

            Population population = new Population(10, chromosome, fitnessFuncao, selecao);

            int contadorNumeroIteracoes = 0;
            while (true)
            {
                population.RunEpoch();

                var melhorEstado = ((PermutationChromosome)population.BestChromosome).Value;

                if (EhObjetivoFinal(ToArrayBidimensional(melhorEstado), ToArrayBidimensional(estadoObjetivo)))
                {
                    throw new Exception("cheguei ao objetivo");
                }

                contadorNumeroIteracoes++;

                if (contadorNumeroIteracoes > numeroMaximoIteracoes)
                    break;
            }
        }

        private int CompararNumeroDiferencas(ushort[,] estadoInicial, ushort[,] estadoObjetivo)
        {
            int contador = 0;

            for (int i = 0; i < estadoInicial.GetLength(0); i++)
            {
                for (int j = 0; j < estadoInicial.GetLength(0); j++)
                {
                    if (estadoInicial[i, j] != estadoObjetivo[i, j])
                        contador++;
                }
            }

            return contador;
        }

        private ushort[,] ToArrayBidimensional(ushort[] estado)
        {
            int totalQuadrados = estado.Length;
            ushort[,] novoEstado = new ushort[n, n];

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

        private bool EhObjetivoFinal(ushort[,] estado, ushort[,] estadoObjetivo)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    if (estado[i, j] != estadoObjetivo[i, j])
                        return false;
                }
            }

            return true;
        }

    }
}
