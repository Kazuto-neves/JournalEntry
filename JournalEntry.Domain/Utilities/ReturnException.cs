namespace JournalEntry.Domain.Utilities
{
    public static class ReturnException
    {
        public static Exception nullException(string message) => new NullReferenceException(message);
    }
}
