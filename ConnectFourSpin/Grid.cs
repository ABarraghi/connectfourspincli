namespace ConnectFourSpin
{
	public class Grid
	{
		public static readonly int ROWS = 8;
		public static readonly int COLS = 5;

		static private char[,] board = new char[ROWS, COLS];

		public Grid()
		{
			for(int i = 0; i < ROWS; i++)
			{
				for(int j = 0; j < COLS; j++)
				{
					board[i, j] = '*';
				}
			}
		}

		public char[] getRow(int rowIdx)
		{
			char[] row = new char[COLS];
			for(int i = 0; i < row.Length; i++)
			{
				row[i] = board[rowIdx, i];
			}
			return row;
		}

		public char[] getCol(int colIdx)
		{
            char[] col = new char[ROWS];
            for (int i = 0; i < col.Length; i++)
            {
                col[i] = board[i, colIdx];
            }
            return col;
        }

		public char getRingAt(int rowIdx, int colIdx)
		{
			return board[rowIdx, colIdx];
		}

		public void setRow(int rowIdx, char[] row)
		{
            for (int i = 0; i < row.Length; i++)
            {
                board[rowIdx, i] = row[i];
            }
        }

        public void setCol(int colIdx, char[] col)
        {
            for (int i = 0; i < col.Length; i++)
            {
                board[i, colIdx] = col[i];
            }
        }

		public void setRingAt(int rowIdx, int colIdx, char val)
		{
			board[rowIdx, colIdx] = val;
		}

        //Flips a column for a Connect Four Spin game
        //column of size 8
        //* indicates empty
        //X indicates player 1
        //O indicates player 2
        //ex. * * * X O * * * -> * * * O X * * *
        public void flipCol(int colIdx)
        {
			char[] col = getCol(colIdx);
            Array.Reverse(col);
            setCol(colIdx,col);
        }

		public void printGrid()
		{
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}

