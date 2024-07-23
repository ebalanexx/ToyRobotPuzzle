namespace ToyRobotPuzzle
{
    public class Table
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Table()
        {
            Width = 6;
            Height = 6;

            Console.CursorVisible = false;
        }

        public void CreateTable()
        {
            Console.Clear();

            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }

            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.Write("-");
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("-");
            }

            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.Write("-");
            }
        }
    }
}
