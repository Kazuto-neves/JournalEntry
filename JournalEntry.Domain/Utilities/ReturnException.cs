namespace JournalEntry.Domain.Utilities
{
    public static class ReturnException
    {
        public static Exception argumentNullException(string message) => new ArgumentNullException(message);
        public static Exception nullReferenceException(string message) => new NullReferenceException(message);
    }
}