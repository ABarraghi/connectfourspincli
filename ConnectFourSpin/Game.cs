using System;
namespace ConnectFourSpin
{
	public class Game
	{
        private Player player1;
        private Player player2;

		static int curPlayerIdx = 0;
		static Grid board = new Grid();
        static readonly int WIN_LENGTH = 4;

        private int curCol;
        private int curRow;

        private int[] p1Move;
        private int[] p2Move;

        private Random flipChance = new Random();


        public Game(Player player1, Player player2)
		{
            this.player1 = player1;
            this.player2 = player2;

		}

		public void StartGame()
		{
            board.printGrid();

            while (!(player1.getWinState() || player2.getWinState()))
            {
                if (curPlayerIdx == 0)
                {
                    Console.WriteLine(player1.getName() + "'s turn. Type your move:");
                    string move = Console.ReadLine();
                    curRow = move[0] - '0';
                    curCol = move[2] - '0';
                    p1Move = player1.makeMove(board, curRow, curCol);

                    Console.WriteLine(player1.getName() + " moved at (" + p1Move[0] + "," + p1Move[1] + ")");
                    board.printGrid();

                    if(flipChance.NextDouble() > 0.5)
                    {
                        board.flipCol(curCol);
                        curRow = 7 - curRow;
                        Console.WriteLine("Board Flipped!");
                        board.printGrid();
                        player2.setWinState(CheckForWin(curRow, curCol, player2.getToken()));

                    }

                    player1.setWinState(CheckForWin(curRow, curCol, player1.getToken()));
                }
                else
                {
                    if (player2.GetType() == typeof(HumanPlayer))
                    {
                        Console.WriteLine(player2.getName() + "'s turn. Type your move:");
                        string move = Console.ReadLine();
                        curRow = move[0] - '0';
                        curCol = move[2] - '0';

                    }

                    p2Move = player2.makeMove(board, curRow, curCol);

                    Console.WriteLine(player2.getName() + " moved at (" + p2Move[0] + "," + p2Move[1] + ")");
                    board.printGrid();

                    if (flipChance.NextDouble() > 0.5)
                    {
                        board.flipCol(p2Move[1]);
                        curRow = 7 - p2Move[0];
                        Console.WriteLine("Board Flipped!");
                        board.printGrid();
                        player1.setWinState(CheckForWin(curRow, curCol, player1.getToken()));

                    }

                    player2.setWinState(CheckForWin(curRow, curCol, player2.getToken()));
                }

                switchPlayers();
            }

            if (player1.getWinState())
            {
                Console.WriteLine(player1.getName() + " is victorious!");
            }

            if (player2.getWinState())
            {
                Console.WriteLine(player2.getName() + " is victorious!");
            }


		}

        public bool CheckForWin(int row, int col, char token)
        {
            return CheckDirection(row, col, 1, 0, token) || // Horizontal
                   CheckDirection(row, col, 0, 1, token) || // Vertical
                   CheckDirection(row, col, 1, 1, token) || // Diagonal (top-left to bottom-right)
                   CheckDirection(row, col, 1, -1, token);  // Diagonal (top-right to bottom-left)
        }

        private bool CheckDirection(int row, int col, int rowDir, int colDir, char token, int count = 0)
        {
            if (count == WIN_LENGTH)
                return true;

            if (row < 0 || row >= Grid.ROWS || col < 0 || col >= Grid.COLS || board.getRingAt(row, col) != token)
                return false;

            return CheckDirection(row + rowDir, col + colDir, rowDir, colDir, token, count + 1);
        }

        void switchPlayers()
        {
            curPlayerIdx = (curPlayerIdx + 1) % 2;
        }
 






    }
}

