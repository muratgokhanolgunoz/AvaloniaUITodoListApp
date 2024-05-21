using AvaloniaUITodoListApp.Services;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var service = new ToDoListService();
            ToDoListViewModel = new ToDoListViewModel(service.GetItems());
        }

        public ToDoListViewModel ToDoListViewModel { get; }
    }
}
