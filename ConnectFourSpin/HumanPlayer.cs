using System;
namespace ConnectFourSpin
{
	public class HumanPlayer : Player
	{

		public HumanPlayer()
		{
		}

		public HumanPlayer(char token, bool hasWon, string name) : base(token, hasWon, name)
		{
		}

        public override int[] makeMove(Grid grid, int rowIdx, int colIdx)
        {

			if(grid.getRingAt(rowIdx,colIdx) == '*'){
                grid.setRingAt(rowIdx, colIdx, token);
				return new int[] {rowIdx,colIdx};
            }

			return new int[] {-1,-1};
        }

    }
}

