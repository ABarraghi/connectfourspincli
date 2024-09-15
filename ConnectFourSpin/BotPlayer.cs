using System;
namespace ConnectFourSpin
{
	public class BotPlayer : Player 
	{
		public BotPlayer()
		{
		}

		public BotPlayer(char token, bool hasWon, string name = "Bot") : base(token,hasWon, name) { }

        public override int[] makeMove(Grid grid, int rowIdx, int colIdx)
        {
			int up = rowIdx - 1;
			int down = rowIdx + 1;
			int left = colIdx - 1;
			int right = colIdx + 1;

			if(up >= 0)
			{
				if(right < Grid.COLS)
				{
					if(grid.getRingAt(up,right) == '*')
					{
						grid.setRingAt(up, right, token);
						return new int[] {up,right};
					}
				}
				if(left >= 0)
				{
                    if (grid.getRingAt(up, left) == '*')
                    {
                        grid.setRingAt(up, left, token);
                        return new int[] { up, left };
                    }
                }
                if (grid.getRingAt(up, colIdx) == '*')
                {
                    grid.setRingAt(up, colIdx, token);
                    return new int[] { up, colIdx };
                }
            }
            if (down < Grid.ROWS)
            {
                if (right < Grid.COLS)
                {
                    if (grid.getRingAt(down, right) == '*')
                    {
                        grid.setRingAt(down, right, token);
                        return new int[] { down, right };
                    }
                }
                if (left >= 0)
                {
                    if (grid.getRingAt(down, left) == '*')
                    {
                        grid.setRingAt(down, left, token);
                        return new int[] { down, left };
                    }
                }
                if (grid.getRingAt(down, colIdx) == '*')
                {
                    grid.setRingAt(down, colIdx, token);
                    return new int[] { down, colIdx };
                }
            }

            return new int[] {-1,-1};
        }
    }
}

