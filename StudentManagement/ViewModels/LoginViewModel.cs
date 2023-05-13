using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace StudentManagement.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private ObservableAsPropertyHelper<string> _errorLabel;
    private string _password;
    private string _username;

    public LoginViewModel()
    {
        
        var canLogin = this.WhenAnyValue(x => x.Username, x => x.Password,
            (user, pass) => !string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass));

        canLogin.Select(valid => valid ? "" : "Username and password are required")
            .ToProperty(this, x => x.ErrorLabel, out _errorLabel);
        
        LogIn = ReactiveCommand.Create(
            () =>
            {
                // using var context = new UserContext();
                // var validCredentials = !context.Users
                //     .Single(user => user.username == _username && user.password == _password)
                //     .Equals(null);
                var validCredentials = Username == "a" && Password == "b";
                this.WhenAnyValue(x => x.Username, x => x.Password, (user, pass) =>
                    Username == "a" && Password == "b").Select(valid => valid ? "" : "Invalid credentials").ToProperty(this, x => x.ErrorLabel, out _errorLabel);
                Console.WriteLine(validCredentials);
                return validCredentials;
            }, canLogin);
    }
    
    public string ErrorLabel => _errorLabel.Value;

    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public ReactiveCommand<Unit, bool> LogIn { get; }
}