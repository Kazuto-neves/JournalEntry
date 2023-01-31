namespace JournalEntry.Domain.Settings
{
    public class SqlServerSettings
    {
        public string? Host { get; set; }

        public string? Port { get; set; }

        public string? User { get; set; }

        public string? Password { get; set; }

        public string? Database { get; set; }

        public string ConnectionString => $"Server={Host},{Port};Initial Catalog={Database};User ID={User};Password={Password}";
    }
}
