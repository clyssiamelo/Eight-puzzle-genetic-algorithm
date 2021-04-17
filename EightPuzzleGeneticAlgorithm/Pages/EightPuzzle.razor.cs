using EightPuzzleGeneticAlgorithm.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EightPuzzleGeneticAlgorithm.Pages
{
    public partial class EightPuzzle
    {
        private List<MarkupString> NosMarkupStr = new List<MarkupString>();
        public int TamanhoPopulacao { get; set; } = 10;
        private int? NumeroMaximoIteracoes { get; set; } = 1000;
        public double ChanceCrossover { get; set; } = 0.75;
        public double ChanceMutacao { get; set; } = 0.1;
        private void AlterarPara3por3() => Dimensao = 3;

        private bool EncontrouSolucao { get; set; }

        private bool GerandoSolucao { get; set; }

        public int Dimensao { get; set; } = 3;

        private int DimensaoSelecionada = 1;

        private string Mensagem { get; set; }
        public bool MostrarMensagem { get; set; }

        public ushort[] EstadoInicial { get; set; }
        public ushort[] EstadoFinal { get; set; }

        #region 3 x 3 inicial

        [Parameter]
        public ushort tres00Inicial { get; set; } = 1;
        [Parameter]
        public ushort tres01Inicial { get; set; } = 2;
        [Parameter]
        public ushort tres02Inicial { get; set; } = 3;

        [Parameter]
        public ushort tres10Inicial { get; set; } = 0;
        [Parameter]
        public ushort tres11Inicial { get; set; } = 4;
        [Parameter]
        public ushort tres12Inicial { get; set; } = 6;

        [Parameter]
        public ushort tres20Inicial { get; set; } = 7;
        [Parameter]
        public ushort tres21Inicial { get; set; } = 5;
        [Parameter]
        public ushort tres22Inicial { get; set; } = 8;

        #endregion

        #region 3 x 3 final

        [Parameter]
        public ushort tres00Final { get; set; } = 1;
        [Parameter]
        public ushort tres01Final { get; set; } = 2;
        [Parameter]
        public ushort tres02Final { get; set; } = 3;

        [Parameter]
        public ushort tres10Final { get; set; } = 4;
        [Parameter]
        public ushort tres11Final { get; set; } = 5;
        [Parameter]
        public ushort tres12Final { get; set; } = 6;

        [Parameter]
        public ushort tres20Final { get; set; } = 7;
        [Parameter]
        public ushort tres21Final { get; set; } = 8;
        [Parameter]
        public ushort tres22Final { get; set; } = 0;

        #endregion


        public void Resolver()
        {
            NosMarkupStr.Clear();

            int numeroMaximoIteracoes = NumeroMaximoIteracoes.HasValue ? NumeroMaximoIteracoes.Value : int.MaxValue;

            // Pegar valores iniciais
            PegarValoresFormulario(true);

            // Pegar valores finais
            PegarValoresFormulario(false);

            int repeticoes = default(int);
            var validarCampo = new ValidaCampos();

            bool existeRepeticoesEstadoInicial = validarCampo.ExistemRepeticoes(Utils.ToArrayBidimensional((ushort[])EstadoInicial.Clone()), out repeticoes);

            if (existeRepeticoesEstadoInicial)
            {
                MostrarMensagemErro("Foram encontradas " + repeticoes + " posições repetidas no estado inicial, preencha corretamente para resolver o puzzle");
                return;
            }

            bool existeRepeticoesEstadoFinal = validarCampo.ExistemRepeticoes(Utils.ToArrayBidimensional((ushort[])EstadoFinal.Clone()), out repeticoes);
            if (existeRepeticoesEstadoFinal)
            {
                MostrarMensagemErro("Foram encontradas " + repeticoes + " posições repetidas no estado final, preencha corretamente para resolver o puzzle");
                return;
            }

            //bool ehResolvivel = new VerificaParidade().IsSolvable(EstadoInicial, EstadoFinal);

            //if (!ehResolvivel)
            //{
            //    MostrarMensagemErro("O conjunto de estados informados não é resolvível");
            //    return;
            //}
            //else
            //{
            //    EsconderMensagem();
            //}

            bool encontrouSolucao = false;

            GerandoSolucao = true;

            // No ultimoNoConhecido = new _8Puzzle.Models.Solver(EstadoInicial, EstadoFinal, numeroIteracoes).Solve(out encontrouSolucao);
            int numeroiteracoes;
            ushort[] estadoEncontrado;

            encontrouSolucao = new PuzzleSolver().Resolver(NumeroMaximoIteracoes.Value, EstadoInicial, EstadoFinal, TamanhoPopulacao, ChanceCrossover, ChanceMutacao, out numeroiteracoes, out estadoEncontrado);

            if (encontrouSolucao == true)
            {
                EncontrouSolucao = encontrouSolucao;
                PrintarArray(estadoEncontrado, numeroiteracoes);
                EsconderMensagem();
            }

            //TODO: Verificar se os estado são possíveis, também verificar se não existe valor repetido
            //TODO: Arrumar view para carregar os valores
        }

        private void PrintarArray(ushort[] estado, int numeroIteracoes)
        {
            string resultado = "";
            resultado += $"<div class='row'>";
            resultado += $"<div class='col-md-2'>";
            resultado += "<label> Número de iterações feitas</label>";
            resultado += @$"<input type='number' disabled class='form-control text-center' value='{numeroIteracoes}'/>";
            resultado += "</div>";
            resultado += "</div>";
            resultado += $"<div class='row mt-3'>";
            resultado += $"<div class='col-md-2'>";
            resultado += $"<div class='grid-resultado w-h-180'>";



            for (int i = 0; i < estado.Length; i++)
            {
                resultado += @$"<input type='number' disabled class='input-w-h-60 text-center' value='{estado[i]}'/>";
            }

            resultado += "</div>";
            resultado += "</div>";
            resultado += "</div>";

            MarkupString resultString = (MarkupString)resultado;
            NosMarkupStr.Add(resultString);

            resultado = "";
        }


        private void PegarValoresFormulario(bool ehEstadoInicial)
        {
            if (Dimensao == 3)
            {
                if (ehEstadoInicial)
                {
                    EstadoInicial = new ushort[]
{ tres00Inicial, tres01Inicial, tres02Inicial, tres10Inicial, tres11Inicial, tres12Inicial, tres20Inicial, tres21Inicial, tres22Inicial};
                }
                else
                {
                    EstadoFinal = new ushort[]

{ tres00Final, tres01Final, tres02Final, tres10Final, tres11Final, tres12Final, tres20Final, tres21Final, tres22Final};
                }
                return;
            }
        }
        private void EsconderMensagem() => MostrarMensagem = false;

        private void MostrarMensagemErro(string mensagem)
        {
            Mensagem = mensagem;
            MostrarMensagem = true;
        }
    }
}

