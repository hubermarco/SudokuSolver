

namespace SudokuSolverAlgorithm
{
    public class SudokuBoard : List<List<char>>
    {
        public SudokuBoard(char[][] board)
        {
            foreach (var row in board)
                Add(row.ToList());
        }

        public bool AreThereNewPartialSolutionSteps()
        {
            var areThereNewPartialSolutionSteps = this.Any(row => row.Any(element => element == '.'));
            return areThereNewPartialSolutionSteps;
        }

        public void SelectNewPartialSolutionStep()
        {

        }
    }
}
