public class BoardSpace : IBoardSpace
{
    public IToken? Token { get; internal set; }

    public BoardSpace() {}

    public void PlaceToken(IToken token)
    {
        if (Token != null) {
            throw new IllegalMoveException();
        }

        Token = token;
    }

    public void Reset()
    {
        Token = null;
    }
}