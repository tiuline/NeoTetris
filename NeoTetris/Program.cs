using System;

namespace NeoTetris
{
    class Program
    {
        static StructBloco nextBlock = new StructBloco();


        static void Main(string[] args)
        {

            bool processoIniciado = true;

            Console.WriteLine("Iniciando processo!");
            while (processoIniciado)
            {
                Console.WriteLine("Processo Iniciado");

                Thread.Sleep(1000);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                }
            }
        }

        private static void MostrarProximoBloco()
        {
            nextBlock = Blocos.Generate(); // get next block

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PlayWindow.width + PlayWindow.left + 4, 8);
            Console.Write("Next");
            Console.SetCursorPosition(PlayWindow.width + PlayWindow.left + 2, 9);
            Console.Write("¤¤¤¤¤¤¤¤");

            for (int i = 1; i <= 6; i++)
            {
                Console.SetCursorPosition(PlayWindow.width + PlayWindow.left + 2, i + 9);
                Console.Write("¤      ¤");
            }

            Console.SetCursorPosition(PlayWindow.width + PlayWindow.left + 2, 15);
            Console.Write("¤¤¤¤¤¤¤¤");
            Console.ResetColor();

            Blocos.Preview(new Point(PlayWindow.width + PlayWindow.left + 6, 12), nextBlock);
        }
    }
}