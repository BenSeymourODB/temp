using NUnit.Framework;
using temp;

namespace temp.UnitTests
{
    public class TempTests
    {
        [TestCase("file_20080121.txt", "01/21/2008")]
        [TestCase("file_19940617.txt", "06/17/1994")]
        [TestCase("file_00010101.txt", "01/01/0001")]
        [TestCase("file_99991231.txt", "12/31/9999")]
        public void GetDateTimeFromFileName_GivenUnderscoreDateFileName_ReturnsDateTime(
            string fileName,
            string usFormattedDate)
        {
            DateTime expected = DateTime.Parse(usFormattedDate);
            DateTime actual = DateTimeMethods.GetDateTimeFromFileName(fileName);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("20080121.txt")]
        [TestCase("file.txt")]
        [TestCase("file_012122.txt")]
        public void GetDateTimeFromFileName_GivenInvalidFileName_ReturnsYesterday(
            string fileName)
        {
            DateTime expected = DateTime.Today.AddDays(-1);
            DateTime actual = DateTimeMethods.GetDateTimeFromFileName(fileName);
            Assert.AreEqual(expected, actual);
        }
    }
}