using NUnit.Framework;
using SudokuSolverAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverAlgorithmTests
{
    [TestFixture]
    public class SudokuBoardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_board_is_valid_then_true_is_returned()
        {
            var board = new char[][]
            {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };

            var sudokuBoard = new SudokuBoard(board);

            Assert.IsTrue(sudokuBoard.IsBoardValid());
        }

        [Test]
        public void When_there_are_no_new_partial_solution_steps_available_then_false_is_returned()
        {
            var board = new char[][]
            {
               new char[] {'5','3','4','6','7','8','9','1','2'},
               new char[] {'6','7','2','1','9','5','3','4','8'},
               new char[] {'1','9','8','3','4','2','5','6','7'},
               new char[] {'8','5','9','7','6','1','4','2','3'},
               new char[] {'4','2','6','8','5','3','7','9','1'},
               new char[] {'7','1','3','9','2','4','8','5','6'},
               new char[] {'9','6','1','5','3','7','2','8','4'},
               new char[] {'2','8','7','4','1','9','6','3','5'},
               new char[] {'3','4','5','2','8','6','1','7','9'}
            };

            var sudokuBoard = new SudokuBoard(board);

            Assert.IsTrue(sudokuBoard.IsSolutionComplete());
        }

        [Test]
        public void When_board_is_checked_to_be_valid_then_correponding_result_is_returned()
        {
            var board = new char[][]
            {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };

            var sudokuBoard = new SudokuBoard(board);

            Assert.IsTrue(sudokuBoard.IsBoardValid(), "IsBoardValid");
        }
    }
}
