using ConnectFourSpin;

Player player1;
Player player2;
Game game;


Console.WriteLine("Welcome to Connect Four Spin - CLI Edition!");
Console.WriteLine("Enter number of players, or type X to exit");
string input = Console.ReadLine();
char mode = Convert.ToChar(input);
if(mode == 'X')
{
    Console.WriteLine("Ending game, goodbye!");
}
else
{
    Console.WriteLine("Player one, please enter your name: ");
    string name = Console.ReadLine();
    player1 = new HumanPlayer('O', false, name);

    if (mode == '1')
    {
        player2 = new BotPlayer('X', false);
        game = new Game(player1, player2);
        game.StartGame();

    }
    else
    {
        Console.WriteLine("Player two, please enter your name: ");
        name = Console.ReadLine();
        player2 = new HumanPlayer('X', false, name);
        game = new Game(player1, player2);
        game.StartGame();
    }

}



