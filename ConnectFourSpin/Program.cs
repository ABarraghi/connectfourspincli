//Flips a column for a Connect Four Spin game
//column of size 8
//* indicates empty
//X indicates player 1
//O indicates player 2
//ex. * * * X O * * * -> * * * O X * * *
static char[] flipCol(char[] colToFlip)
{
    Array.Reverse(colToFlip);
    return colToFlip;
}

char[,] board = {
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', 'X', 'X', ' ', ' ', ' '},
            {' ', ' ', 'O', 'O', ' ', ' ', ' '},
            {' ', 'O', 'X', 'X', ' ', ' ', ' '},
            {'O', 'X', 'X', 'X', 'O', ' ', ' '}
};

ConnectFourChecker checker = new ConnectFourChecker(board);

// Check for a win at each position
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 7; j++)
    {
        if (board[i, j] != ' ')
        {
            if (checker.CheckForWin(i, j, board[i, j]))
            {
                Console.WriteLine($"Player {board[i, j]} wins starting at position ({i}, {j})!");
                return;
            }
        }
    }
}

Console.WriteLine("No winner found.");


public class ConnectFourChecker
{
    private readonly char[,] board;
    private readonly int m, n;
    private const int WIN_LENGTH = 4;

    public ConnectFourChecker(char[,] board)
    {
        this.board = board;
        m = board.GetLength(0);
        n = board.GetLength(1);
    }

    public bool CheckForWin(int row, int col, char player)
    {
        return CheckDirection(row, col, 1, 0, player) || // Horizontal
               CheckDirection(row, col, 0, 1, player) || // Vertical
               CheckDirection(row, col, 1, 1, player) || // Diagonal (top-left to bottom-right)
               CheckDirection(row, col, 1, -1, player);  // Diagonal (top-right to bottom-left)
    }

    private bool CheckDirection(int row, int col, int rowDir, int colDir, char player, int count = 0)
    {
        if (count == WIN_LENGTH)
            return true;

        if (row < 0 || row >= m || col < 0 || col >= n || board[row, col] != player)
            return false;

        return CheckDirection(row + rowDir, col + colDir, rowDir, colDir, player, count + 1);
    }
}
    



