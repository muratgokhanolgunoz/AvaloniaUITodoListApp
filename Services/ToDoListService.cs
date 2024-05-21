using AvaloniaUITodoListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaUITodoListApp.Services
{
    public class ToDoListService
    {
        public IEnumerable<ToDoItem> GetItems() => new[]
        {
            new ToDoItem
            {
                Description = "Update the project documentation"
            },
            new ToDoItem
            {
                Description = "Implement the login feature"
            },
            new ToDoItem
            {
                Description = "Fix bugs reported in issue tracker"
            },
            new ToDoItem
            {
                Description = "Review pull requests",
                IsChecked = true
            }
        };
    }
}
