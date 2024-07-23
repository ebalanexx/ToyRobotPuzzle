namespace ToyRobotPuzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            Table table = new Table();
            Robot robot = new Robot();

            table.CreateTable();
            Console.WriteLine();

            while (!finished)
            {
                Console.Write("Command: ");
                var command = Console.ReadLine();

                if (command != null)
                    robot.PlaceRobot(command);
                    
                robot.DrawRobot();
            }

            Console.ReadLine();
        }
    }
}
