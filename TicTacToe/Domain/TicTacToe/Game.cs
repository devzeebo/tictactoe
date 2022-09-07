public class Game : IGame
{
    public IEnumerable<IPlayer> Players { get; protected internal set; }
    public IPlayer CurrentPlayer { get; protected internal set; }
    public IBoardSpace Board { get; protected internal set; }
    public GameState GameState { get; private set; }

    public Game(
        IEnumerable<IPlayer> players
    ) {
        Players = players;
        CurrentPlayer = players.First();

        GameState = GameState.Active;
    }

    public void Render(TextWriter stream)
    {
        throw new NotImplementedException();
    }

    public void TakeTurn(int r, int c)
    {
        if (CurrentPlayer == Players.First()) {
            CurrentPlayer = Players.Last();
        }
        else {
            CurrentPlayer = Players.First();
        }
    }
}