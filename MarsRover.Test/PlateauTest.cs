using MarsRover.Core;
using Xunit;

namespace MarsRover.Test
{
    public class PlateauTest
    {
        [Theory]
        [InlineData(new object[] { "5 5", 5, 5})]
        [InlineData(new object[] { "10 10", 10, 10})]
        public void GeneratePlateau(string size, int expectedWidth, int expectedHeight)
        {
            var plateau = new Plateau();
            plateau.Initialize(size);
            
            Assert.NotNull(plateau);
            Assert.NotNull(plateau.Size);
            Assert.Equal(plateau.CheckInit,true);
            Assert.Equal(plateau.Size.Width, expectedWidth);
            Assert.Equal(plateau.Size.Height, expectedHeight);
        }
    }
}