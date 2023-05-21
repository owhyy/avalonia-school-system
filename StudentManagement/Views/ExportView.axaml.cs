using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace StudentManagement.Views;

public partial class ExportView : UserControl
{
    public ExportView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
