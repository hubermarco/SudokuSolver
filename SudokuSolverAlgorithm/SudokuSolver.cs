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
            var sudokuBoard = new SudokuBoard(board);

            while(sudokuBoard.AreThereNewPartialSolutionSteps())
            {

            }

            return true;
        }
    }
}
