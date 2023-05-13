using System; using ReactiveUI;

namespace StudentManagement.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    ViewModelBase _content;

    public MainWindowViewModel()
    {
        var vm = new LoginViewModel();
        vm.Login.Subscribe(validCredentials =>
        {
            if (validCredentials)
                Content = new MenuViewModel();
        });
        Content = vm;
    }

    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
}