using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ToyRobotPuzzle
{
    public class Robot
    {
        public int x { get; set; }
        public int y { get; set; }
        public string? f { get; set; }
        public int row {  get; set; }
        private bool isConfirmed;

        List<Position> robot;
        Command _command = new Command();

        public Robot()
        {
            robot = new List<Position>();
            row = 7;
        }

        public void DrawRobot()
        {
            var robotChar = string.Empty;

            if(robot.Count > 0 )
            {
                foreach (Position pos in robot)
                {
                    Console.SetCursorPosition(pos.x, pos.y);

                    switch (pos.f)
                    {
                        case "NORTH":
                            robotChar = "N";
                            break;
                        case "SOUTH":
                            robotChar = "S";
                            break;
                        case "EAST":
                            robotChar = "E";
                            break;
                        case "WEST":
                            robotChar = "W";
                            break;
                    }

                    Console.Write(robotChar);
                    Console.SetCursorPosition(0, row);
                    Console.WriteLine("");
                }

                row++;
            }
        }

        public void PlaceRobot(string command)
        {
            if (!IsValid(command)) return;

            _command.GetCommandValues(command);

            x = _command.X;
            y = _command.Y;
            f = _command.F;

            switch (_command.CommandValue)
            {
                case "PLACE":
                    if(command == "PLACE")
                    {
                        isConfirmed = true;
                    }
                    else
                    {
                        robot.Add(new Position(x + 1, Math.Abs(y - 5), f));

                        if(robot.Count > 1)
                        {
                            Console.SetCursorPosition(robot[0].x, robot[0].y);
                            Console.Write(" ");
                            robot.RemoveAt(0);
                        }

                        Console.WriteLine("PLACE command with directions are valid. Input PLACE only to confirm");
                        row++;
                    }
                    break;
                case "MOVE":
                    if (!isConfirmed) return;
                    if (_command.IsMoveValid(robot[0].x, robot[0].y, robot[0].f))
                    {
                        Console.SetCursorPosition(robot[0].x, robot[0].y);
                        Console.Write(" ");

                        switch (robot[0].f)
                        {
                            case "SOUTH":
                                robot[0].y++;
                                break;
                            case "NORTH":
                                robot[0].y--;
                                break;
                            case "EAST":
                                robot[0].x++;
                                break;
                            case "WEST":
                                robot[0].x--;
                                break;
                        }

                        robot.Add(new Position(robot[0].x, Math.Abs(robot[0].y), robot[0].f));
                        robot.RemoveAt(0);
                    }
                    else
                    {
                        Console.WriteLine("Out of bounds");
                        row++;
                    }
                    break;
                case "LEFT":
                    if (!isConfirmed) return;
                    Console.SetCursorPosition(robot[0].x, robot[0].y);
                    Console.Write(" ");

                    switch (robot[0].f)
                    {
                        case "SOUTH":
                            robot[0].f = "EAST";
                            break;
                        case "NORTH":
                            robot[0].f = "WEST";
                            break;
                        case "EAST":
                            robot[0].f = "NORTH";
                            break;
                        case "WEST":
                            robot[0].f = "SOUTH";
                            break;
                    }

                    robot.Add(new Position(robot[0].x, Math.Abs(robot[0].y), robot[0].f));
                    robot.RemoveAt(0);
                    break;
                case "RIGHT":
                    if (!isConfirmed) return;
                    Console.SetCursorPosition(robot[0].x, robot[0].y);
                    Console.Write(" ");

                    switch (robot[0].f)
                    {
                        case "SOUTH":
                            robot[0].f = "WEST";
                            break;
                        case "NORTH":
                            robot[0].f = "EAST";
                            break;
                        case "EAST":
                            robot[0].f = "SOUTH";
                            break;
                        case "WEST":
                            robot[0].f = "NORTH";
                            break;
                    }

                    robot.Add(new Position(robot[0].x, Math.Abs(robot[0].y), robot[0].f));
                    robot.RemoveAt(0);
                    break;
                case "REPORT":
                    if (!isConfirmed) return;
                    Console.WriteLine(Math.Abs(robot[0].x - 1)  + ", " + Math.Abs(robot[0].y - 5) + " " + robot[0].f);
                    row++;
                    break;
            }
        }

        private bool IsValid(string command)
        {
            if (command == "PLACE" && robot.Count == 0)
            {
                row++;
                return false;
            }

            if (!_command.IsCommandValid(command))
            {
                row++;
                return false;
            }

            if (!command.Contains("PLACE") && robot.Count == 0)
            {
                row++;
                return false;
            }

            if (command.Contains("PLACE") && isConfirmed)
            {
                row++;
                return false;
            }

            return true;
        }
    }
}
