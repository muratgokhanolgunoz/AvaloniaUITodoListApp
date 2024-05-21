using AvaloniaUITodoListApp.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Windows.Input;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ObservableCollection<ToDoItem> ToDoList { get; }
        public ICommand DeleteCommand { get; }

        public ToDoListViewModel(IEnumerable<ToDoItem> items)
        {
            ToDoList = new ObservableCollection<ToDoItem>(items);

            DeleteCommand = ReactiveCommand.Create<ToDoItem>(item =>
            {
                var list = items.ToList();
                list.Remove(item);

                items = list.AsEnumerable();
            });
        }

        
    }
}