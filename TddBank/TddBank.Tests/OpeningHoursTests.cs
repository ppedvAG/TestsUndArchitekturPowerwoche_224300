using Microsoft.QualityTools.Testing.Fakes;

namespace TddBank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2023, 2, 06, 10, 30, true)]//mo
        [InlineData(2023, 2, 06, 10, 29, false)]//mo
        [InlineData(2023, 2, 06, 10, 31, true)] //mo
        [InlineData(2023, 2, 06, 18, 59, true)] //mo
        [InlineData(2023, 2, 06, 19, 00, false)] //mo
        [InlineData(2023, 2, 11, 13, 0, true)] //sa
        [InlineData(2023, 2, 11, 16, 0, false)] //sa
        [InlineData(2023, 2, 12, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();


            Assert.Equal(result, oh.IsOpen(dt));
        }

        [Fact]
        public void IsNowOpen()
        {
            var oh = new OpeningHours();
            oh.IsNowOpen();
        }

        [Fact]
        public void IsWeekend()
        {
            using (ShimsContext.Create())
            {
                var oh = new OpeningHours();

                System.IO.Fakes.ShimStreamReader.ConstructorString = (sr, path) => { };
                System.IO.Fakes.ShimStreamReader.AllInstances.ReadToEnd = sr => "___";

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 2, 6); //Mo
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 2, 7); //Di
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 2, 8); //Mi
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 2, 9); //Do
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 2, 10); //Fr
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 2, 11); //Sa
                Assert.True(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 2, 12); //So
                Assert.True(oh.IsWeekend());
            }
        }
    }
}
