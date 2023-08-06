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
        public void When_there_are_new_partial_solution_steps_available_then_true_is_returned()
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

            Assert.IsTrue(sudokuBoard.AreThereNewPartialSolutionSteps());
        }

        [Test]
        public void When_there_are_no_new_partial_solution_steps_available_then_false_is_returned()
        {
            var board = new char[][]
            {
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'},
                new char[] {'5','3','4','5','7','3','6','7','9'}
            };

            var sudokuBoard = new SudokuBoard(board);

            Assert.IsFalse(sudokuBoard.AreThereNewPartialSolutionSteps());
        }

    }
}
