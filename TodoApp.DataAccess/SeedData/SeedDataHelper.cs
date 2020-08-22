namespace TodoApp.DataAccess.SeedData
{
    class SeedDataHelper
    {
        public static void SeedDatabase(TodoContext context)
        {
            context.SeedTodos();
        }
    }
}
