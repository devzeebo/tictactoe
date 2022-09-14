using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

public class BoardSpaceTests
{
    [Fact]
    void NEW_board_space_is_EMPTY()
    {
        Given_NEW_board_space();

        Then_NO_token_is_on_board_space();
    }

    [Fact]
    public void Placing_token_on_EMPTY_board_space()
    {
        Given_NEW_board_space();

        When_placing_token();

        Then_token_is_on_board_space();
    }

    [Fact]
    public void Placing_token_on_FILLED_board_space()
    {
        Given_FILLED_board_space();

        this.ExpectError(When_placing_token);

        Then_illegal_move_error();
    }
    
    [Fact]
    public void Resetting_clears_token()
    {
        Given_FILLED_board_space();

        When_resetting_board_space();

        Then_NO_token_is_on_board_space();
    }
    
    [Fact]
    public void Resetting_EMPTY_board_space()
    {
        Given_NEW_board_space();

        When_resetting_board_space();

        Then_NO_token_is_on_board_space();
    }

    BoardSpace board_space;

    Exception error;

    void Given_NEW_board_space()
    {
        board_space = new BoardSpace();
    }
    
    void Given_FILLED_board_space()
    {
        var token = new Mock<IToken>();
        token.SetupGet(x => x.Symbol).Returns("F");

        board_space = new BoardSpace();
        board_space.Token = token.Object;
    }

    void When_placing_token()
    {
        var token = new Mock<IToken>();
        token.SetupGet(x => x.Symbol).Returns("T");

        board_space.PlaceToken(token.Object);
    }

    void When_resetting_board_space()
    {
        board_space.Reset();
    }

    void Then_NO_token_is_on_board_space()
    {
        Assert.Null(board_space.Token);
    }

    void Then_token_is_on_board_space()
    {
        Assert.Equal("T", board_space.Token?.Symbol);
    }

    void Then_illegal_move_error()
    {
        Assert.IsAssignableFrom<IllegalMoveException>(error);
    }
}