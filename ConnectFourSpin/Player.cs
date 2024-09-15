namespace ConnectFourSpin
{
	public abstract class Player
	{

		protected char token;
		protected bool hasWon;
		protected string name;

		public Player()
		{

		}
		public Player(char token, bool hasWon, string name)
		{
			this.token = token;
			this.hasWon = hasWon;
			this.name = name;
		}

		public char getToken()
		{
			return token;
		}

		public bool getWinState()
		{
			return hasWon;
		}

        public string getName()
        {
            return name;
        }

        public void setWinState(bool hasWon)
		{
			this.hasWon = hasWon;
		}

		public abstract int[] makeMove(Grid grid, int rowIdx, int colIdx);

	}
}

