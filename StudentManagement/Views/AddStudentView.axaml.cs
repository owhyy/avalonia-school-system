using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace StudentManagement.Views;

public partial class AddStudentView : UserControl
{
    public AddStudentView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}