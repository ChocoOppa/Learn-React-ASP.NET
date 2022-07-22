namespace ToDoAppApi.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo()
                {
                    Id = 1,
                    Name = "Mission 1",
                    IsComplete = false,
                },
                new Todo()
                {
                    Id=2,
                    Name = "Mission 2",
                    IsComplete = true,
                });
        }
    }
}
