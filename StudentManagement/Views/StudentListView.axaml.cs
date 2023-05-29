using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DialogHost;
using StudentManagement.ViewModels;

namespace StudentManagement.Views;

public partial class StudentListView : UserControl
{
    public StudentListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void DialogHost_OnDialogClosing(object? sender, DialogClosingEventArgs e)
    {
        var vm = (StudentListViewModel)DataContext!;
        vm.DialogIsOpen = false;
    }
}