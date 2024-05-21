using AvaloniaUITodoListApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ToDoListViewModel(IEnumerable<ToDoItem> items)
        {
            ToDoList = new ObservableCollection<ToDoItem>(items);
        }

        public ObservableCollection<ToDoItem> ToDoList { get; }
    }
}