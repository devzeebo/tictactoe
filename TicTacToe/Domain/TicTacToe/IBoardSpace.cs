public interface IBoardSpace
{
    IToken? Token { get; }

    void PlaceToken(IToken token);
    void Reset();
}