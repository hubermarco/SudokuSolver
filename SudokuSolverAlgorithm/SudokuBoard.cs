

using System.Data.Common;
using System.Linq;

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

        public bool IsSolutionComplete()
        {
            var isSolutionComplete = IsBoardComplelyFilled() && IsBoardValid();
            return isSolutionComplete;
        }

        public void ExtendSolutionByOneStep(int nextNumber)
        {
            GetRowAndColumnIndexOfNextFreeElement(out var rowIndex, out var columnIndex);
            
            if((rowIndex != -1) && (columnIndex != -1))
            {
                this[rowIndex][columnIndex] = (char)(nextNumber + 48);
                _stack.Add(new Tuple<int, int>(rowIndex, columnIndex));
            }
        }

        public void SelectNewPartialSolutionStep(int nextNumber)
        {
            if (_stack.Count == 0)
            {
                ExtendSolutionByOneStep(nextNumber);
            }
            else
            {
                var lastCoordinates = _stack.Last();
                this[lastCoordinates.Item1][lastCoordinates.Item2] = (char)(nextNumber + 48);
            }
        }

        public bool IsBoardValid()
        { 
            bool AreAllRowsValid() => Enumerable.Range(0, 9).All(
                row => Enumerable.Range(1, 9).All(value => this[row].Count(x => x == value + 48) <= 1));

            bool AreAllColumnsValid()
            {
                var transposedBoard = Enumerable.Range(0, 9).Select(column => Enumerable.Range(0, 9).Select(row => this[row][column]).ToArray()).ToArray();
                var areAllColumnsValid = Enumerable.Range(0, 9).All(
                    row => Enumerable.Range(1, 9).All(value => transposedBoard[row].Count(x => x == value + 48) <= 1));
                return areAllColumnsValid;
            }
            
            bool AreAllSegmentsValid()
            {
                var indexMatrix = new List<List<int>> { new List<int> { 0, 1, 2, 9, 10, 11, 18, 19, 20 } };

                for (var rowIndex = 1; rowIndex < 9; rowIndex++)
                {
                    var offset = (rowIndex % 3 == 0) ? 21 : 3;
                    indexMatrix.Add(indexMatrix[rowIndex - 1].Select(x => x + offset).ToList());
                }

                var areAllSegmentsValid =
                    indexMatrix.All(row => Enumerable.Range(1, 9).All(value => row.Select(x => this[(x / 9)][x % 9]).Count(x => x == value + 48) <= 1));

                return areAllSegmentsValid;
            }

            return AreAllRowsValid() && AreAllColumnsValid() && AreAllSegmentsValid();
        }

        public void SetBackLastStep()
        {
            var lastCoordinates = _stack.Last();
            this[lastCoordinates.Item1][lastCoordinates.Item2] = '.';

            _stack.Remove(lastCoordinates);
        }

        private void GetRowAndColumnIndexOfNextFreeElement(out int rowIndex, out int columnIndex)
        {
            rowIndex = 0;
            columnIndex = -1;
            for (; rowIndex < Count; rowIndex++)
        {
                columnIndex = this[rowIndex].FindIndex(element => element.Equals('.'));

                if (columnIndex > -1)
                    return;
            }
        }

        private bool IsBoardComplelyFilled()
        {
            var isBoardComplelyFilled = !this.Any(row => row.Any(element => element == '.'));
            return isBoardComplelyFilled;
        }
    }
}
