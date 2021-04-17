using AForge.Genetic;
using TestConsole.Models.GA;
using System;

namespace TestConsole.Models
{
    public class PuzzleSolver
    {
        public int N { get; set; } = 3;

        public void Resolver()
        {
            int numeroMaximoIteracoes = 10000;

            // Estados
            ushort[] estadoInicial = new ushort[] { 1, 5, 3, 4, 2, 6, 7, 8, 0 };
            ushort[] estadoObjetivo = new ushort[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            int tamanhoPopulacao = 100;            

            var chromosome = new Chromosome(estadoInicial);
            var fitnessFuncao = new Fitness(estadoObjetivo);
            var selecao = new RouletteWheelSelection();

            Population population = new Population(tamanhoPopulacao, chromosome, fitnessFuncao, selecao);

            int contadorNumeroIteracoes = 0;
            while (true)
            {
                population.RunEpoch();

                var melhorEstado = ((PermutationChromosome)population.BestChromosome).Value;

                if (EhObjetivoFinal(Utils.ToArrayBidimensional(melhorEstado), Utils.ToArrayBidimensional(estadoObjetivo)))
                {
                    Console.WriteLine("Encontrei o estado objetivo...");

                    string resultado = "ESTADO OBJETIVO ENCONTRADO PELO GA --> [ ";
                    for (int i = 0; i < melhorEstado.Length; i++)
                    {
                        resultado += melhorEstado[i] + " ";
                    }

                    resultado += "]";

                    Console.WriteLine(resultado);
                    Console.WriteLine($"Número de iterações necessárias = [{contadorNumeroIteracoes}]");

                    break;
                }

                contadorNumeroIteracoes++;

                if (contadorNumeroIteracoes > numeroMaximoIteracoes)
                {
                    Console.WriteLine("Com o número máximo de iterações não encontrei o objetivo...");

                    break;
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
