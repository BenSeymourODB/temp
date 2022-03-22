using System.Globalization;

namespace temp
{
    public static class DateTimeMethods
    {
        /// <summary>
        /// Parses a DateTime from a filename ending in date format 
        /// "<paramref name="separator"/>[yyyyMMdd]" (excluding extension)
        /// </summary>
        /// <remarks>
        /// If no DateTime can be found matching the expected format, 
        /// returns <paramref name="defaultValue"/> (yesterday's date if null)
        /// </remarks>
        /// <param name="fileName"></param>
        /// <param name="separator"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromFileName(string fileName, char separator = '_', DateTime? defaultValue = null)
        {
            defaultValue ??= DateTime.Today.AddDays(-1);
            DateTime result = (DateTime)defaultValue;
            string dateFormatString = "yyyyMMdd";

            if (fileName.LastIndexOf(separator) > 0 
                && fileName.Length > fileName.LastIndexOf(separator) + dateFormatString.Length)
            {
                string dateString = fileName.Substring(fileName.LastIndexOf(separator) + 1, dateFormatString.Length);
                if (!DateTime.TryParseExact(
                    dateString, dateFormatString, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out result))
                {
                    result = (DateTime)defaultValue;
                }
            }
            return result;
        }
    }
}
