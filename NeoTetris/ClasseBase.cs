namespace NeoTetris
{
    class ClasseBase
    {
            protected static int TAMANHO_BLOCO = 4; 

            protected static bool[] arrBlock = new bool[TAMANHO_BLOCO << 2];
            protected static WindowRect TetrisField = new WindowRect();
            protected static Ponteiro m_blockpos = new Ponteiro();
            protected static StructBloco m_block = new StructBloco();
            protected static StructBlocoEstilo[] arrField;
    }
}
