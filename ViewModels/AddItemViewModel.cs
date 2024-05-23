using AvaloniaUITodoListApp.Models;
using ReactiveUI;
using System;
using System.Reactive;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string _description = string.Empty;

        public ReactiveCommand<Unit, ToDoItem> AddCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public AddItemViewModel()
        {
            var isValidObservable = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            AddCommand = ReactiveCommand.Create(AddItemProcess, isValidObservable);
            CancelCommand = ReactiveCommand.Create(CancelProcess);
        }

        public ToDoItem AddItemProcess()
        {
            Random random = new Random();

            return new ToDoItem 
            { 
                Id = random.Next(), 
                Description = Description 
            };
        }

        public void CancelProcess()
        {

        }
    }
}