using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToyRobotPuzzle
{
    public class Command
    {
        public string[]? CommandInputs { get; set; }
        public string? CommandValue { get; set; }
        public string[]? PositionInputs {  get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string F { get; set; }

        public void GetCommandValues(string command)
        {
            CommandInputs = command.Split(' ');
            CommandValue = CommandInputs[0];

            if(CommandInputs.Length > 1 )
            {
                PositionInputs = CommandInputs[1].Split(',');
                X = Convert.ToInt32(PositionInputs[0]);
                Y = Convert.ToInt32(PositionInputs[1]);
                F = PositionInputs[2];
            }
        }

        public bool IsCommandValid(string command)
        {

            if(command.Contains("PLACE"))
            {
                if (command.Trim() == "PLACE") return true;

                string pattern = @"^PLACE\s+(\d+),(\d+),([A-Z]+)$";
                Match match = Regex.Match(command, pattern);

                if (match.Success)
                {
                    int x, y;
                    string f = match.Groups[3].Value;

                    if (int.TryParse(match.Groups[1].Value, out x) && int.TryParse(match.Groups[2].Value, out y) && !string.IsNullOrEmpty(f))
                    {
                        return true;
                    }
                }
            }
            else
            {
                switch (command)
                {
                    case "MOVE":
                    case "LEFT":
                    case "RIGHT":
                    case "REPORT":
                        return true;
                }
            }

            return false;
        }

        public bool IsMoveValid(int x, int y, string f)
        {
            switch (f)
            {
                case "SOUTH":
                    if (y == 5) return false;
                    break;
                case "NORTH":
                    if (y == 1) return false;
                    break;
                case "EAST":
                    if (x == 5) return false;
                    break;
                case "WEST":
                    if (x == 1) return false;
                    break;
            }

            return true;
        }
    }
}
