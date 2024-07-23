namespace ToyRobotPuzzle
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public string f { get; set; }

        public Position(int x, int y, string f)
        {
            this.x = x;
            this.y = y;
            this.f = f;
        }
    }
}
