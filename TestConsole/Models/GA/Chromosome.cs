using AForge.Genetic;
using System;
using System.Linq;

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

                contadorMovimentos++;
            }

            ushort[] novoEstadoGerado = Utils.ToArray(novoEstado);

            return new Chromosome(novoEstadoGerado);
        }

        public override void Crossover(IChromosome pair)
        {
            var p = (Chromosome)pair;

            var valorPai = p.val;
            var valorMae = this.val;

            var filho1 = IniciarArray(valorPai.Length);
            var filho2 = IniciarArray(valorPai.Length);

            for (int i = 0; i < valorPai.Length; i++)
            {
                if (i <= 4)
                {
                    filho1[i] = valorMae[i];
                    filho2[i] = valorPai[i];
                }
                else
                    break;
            }

            for (int i = 5; i < valorPai.Length; i++)
            {
                ushort valorEncontrado = PegarUmValorQueNaoEstejaInserido(valorPai, filho1);
                filho1[i] = valorEncontrado;
            }

            for (int i = 5; i < valorMae.Length; i++)
            {
                ushort valorEncontrado = PegarUmValorQueNaoEstejaInserido(valorMae, filho2);
                filho2[i] = valorEncontrado;
            }

            p.val = filho1;
            this.val = filho2;
        }

        private ushort PegarUmValorQueNaoEstejaInserido(ushort[] primeiro, ushort[] segundo)
        {
            for (int i = 0; i < primeiro.Length; i++)
            {
                bool existe = segundo.Any(val => val == primeiro[i]);
                if (!existe)
                    return primeiro[i];
            }

            return 0;
        }

        private ushort[] IniciarArray(int length)
        {
            ushort[] arr = new ushort[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = ushort.MaxValue;
            }

            return arr;
        }
    }

}