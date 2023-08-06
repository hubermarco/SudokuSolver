

namespace SudokuSolverAlgorithm
{
    public class SudokuBoard : List<List<char>>
    {
        private IList<Tuple<int, int>> _stack = new List<Tuple<int, int>>();

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

        public void SelectNewPartialSolutionStep(int nextNumber)
        {
            GetRowAndColumnIndexOfNextFreeElement(out var rowIndex, out var columnIndex);

            this[rowIndex][columnIndex] =  (char)nextNumber;

            _stack.Add(new Tuple<int,int>(rowIndex, columnIndex));
        }

        public bool IsBoardValid()
        { 
            var areAllRowsValid = Enumerable.Range(0, 9).All( 
                row => Enumerable.Range(1, 9).All(value => this[row].Count(x => x == value + 48) <= 1));

            //var areAllColumnsValid = Enumerable.Range(0, 9).All(
            //    column => Enumerable.Range(1, 9).All(value => this[column][column].Count(x => x == value + 48) <= 1));

            return areAllRowsValid;
        }



        private void GetRowAndColumnIndexOfNextFreeElement(out int rowIndex, out int columnIndex)
        {
            rowIndex = -1;
            columnIndex = -1;
            for (; rowIndex < Count; rowIndex++)
            {
                columnIndex = this[rowIndex].FindIndex(element => element.Equals('.'));

                if (columnIndex > -1)
                    return;
            }
        }
    }
}
