using AvaloniaUITodoListApp.Services;
using ReactiveUI;

namespace AvaloniaUITodoListApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _viewModelBase;

        public MainWindowViewModel()
        {
            var service = new ToDoListService();
            ToDoListViewModel = new ToDoListViewModel(service.GetItems());

            _viewModelBase = ToDoListViewModel;
        }

        public ToDoListViewModel ToDoListViewModel { get; }

        public ViewModelBase ViewModelBase
        {
            get => _viewModelBase;
            private set => this.RaiseAndSetIfChanged(ref _viewModelBase, value);
        }

        public void AddItem()
        {
            ViewModelBase = new AddItemViewModel();
        }
    }
}
