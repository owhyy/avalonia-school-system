using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _errorLabel;
    private string _password;
    private string _username;

    public LoginViewModel(IEnumerable<User> users)
    {
        users = new ObservableCollection<User>(users);
        var canLogin = this.WhenAnyValue(
            x => x.Username,
            x => x.Password,
            (user, pass) => !string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass)
        );

        Login = ReactiveCommand.Create(
            () =>
            {
                var validCredentials = false;
                try
                {
                    validCredentials = !users
                        .Single(user => user.Username == _username && user.Password == _password)
                        .Equals(null);
                }
                // TODO: figure out a better thing to catch here
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (!validCredentials)
                    ErrorLabel = "Invalid credentials";
                return validCredentials;
            },
            canLogin
        );
    }

    public string ErrorLabel
    {
        get => _errorLabel;
        set => this.RaiseAndSetIfChanged(ref _errorLabel, value);
    }

    [Required]
    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    [Required]
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public ReactiveCommand<Unit, bool> Login { get; }
}
