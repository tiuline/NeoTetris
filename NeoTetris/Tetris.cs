using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoTetris
{
    internal class Tetris : ClasseBase
    {
        public void Preview(Ponteiro pt, StructBloco structBlock)
        {
            Blocos bloco = new Blocos();
            WindowRect wrBlockAdj = new WindowRect();
            bool[] arrData = bloco.SelecionaProximoBloco(structBlock);

            bloco.Ajustes(ref wrBlockAdj, arrData);

            Console.ForegroundColor = ConsoleColor.White;
            for (int linha = wrBlockAdj.topo; linha < wrBlockAdj.topo + wrBlockAdj.altura; linha++)
                for (int coluna = wrBlockAdj.esquerda; coluna < wrBlockAdj.esquerda + wrBlockAdj.largura; coluna++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        Console.SetCursorPosition(pt.x + coluna - wrBlockAdj.esquerda - wrBlockAdj.largura / 2,
                                                  pt.y + linha - wrBlockAdj.topo - wrBlockAdj.altura / 2);
                        Console.Write("#");
                    }
            Console.ResetColor();
        }
    }
}
