public interface IGame {
    IEnumerable<IPlayer> Players { get; }
    IPlayer CurrentPlayer { get; }
    IBoardSpace[,] Board { get; }

    GameState GameState { get; }

    void TakeTurn(int r, int c);
    void Render(TextWriter stream);
}