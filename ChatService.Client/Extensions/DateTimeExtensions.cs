namespace ChatService.Client.Extensions
{
    public static class DateTimeExtensions
	{
        public static double ToElapsedTime(this DateTime source, DateTime dateTime)
        {
            return (source - dateTime).TotalSeconds;
        }
    }
}