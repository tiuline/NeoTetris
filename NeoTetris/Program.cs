using System;

namespace NeoTetris
{
    class Program
    {
        static StructBloco nextBlock = new StructBloco();
        static WindowRect PlayWindow = new WindowRect(); 

        static void Main(string[] args)
        {
            bool processoIniciado = true;

            while (processoIniciado)
            {
                Thread.Sleep(1500);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                }
                MostrarBloco();
            }
        }

        private static void MostrarBloco()
        {
            Blocos bloco = new Blocos();
            Tetris game = new Tetris();
            nextBlock = bloco.Gerar();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PlayWindow.largura+ PlayWindow.esquerda + 2,0);
            Console.Write("Impulso");
            Console.SetCursorPosition(PlayWindow.largura+ PlayWindow.esquerda + 2, 1);
            Console.Write("¤¤¤¤¤¤¤¤");

            for (int i = 1; i <= 6; i++)
            {
                Console.SetCursorPosition(PlayWindow.largura+ PlayWindow.esquerda + 2, i + 1);
                Console.Write("¤      ¤");
            }

            Console.SetCursorPosition(PlayWindow.largura+ PlayWindow.esquerda + 2, 7);
            Console.Write("¤¤¤¤¤¤¤¤");
            Console.ResetColor();

            game.Preview(new Ponteiro(PlayWindow.largura+ PlayWindow.esquerda + 6, 4), nextBlock);
        }
    }
}