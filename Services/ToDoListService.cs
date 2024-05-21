using AvaloniaUITodoListApp.Models;
using System.Collections.Generic;

namespace AvaloniaUITodoListApp.Services
{
    public class ToDoListService
    {
        public IEnumerable<ToDoItem> GetItems() => new[]
        {
            new ToDoItem
            {
                Id = 1,
                Description = "Update the project documentation"
            },
            new ToDoItem
            {
                Id = 2,
                Description = "Implement the login feature"
            },
            new ToDoItem
            {
                Id = 3,
                Description = "Fix bugs reported in issue tracker"
            },
            new ToDoItem
            {
                Id = 4,
                Description = "Review pull requests",
                IsChecked = true
            }
        };
    }
}
