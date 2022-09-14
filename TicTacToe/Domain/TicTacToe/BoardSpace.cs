public class BoardSpace : IBoardSpace
{
    public IToken? Token { get; internal set; }

    public BoardSpace() {}

    public void PlaceToken(IToken token)
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}