using System;
using LoggingKata;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.Equal(34.073638, actual.Location.Latitude);
            Assert.Equal(-84.677017, actual.Location.Longitude);
            Assert.Equal("Taco Bell Acwort...", actual.Name.Trim());

        }

        [Theory]
        [InlineData("4.073638, -84.677017, Taco Bell Acwort...", 4.073638)]
        [InlineData("31.216447, -85.361015, Taco Bell Dotha...", 31.216447)]
        public void LatitudeTest(string str, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(str).Location.Latitude;
            
            //Assert
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("4.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("31.216447, -85.361015, Taco Bell Dotha...", -85.361015)]
        public void LongitudeTest(string str, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(str).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("string, string, string")]
        public void ShouldFailParse(string str)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(str);

            //Assert
            Assert.Null(actual);
        }
    }
}
