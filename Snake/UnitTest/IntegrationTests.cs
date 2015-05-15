using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Snake;

namespace UnitTest
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Snake_Moves_1_Step_Right()
        {

            string before = @"
                +++++++++
                +       +
                +  @@*  +
                +       +
                +++++++++";

            string expected = @"
                +++++++++
                +       +
                +   @@* +
                +       +
                +++++++++";

            IGame game;
            IBoard board = BuildBoardFromString(before);
            ISnake snake = BuildSnakeFromString(before);
            snake.Direction = Direction.Right;

            game.Start(board, snake);
            game.Step();

            Assert.That(board.ToString(), Is.EqualTo(expected));
        }

        private IBoard BuildBoardFromString(string sBoard)
        {
            IBoard result;
            var lines = sBoard.Split('\n');
            var height = lines.Length;
            var width = lines.Max(x => x.Length);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    result[i, j] = CellTypeFromChar(lines[j][i]);
                }
            }
        }

        private Dictionary<char, CellType> cellTypeConverterDictionary_ = new Dictionary<char, CellType>()
        {
            {'+', CellType.Wall},
            {'@', CellType.Snake},
            {'*', CellType.SnakeHead},
            {'F', CellType.Food}
        };

        private CellType CellTypeFromChar(char ch)
        {
            CellType result = CellType.Empty;
            cellTypeConverterDictionary_.TryGetValue(ch, out result);
            return result;
        }

        private ISnake BuildSnakeFromString(string sBoard)
        {

        }

    }

}
