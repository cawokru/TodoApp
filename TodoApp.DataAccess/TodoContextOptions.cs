namespace TodoApp.DataAccess
{
    public class TodoContextOptions
    {
        private const string DefaultDatabaseName = "TodoApp";
        public string ConnectionString { get; set; }

        public bool UseInMemoryDb { get; set; } = false;
        public string DefaultDbName { get; set; } = DefaultDatabaseName;
    }
}
