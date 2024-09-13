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

char[] col = { '*', 'X', 'O' };
Console.WriteLine(flipCol(col)); // Expecting 'O', 'X', '*'

