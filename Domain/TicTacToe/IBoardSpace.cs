public interface IBoardSpace
{
    IToken Token { get; protected set; }

    void placeToken(IToken token);
    void Reset();
}