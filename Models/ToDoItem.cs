using System;

namespace AvaloniaUITodoListApp.Models
{
    public class ToDoItem
    {
        public required int Id { get; set; }
        public required string Description { get; set; } = String.Empty;
        public bool IsChecked { get; set; }
    }
}
