using Xunit;
using Hangman.Utilities;

namespace Hangman.Tests
{
    public class MiscTests
    {
        [Fact]
        public void CheckForGameWinTest()
        {
            //Arrange
            char[] positiveInput = { 'u', 'n', 'i', 't', 'y' };
            char[] negativeInput = { 'u', '_', 'i', 't', 'y' };
            bool positiveTest;
            bool negativeTest;

            //Act
            positiveTest = Misc.CheckForGameWin(positiveInput);
            negativeTest = Misc.CheckForGameWin(negativeInput);

            //Assert
            Assert.True(positiveTest);
            Assert.False(negativeTest);

            //Program.UserGuessLetter();
        }
    }
}