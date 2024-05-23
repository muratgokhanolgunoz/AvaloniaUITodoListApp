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
        public ObservableCollection<ToDoItem> ToDoList { get; }
        public ReactiveCommand<int, Unit> DeleteItemCommand { get; }

        public ToDoListViewModel(IEnumerable<ToDoItem> items)
        {
            ToDoList = new ObservableCollection<ToDoItem>(items);
            DeleteItemCommand = ReactiveCommand.Create<int>(DeleteItemProcess);
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