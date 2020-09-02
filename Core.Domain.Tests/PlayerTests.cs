using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Core.Domain.Tests
{
    public class PlayerTests
    {

        [Fact]
        void Given_Player_To_String_Should_Include_Number_And_Name()
        {
            // Arrange
            var player = new Player {Name = "Agnes", PlayerNumber = 50};

            // Act
            var playerAsString = player.ToString();

            // Assert
            Assert.Equal("Agnes-50", playerAsString);
        }

    }
}
