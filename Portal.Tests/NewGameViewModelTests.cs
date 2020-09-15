using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Portal.Models;
using Xunit;

namespace Portal.Tests
{
    public class NewGameViewModelTests
    {
        [Fact]
        public void Opponent_Required_Should_Be_Checked()
        {
            // Arrange
            var validationResults = new List<ValidationResult>();

            // Act
            var sut = new NewGameViewModel();
            var ctx = new ValidationContext(sut, null, null);
            Validator.TryValidateObject(sut, ctx, validationResults, true);

            // Assert
            Assert.Single(validationResults);
            Assert.Contains(validationResults, validationResult =>
                validationResult.MemberNames.Contains("Opponent") && validationResult.ErrorMessage.Contains("required"));
        }

    }
}