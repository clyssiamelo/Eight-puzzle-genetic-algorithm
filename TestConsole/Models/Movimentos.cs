namespace TestConsole.Models
{
    public static class Movimentos
    {

        public static bool GerarPossibilidadeCima(ushort[,] estado, Posicao espacoVazio, out ushort[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha - 1, espacoVazio.Coluna);
            if (PosicaoValida(paraCima, estado.GetLength(0)))
            {
                ushort[,] novoEstado = (ushort[,])estado.Clone();

                ushort valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        public static bool GerarPossibilidadeDireita(ushort[,] estado, Posicao espacoVazio, out ushort[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha, espacoVazio.Coluna + 1);
            if (PosicaoValida(paraCima, estado.GetLength(0)))
            {
                ushort[,] novoEstado = (ushort[,])estado.Clone();

                ushort valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        public static bool GerarPossibilidadeBaixo(ushort[,] estado, Posicao espacoVazio, out ushort[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha + 1, espacoVazio.Coluna);
            if (PosicaoValida(paraCima, estado.GetLength(0)))
            {
                ushort[,] novoEstado = (ushort[,])estado.Clone();

                ushort valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        public static bool GerarPossibilidadeEsquerda(ushort[,] estado, Posicao espacoVazio, out ushort[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha, espacoVazio.Coluna - 1);
            if (PosicaoValida(paraCima, estado.GetLength(0)))
            {
                ushort[,] novoEstado = (ushort[,])estado.Clone();

                ushort valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        public static Posicao EncontrarEspacoVazio(ushort[,] estado)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    int valorPosicao = estado[i, j];

                    if (valorPosicao == 0)
                    {
                        return new Posicao(i, j);
                    }
                }
            }

            return null;
        }

        private static bool PosicaoValida(Posicao posicao, int maxLineRow)
        {
            bool colunaValida = posicao.Coluna >= 0 && posicao.Coluna < maxLineRow;
            bool linhaValida = posicao.Linha >= 0 && posicao.Linha < maxLineRow;

            return colunaValida && linhaValida;
        }
    }
}
