using System;

/*
boolean FindeLoesung(int index, Lsg loesung, ...)
{
    // index = Schrittzahl
    // loesung = Referenz auf Teillösung
    while (es gibt noch neue Teil-Lösungsschritte) {
    Wähle einen neuen Teil-Lösungsschritt schritt; // Heuristik
    if (schritt ist gültig) {
        Erweitere loesung um schritt;
        if (loesung noch nicht vollständig) {
            // rekursiver Aufruf von FindeLoesung
            if (FindeLoesung(index + 1, loesung, ...))
            {
                return true; // Lösung gefunden
            }
            else
            { // wir sind in einer Sackgasse
                Mache schritt rückgängig; // Backtracking
            }
        } else return true; // Lösung gefunden -> fertig
    }
}
return false;
} // Bei true als Rückgabewert steht die Lösung in loesung
*/
namespace SudokuSolverAlgorithm
{
    public class SudokuSolver
    {
        public bool SolveSudoku(char [][] board)
        {
            int index = 0;

            var sudokuBoard = new SudokuBoard(board);

            return SolveSudoku(sudokuBoard, index);
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

                    if (sudokuBoard.IsSolutionComplete())
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

        private static int CalculateNextNumber(int index)
        {
            return index % 9 + 1; ;
        }

        private static bool AreThereNewPartialSolutionSteps(int numberSum)
        {
            return numberSum < 45;
        }
    }
}
