using AvaloniaUITodoListApp.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ObservableCollection<ToDoItem> ToDoList { get; }
        public ReactiveCommand<int, Unit> DeleteCommand { get; }

        public ToDoListViewModel(IEnumerable<ToDoItem> items)
        {
            ToDoList = new ObservableCollection<ToDoItem>(items);

            DeleteCommand = ReactiveCommand.Create<int>(id =>
            {
                ToDoItem? item = ToDoList.FirstOrDefault(x => x.Id == id);

                if(!(item is null))
                {
                    ToDoList.Remove(item);
                }
            });
        }
    }
}