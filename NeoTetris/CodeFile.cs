using NeoTetris;
using static NeoTetris.Enums;

struct StructBloco
{
    public Enums.Rotacao angulo;
    public Enums.TipoBloco tipoBloco;

    public StructBloco(Rotacao novoAngulo, TipoBloco novoTipo)
    {
        this.angulo = novoAngulo;
        this.tipoBloco = novoTipo;
    }
}

struct StructBlocoEstilo
{
    public ConsoleColor cor;
    public Boolean bloco;

    public StructBlocoEstilo(ConsoleColor novaCor, Boolean novoBloco)
    {
        this.cor = novaCor;
        this.bloco = novoBloco;
    }
}

struct WindowRect
{
    public int esquerda;
    public int topo;
    public int largura;
    public int altura;

    public WindowRect(int novaEsquerda, int novoTopo, int novaLargura, int novaAltura)
    {
        this.esquerda = novaEsquerda;
        this.topo = novoTopo;
        this.largura = novaLargura;
        this.altura = novaAltura;
    }
}

struct Ponteiro
{
    public int x;
    public int y;

    public Ponteiro(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
