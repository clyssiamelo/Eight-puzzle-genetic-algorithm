using AForge.Genetic;
using System;

namespace EightPuzzleGeneticAlgorithm.Models.GA
{
    public class Fitness : IFitnessFunction
    {
        public ushort[] EstadoObjetivo { get; set; }

        public Fitness(ushort[] estadoObjetivo)
        {
            EstadoObjetivo = estadoObjetivo;
        }

        /// <summary>
        /// Retorna o número de posições no lugar comparando com o estado objetivo
        /// </summary>        
        public double Evaluate(IChromosome chromosome)
        {
            var valor = ((PermutationChromosome)chromosome).Value;

            ushort[,] estado = Utils.ToArrayBidimensional(valor);
            ushort[,] estadoObjetivo = Utils.ToArrayBidimensional(EstadoObjetivo);

            int fitness = 0;
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    if (estado[i, j] == estadoObjetivo[i, j])
                    {
                        fitness++;
                    }
                }
            }

            return fitness;
        }

        // Calculava a distância manhattan do estado
        //public double Evaluate(IChromosome chromosome)
        //{
        //    var valor = ((PermutationChromosome)chromosome).Value;

        //    ushort[,] estado = Utils.ToArrayBidimensional(valor);

        //    int distance = 0;
        //    for (int i = 0; i < estado.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < estado.GetLength(1); j++)
        //        {
        //            int valorAtual = estado[i, j];
        //            if (valorAtual != 0)
        //            {
        //                var posicao = EncontrarValor(Utils.ToArrayBidimensional(EstadoObjetivo), valorAtual);
        //                distance += Math.Abs(i - posicao.Linha) + Math.Abs(j - posicao.Coluna);
        //            }
        //        }
        //    }

        //    return distance;
        //}

        //private Posicao EncontrarValor(ushort[,] estado, int valor)
        //{
        //    for (int i = 0; i < estado.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < estado.GetLength(1); j++)
        //        {
        //            if (estado[i, j] == valor)
        //            {
        //                return new Posicao(i, j);
        //            }
        //        }
        //    }
        //    return null;
        //}        

    }
}
