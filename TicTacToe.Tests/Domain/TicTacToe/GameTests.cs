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

        When_taking_turn();

        Then_current_player_is_FIRST_player();
    }

    IEnumerable<IPlayer> players;
    Game game;


    void Given_players() {
        players = new IPlayer[] {
            Mock.Of<IPlayer>(),
            Mock.Of<IPlayer>(),
        };
    }

    void When_starting_game() {
        game = new Game(players);
    }

    void When_taking_turn() {
        game.TakeTurn(1, 1);
    }
    
    void Then_current_player_is_SECOND_player() {
        Assert.Equal(players.Last(), game.CurrentPlayer);
    }
    void Then_current_player_is_FIRST_player() {
        Assert.Equal(players.First(), game.CurrentPlayer);
    }
}