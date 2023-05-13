using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace StudentManagement.Views;

public partial class CourseListView : UserControl
{
    public CourseListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}