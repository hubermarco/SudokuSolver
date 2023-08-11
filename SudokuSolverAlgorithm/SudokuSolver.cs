namespace SudokuSolverAlgorithm
{
    public class SudokuSolver
    {
        public bool SolveSudoku(char [][] board, out int numberOfTrials)
        {
            int index = 0;

            var sudokuBoard = new SudokuBoard(board);

            var sudokuSolved = SolveSudoku(sudokuBoard, index);

            numberOfTrials = sudokuBoard.GetNumberOfTrials();

            return sudokuSolved;
        }

        private bool SolveSudoku(SudokuBoard sudokuBoard, int index)
        {
            var numberSum = 0;

            while (AreThereNewPartialSolutionSteps(numberSum))
            {
                var nextNumber = CalculateNextNumber(index++);
                sudokuBoard.SelectNewPartialSolutionStep(nextNumber);
                numberSum += nextNumber;
               
                if (sudokuBoard.IsBoardValid())
                {
                    nextNumber = CalculateNextNumber(index++);
                    sudokuBoard.ExtendSolutionByOneStep(nextNumber);

                    if (!sudokuBoard.IsSolutionComplete())
                        if (SolveSudoku(sudokuBoard, index))
                            return true;
                        else
                            sudokuBoard.SetBackLastStep();
                    else
                        return true;
                }
            }
            return false;
        }

        private static int CalculateNextNumber(int index) => index % 9 + 1; 

        private static bool AreThereNewPartialSolutionSteps(int numberSum) => numberSum < 45;
    }
}
