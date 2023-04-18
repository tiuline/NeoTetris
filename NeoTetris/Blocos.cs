
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NeoTetris.Enums;

namespace NeoTetris
{
    class Blocos : ClasseBase
    {
        public Enums.Rotacao Angulo
        {
            get { return m_block.angulo; }
            set { m_block.angulo = value; }
        }

        public Enums.TipoBloco TipoBloco
        {
            get { return m_block.tipoBloco; }
            set { m_block.tipoBloco = value; }
        }

        public Point Location
        {
            get { return new Point(m_blockpos.x, m_blockpos.y); }
            set { m_blockpos = value; }
        }

        public int Size
        {
            get { return TAMANHO_BLOCO; }
        }

        public ConsoleColor Cores(Enums.TipoBloco typBlock)
        {
            switch (typBlock)
            {
                case Enums.TipoBloco.bloco01:
                    return ConsoleColor.Red;
                case Enums.TipoBloco.bloco02:
                    return ConsoleColor.Blue;
                case Enums.TipoBloco.bloco03:
                    return ConsoleColor.Cyan;
                case Enums.TipoBloco.bloco04:
                    return ConsoleColor.Yellow;
                case Enums.TipoBloco.bloco05:
                    return ConsoleColor.Green;
                case Enums.TipoBloco.bloco06:
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.DarkCyan;
            }
            // as cores ficam com o nome em ingles por ser coisa do System
        }

        public StructBloco Gerar()
        {
            Random rnd = new Random();

            // pick random pieces
            return new StructBloco((Enums.Rotacao)rnd.Next(0, Enum.GetNames(typeof(Enums.Rotacao)).Length),
                                   (Enums.TipoBloco)rnd.Next(0, Enum.GetNames(typeof(Enums.TipoBloco)).Length));
        }

        public WindowRect Rotate(Rotacao novoAngulo)
        {
            WindowRect wrBlock = new WindowRect();

            Angulo = novoAngulo;
            Construir();
            Ajustes(ref wrBlock);

            return wrBlock;
        }

        public void Construir()
        {
            arrBlock = SelecionaProximoBloco(new StructBloco(Angulo, TipoBloco));
        }

        public Boolean[] SelecionaProximoBloco(StructBloco StructBloco)
        {
            // data for 4v4 block shapes
            bool[] arrData = new bool[TAMANHO_BLOCO << 2];

            switch (StructBloco.tipoBloco)
            {
                case Enums.TipoBloco.bloco01:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0) ||
                       StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[2] = true;  // ..#. 0123
                        arrData[6] = true;  // ..#. 4567
                        arrData[10] = true; // ..#. 8901
                        arrData[14] = true; // ..#. 2345
                    }
                    else
                    {
                        arrData[12] = true; // .... 0123
                        arrData[13] = true; // .... 4567
                        arrData[14] = true; // .... 8901
                        arrData[15] = true; // #### 2345
                    }

                    break;
                case Enums.TipoBloco.bloco02:
                    arrData[0] = true; // ##.. 0123
                    arrData[1] = true; // ##.. 4567
                    arrData[4] = true; // .... 8901
                    arrData[5] = true; // .... 2345
                    break;
                case Enums.TipoBloco.bloco03:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0) ||
                       StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[5] = true; // .... 0123
                        arrData[6] = true; // .##. 4567
                        arrData[8] = true; // ##.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    else
                    {
                        arrData[1] = true;  // .#.. 0123
                        arrData[5] = true;  // .##. 4567
                        arrData[6] = true;  // ..#. 8901
                        arrData[10] = true; // .... 2345
                    }
                    break;
                case Enums.TipoBloco.bloco04:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0) ||
                       StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[4] = true;  // .... 0123
                        arrData[5] = true;  // ##.. 4567
                        arrData[9] = true;  // .##. 8901
                        arrData[10] = true; // .... 2345
                    }
                    else
                    {
                        arrData[2] = true; // ..#. 0123
                        arrData[5] = true; // .##. 4567
                        arrData[6] = true; // .#.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    break;
                case Enums.TipoBloco.bloco05:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0))
                    {
                        arrData[4] = true; // .... 0123
                        arrData[5] = true; // ###. 4567
                        arrData[6] = true; // .#.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r90))
                    {
                        arrData[1] = true; // .#.. 0123
                        arrData[4] = true; // ##.. 4567
                        arrData[5] = true; // .#.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[5] = true;  // .... 0123
                        arrData[8] = true;  // .#.. 4567
                        arrData[9] = true;  // ###. 8901
                        arrData[10] = true; // .... 2345
                    }
                    else
                    {
                        arrData[1] = true; // .#.. 0123
                        arrData[5] = true; // .##. 4567
                        arrData[6] = true; // .#.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    break;
                case Enums.TipoBloco.bloco06:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0))
                    {
                        arrData[4] = true; // .... 0123
                        arrData[5] = true; // ###. 4567
                        arrData[6] = true; // #... 8901
                        arrData[8] = true; // .... 2345
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r90))
                    {
                        arrData[0] = true; // ##.. 0123
                        arrData[1] = true; // .#.. 4567
                        arrData[5] = true; // .#.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[6] = true; // .... 0123
                        arrData[8] = true; // ..#. 4567
                        arrData[9] = true; // ###. 8901
                        arrData[10] = true; // .... 2345
                    }
                    else
                    {
                        arrData[1] = true; // .#.. 0123
                        arrData[5] = true; // .#.. 4567
                        arrData[9] = true; // .##. 8901
                        arrData[10] = true; // .... 2345
                    }
                    break;
                case Enums.TipoBloco.bloco07:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0))
                    {
                        arrData[4] = true; // .... 0123
                        arrData[5] = true; // ###. 4567
                        arrData[6] = true; // ..#. 8901
                        arrData[10] = true; // .... 2345
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r90))
                    {
                        arrData[1] = true; // .#.. 0123
                        arrData[5] = true; // .#.. 4567
                        arrData[8] = true; // ##.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[4] = true; // .... 0123
                        arrData[8] = true; // #... 4567
                        arrData[9] = true; // ###. 8901
                        arrData[10] = true; // .... 2345
                    }
                    else
                    {
                        arrData[1] = true; // .##. 0123
                        arrData[2] = true; // .#.. 4567
                        arrData[5] = true; // .#.. 8901
                        arrData[9] = true; // .... 2345
                    }
                    break;
            }

            return arrData;
        }

        public void Ajustes(ref WindowRect wrBlock)
        {
            Ajustes(ref wrBlock, arrBlock);
        }

        public void Ajustes(ref WindowRect wrBlock, bool[] arrData)
        {
            //  This function returns the exact measurement of the block. 

            wrBlock = new WindowRect();

            int coluna;
            int linha;
            bool isAdj;

            //  Check empty colums from the left-side of the block, and if found, 
            // increase the left margin.
            isAdj = true;
            for (coluna = 0; coluna < TAMANHO_BLOCO; coluna++)
            {
                for (linha = 0; linha < TAMANHO_BLOCO; linha++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        isAdj = false;
                        break;
                    }

                if (isAdj)
                    // left margin
                    wrBlock.left++;
                else
                    break;
            }
            // end left Ajustes

            //  Check empty rows from the top-side of the block, and if found, 
            // increse the top margin. 
            isAdj = true;
            for (linha = 0; linha < TAMANHO_BLOCO; linha++)
            {
                for (coluna = 0; coluna < TAMANHO_BLOCO; coluna++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        isAdj = false;
                        break;
                    }

                if (isAdj)
                    wrBlock.top++;
                else
                    break;
            }
            // end top Ajustes

            //  Check empty columns from the right-side of the block, and if found, 
            // increase the right margin.
            isAdj = true;
            for (coluna = TAMANHO_BLOCO - 1; coluna >= 0; coluna--)
            {
                for (linha = 0; linha < TAMANHO_BLOCO; linha++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        isAdj = false;
                        break;
                    }

                if (isAdj)
                    wrBlock.width++;
                else
                    break;
            }

            // get the exact width of the block
            wrBlock.width = TAMANHO_BLOCO - (wrBlock.left + wrBlock.width);
            // end right Ajustes

            //  Check empty rows from the bottom-side of the block, and if found, 
            // increase the bottom.
            isAdj = true;
            for (linha = TAMANHO_BLOCO - 1; linha >= 0; linha--)
            {
                for (coluna = 0; coluna < TAMANHO_BLOCO; coluna++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        isAdj = false;
                        break;
                    }

                if (isAdj)
                    // bottom margin
                    wrBlock.height++;
                else
                    break;
            }

            // get the exact height of the block.
            wrBlock.height = TAMANHO_BLOCO - (wrBlock.top + wrBlock.height);
            // end top Ajustes;
        }
    }
}
