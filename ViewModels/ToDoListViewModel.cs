using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaUITodoListApp.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        private bool _noItemsFoundLabelVisibility;
        public ObservableCollection<ToDoItem> ToDoList { get; }
        public ReactiveCommand<int, Unit> DeleteItemCommand { get; }

        public ToDoListViewModel(IEnumerable<ToDoItem> items)
        {
            ToDoList = new ObservableCollection<ToDoItem>(items);
            CheckToDoListLength();

            DeleteItemCommand = ReactiveCommand.Create<int>(DeleteItemProcess);
        }

        public bool NoItemsFoundLabelVisibility
        {
            get => _noItemsFoundLabelVisibility;
            set => this.RaiseAndSetIfChanged(ref _noItemsFoundLabelVisibility, value);
        }

        public void CheckToDoListLength()
        {
            if (ToDoList.Count == 0)
            {
                NoItemsFoundLabelVisibility = true;
                return;
            }

            NoItemsFoundLabelVisibility = false;
        }

        public async void DeleteItemProcess(int id)
        {
            var messageBoxConfig = MessageBoxManager.GetMessageBoxStandard("Delete Process", "Are you sure?", ButtonEnum.YesNo, Icon.Question);
            var messageBox = await messageBoxConfig.ShowWindowDialogAsync((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow);

            if (messageBox == ButtonResult.Yes)
            {
                try
                {
                    ToDoItem? item = ToDoList.FirstOrDefault(item => item.Id == id);

                    if (!(item is null))
                    {
                        ToDoList.Remove(item);
                        CheckToDoListLength();
                    }
                }
                catch (Exception exception)
                {
                    var messageBoxErrorConfig = MessageBoxManager.GetMessageBoxStandard("Error", $"Failed to delete item. (Error: {exception})", ButtonEnum.Ok, Icon.Error);
                    await messageBoxErrorConfig.ShowWindowDialogAsync((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow);
                }
            }
        }
    }
}