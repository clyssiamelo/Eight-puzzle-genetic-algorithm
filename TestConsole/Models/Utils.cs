using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole.Models
{
    public class Utils
    {
        public static ushort[,] ToArrayBidimensional(ushort[] estado)
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
