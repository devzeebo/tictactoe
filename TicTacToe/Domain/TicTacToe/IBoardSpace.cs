public interface IBoardSpace
{
    IToken Token { get; }

    void placeToken(IToken token);
    void Reset();
}