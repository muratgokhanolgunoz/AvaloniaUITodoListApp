using AvaloniaUITodoListApp.Models;
using AvaloniaUITodoListApp.Services;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _viewModelBase;
        public ToDoListViewModel ToDoListViewModel { get; }

        public MainWindowViewModel()
        {
            var service = new ToDoListService();
            ToDoListViewModel = new ToDoListViewModel(service.GetItems());

            _viewModelBase = ToDoListViewModel;
        }

        public ViewModelBase ViewModelBase
        {
            get => _viewModelBase;
            private set => this.RaiseAndSetIfChanged(ref _viewModelBase, value);
        }

        public void AddItem()
        {
            AddItemViewModel addItemViewModel = new();

            Observable.Merge(
                addItemViewModel.AddCommand,
                addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if(newItem != null)
                    {
                        ToDoListViewModel.ToDoList.Add(newItem);
                        ToDoListViewModel.CheckToDoListLength();
                    }

                    ViewModelBase = ToDoListViewModel;
                });

            ViewModelBase = addItemViewModel;
        }
    }
}
