using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

// TARGET - SKELETON
// v1
// - Step()
// - Turn(direction)
// - Reset
// Components
// Engine
// Model
// --> Snake
// --> Board
namespace Snake
{
    public enum Direction
    {
        Left, Right, Top, Bottom
    }

    public enum StepResult
    {
        SnakeDied, Survived, LevelComplete
    }

    public enum CellType
    {
        Wall, Empty, Food, Snake, SnakeHead
    }

    public interface ISnake
    {
        Direction Direction { get; set; }
        StepResult Step();
        void Add(Point point);
    }

    public interface IBoard
    {
        void Build(int width, int height);
        CellType this[int i, int j] { get; set; }
        void AddFood();
    }

    public interface IGame
    {
        StepResult Step();
        void KeyPress(ConsoleKey key);
        void Start(IBoard board, ISnake snake);
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
