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

        public Ponteiro Location
        {
            get { return new Ponteiro(m_blockpos.x, m_blockpos.y); }
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
        }

        public StructBloco Gerar()
        {
            Random rnd = new Random();
            return new StructBloco((Enums.Rotacao)rnd.Next(0, Enum.GetNames(typeof(Enums.Rotacao)).Length), (Enums.TipoBloco)rnd.Next(0, Enum.GetNames(typeof(Enums.TipoBloco)).Length));
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
            bool[] arrData = new bool[TAMANHO_BLOCO << 2];

            switch (StructBloco.tipoBloco)
            {
                case Enums.TipoBloco.bloco01:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0) || StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[2] = true;  
                        arrData[6] = true;  
                        arrData[10] = true; 
                        arrData[14] = true; 
                    }
                    else
                    {
                        arrData[12] = true; 
                        arrData[13] = true; 
                        arrData[14] = true; 
                        arrData[15] = true; 
                    }
                    break;
                case Enums.TipoBloco.bloco02:
                    arrData[0] = true; 
                    arrData[1] = true; 
                    arrData[4] = true; 
                    arrData[5] = true; 
                    break;
                case Enums.TipoBloco.bloco03:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0) || StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[5] = true; 
                        arrData[6] = true; 
                        arrData[8] = true; 
                        arrData[9] = true; 
                    }
                    else
                    {
                        arrData[1] = true;  
                        arrData[5] = true;  
                        arrData[6] = true;  
                        arrData[10] = true; 
                    }
                    break;
                case Enums.TipoBloco.bloco04:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0) || StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[4] = true;  
                        arrData[5] = true;  
                        arrData[9] = true;  
                        arrData[10] = true; 
                    }
                    else
                    {
                        arrData[2] = true; 
                        arrData[5] = true; 
                        arrData[6] = true; 
                        arrData[9] = true; 
                    }
                    break;
                case Enums.TipoBloco.bloco05:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0))
                    {
                        arrData[4] = true;
                        arrData[5] = true;
                        arrData[6] = true;
                        arrData[9] = true;
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r90))
                    {
                        arrData[1] = true; 
                        arrData[4] = true; 
                        arrData[5] = true; 
                        arrData[9] = true; 
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[5] = true;  
                        arrData[8] = true;  
                        arrData[9] = true;  
                        arrData[10] = true; 
                    }
                    else
                    {
                        arrData[1] = true;
                        arrData[5] = true;
                        arrData[6] = true;
                        arrData[9] = true;
                    }
                    break;
                case Enums.TipoBloco.bloco06:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0))
                    {
                        arrData[4] = true; 
                        arrData[5] = true; 
                        arrData[6] = true; 
                        arrData[8] = true; 
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r90))
                    {
                        arrData[0] = true; 
                        arrData[1] = true; 
                        arrData[5] = true; 
                        arrData[9] = true; 
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[6] = true; 
                        arrData[8] = true; 
                        arrData[9] = true; 
                        arrData[10] = true;
                    }
                    else
                    {
                        arrData[1] = true; 
                        arrData[5] = true; 
                        arrData[9] = true; 
                        arrData[10] = true;
                    }
                    break;
                case Enums.TipoBloco.bloco07:
                    if (StructBloco.angulo.Equals(Enums.Rotacao.r0))
                    {
                        arrData[4] = true; 
                        arrData[5] = true; 
                        arrData[6] = true; 
                        arrData[10] = true;
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r90))
                    {
                        arrData[1] = true; 
                        arrData[5] = true; 
                        arrData[8] = true; 
                        arrData[9] = true; 
                    }
                    else if (StructBloco.angulo.Equals(Enums.Rotacao.r180))
                    {
                        arrData[4] = true; 
                        arrData[8] = true; 
                        arrData[9] = true; 
                        arrData[10] = true;
                    }
                    else
                    {
                        arrData[1] = true; 
                        arrData[2] = true; 
                        arrData[5] = true; 
                        arrData[9] = true; 
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
            wrBlock = new WindowRect();

            int coluna;
            int linha;
            bool estaAjustado;

            estaAjustado = true;
            for (coluna = 0; coluna < TAMANHO_BLOCO; coluna++)
            {
                for (linha = 0; linha < TAMANHO_BLOCO; linha++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        estaAjustado = false;
                        break;
                    }

                if (estaAjustado)
                    wrBlock.esquerda++;
                else
                    break;
            }
            
            estaAjustado = true;
            for (linha = 0; linha < TAMANHO_BLOCO; linha++)
            {
                for (coluna = 0; coluna < TAMANHO_BLOCO; coluna++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        estaAjustado = false;
                        break;
                    }

                if (estaAjustado)
                    wrBlock.topo++;
                else
                    break;
            }
            
            estaAjustado = true;
            for (coluna = TAMANHO_BLOCO - 1; coluna >= 0; coluna--)
            {
                for (linha = 0; linha < TAMANHO_BLOCO; linha++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        estaAjustado = false;
                        break;
                    }

                if (estaAjustado)
                    wrBlock.largura++;
                else
                    break;
            }

            wrBlock.largura = TAMANHO_BLOCO - (wrBlock.esquerda + wrBlock.largura);
            
            estaAjustado = true;
            for (linha = TAMANHO_BLOCO - 1; linha >= 0; linha--)
            {
                for (coluna = 0; coluna < TAMANHO_BLOCO; coluna++)
                    if (arrData[coluna + linha * TAMANHO_BLOCO])
                    {
                        estaAjustado = false;
                        break;
                    }

                if (estaAjustado)
                    wrBlock.altura++;
                else
                    break;
            }

            wrBlock.altura = TAMANHO_BLOCO - (wrBlock.topo + wrBlock.altura);
        }
    }
}
