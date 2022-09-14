public class Game : IGame
{
    public IEnumerable<IPlayer> Players { get; protected internal set; }
    public IPlayer CurrentPlayer { get; protected internal set; }
    public IBoardSpace[,] Board { get; protected internal set; }
    public GameState GameState { get; private set; }

    public Game(
        IEnumerable<IPlayer> players
    ) {
        Players = players;
        CurrentPlayer = players.First();

        GameState = GameState.Active;

        Board = new BoardSpace[3,3];
        for (int r = 0; r < 3; r++) {
            for (int c = 0; c < 3; c++) {
                Board[r, c] = new BoardSpace();
            }
        }
    }

    public void Render(TextWriter stream)
    {
        throw new NotImplementedException();
    }

    public void TakeTurn(int r, int c)
    {
        Board[r,c].PlaceToken(CurrentPlayer.Token);

        if (CurrentPlayer == Players.First()) {
            CurrentPlayer = Players.Last();
        }
        else {
            CurrentPlayer = Players.First();
        }
    }
}