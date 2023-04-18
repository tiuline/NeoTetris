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
    public ConsoleColor color;
    public Boolean isBlock;

    public StructBlocoEstilo(ConsoleColor newColor, Boolean newIsBlock)
    {
        this.color = newColor;
        this.isBlock = newIsBlock;
    }
}

struct WindowRect
{
    public int left;
    public int top;
    public int width;
    public int height;

    public WindowRect(int newLeft, int newTop, int newWidth, int newHeight)
    {
        this.left = newLeft;
        this.top = newTop;
        this.width = newWidth;
        this.height = newHeight;
    }
}

struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
