public interface IGame {
    List<IPlayer> Players { get; protected set; }
    IPlayer CurrentPlayer { get; protected set; }
    IBoardSpace Board { get; protected set; }

    GameState GameState { get; protected set; }

    void TakeTurn(int r, int c);
    void Render(TextWriter stream);
}