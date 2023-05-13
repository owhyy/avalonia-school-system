using System;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;

namespace StudentManagement.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    ViewModelBase _content;

    public MainWindowViewModel()
    {
        Content = new LoginViewModel();
    }

    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
    
    public void LogIn()
    {
        var vm = new LoginViewModel();

        vm.LogIn.Subscribe(validCredentials =>
        {
            // Console.WriteLine(validCredentials);
            if (validCredentials)
                Content = new MenuViewModel();
        });
    }
}