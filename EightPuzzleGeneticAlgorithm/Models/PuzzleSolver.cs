using AForge.Genetic;
using EightPuzzleGeneticAlgorithm.Models.GA;
using System;

namespace EightPuzzleGeneticAlgorithm.Models
{
    public class PuzzleSolver
    {

        public bool Resolver(int numeroMaximoIteracoes, ushort[] estadoInicial, ushort[] estadoObjetivo, int tamanhoPopulacao, double chanceCrossover, double chanceMutacao, out int numeroIteracoes, out ushort[] estadoEncontrado)
        {
            // Estados
            //estadoInicial = new ushort[] { 1, 5, 3, 4, 2, 6, 7, 8, 0 };
            //estadoObjetivo = new ushort[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0 };

            //tamanhoPopulacao           
            var chromosome = new Chromosome(estadoInicial);
            var fitnessFuncao = new Fitness(estadoObjetivo);
            var selecao = new RouletteWheelSelection();

            Population population = new Population(tamanhoPopulacao, chromosome, fitnessFuncao, selecao);
            population.CrossoverRate = chanceCrossover;
            population.MutationRate = chanceMutacao;
            int contadorNumeroIteracoes = 0;
            while (true)
            {
                population.RunEpoch();

                ushort[] melhorEstado = ((PermutationChromosome)population.BestChromosome).Value;

                if (EhObjetivoFinal(Utils.ToArrayBidimensional(melhorEstado), Utils.ToArrayBidimensional(estadoObjetivo)))
                {
                    numeroIteracoes = contadorNumeroIteracoes;
                    estadoEncontrado = melhorEstado;
                    return true;
                }

                contadorNumeroIteracoes++;

                if (contadorNumeroIteracoes > numeroMaximoIteracoes)
                {
                    numeroIteracoes = numeroMaximoIteracoes;
                    estadoEncontrado = null;
                    return false;
                }
            }
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
