using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

public class GameTests {

    [Fact]
    public void Take_turn_switches_player() {
        Given_players();

        When_starting_game();
        When_taking_turn();

        Then_current_player_is_SECOND_player();

        When_taking_ANOTHER_turn();

        Then_current_player_is_FIRST_player();
    }

    [Fact]
    public void FIRST_player_turn() {
        Given_players();

        When_starting_game();
        When_taking_turn();

        Then_board_space_is_owned_by_FIRST_player();
    }
    
    [Fact]
    public void SECOND_player_turn() {
        Given_players();
        Given_current_player_is_SECOND_player();

        When_taking_turn();

        Then_board_space_is_owned_by_SECOND_player();
    }

    IEnumerable<IPlayer> players;
    Game game;


    void Given_players() {
        IPlayer createPlayer() {
            var mock = new Mock<IPlayer>();
            mock.SetupGet(x => x.Token).Returns(Mock.Of<IToken>());

            return mock.Object;
        }

        players = new IPlayer[] {
            createPlayer(),
            createPlayer(),
        };
    }

    void Given_current_player_is_SECOND_player() {
        game = new Game(players);
        game.CurrentPlayer = players.Last();
    }

    void When_starting_game() {
        game = new Game(players);
    }

    void When_taking_turn() {
        game.TakeTurn(1, 1);
    }
    
    void When_taking_ANOTHER_turn() {
        game.TakeTurn(2, 1);
    }
    
    void Then_current_player_is_SECOND_player() {
        Assert.Equal(players.Last(), game.CurrentPlayer);
    }
    void Then_current_player_is_FIRST_player() {
        Assert.Equal(players.First(), game.CurrentPlayer);
    }

    void Then_board_space_is_owned_by_FIRST_player() {
        Assert.Equal(players.First().Token, game.Board[1, 1].Token);
    }
    
    void Then_board_space_is_owned_by_SECOND_player() {
        Assert.Equal(players.Last().Token, game.Board[1, 1].Token);
    }
}