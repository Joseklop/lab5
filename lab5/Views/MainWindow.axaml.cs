using Avalonia.Controls;
using lab5.ViewModels;
using Avalonia.Interactivity;

namespace lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("OpenFileButton").Click += async delegate
            {
                var taskPathIn = new OpenFileDialog()
                {
                    Title = "Open file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPathIn;
                var contex = this.DataContext as MainWindowViewModel;
                if (path != null) contex.SetPath = string.Join(@"\", path);
            };

            this.FindControl<Button>("SaveFileButton").Click += async delegate
            {
                var taskPathOut = new OpenFileDialog()
                {
                    Title = "Choose file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path2 = await taskPathOut;
                var contex = this.DataContext as MainWindowViewModel;
                if (path2 != null) contex.GetPath = string.Join(@"\", path2);
            };


        }
        private void MyClickEventHandler(object sender, RoutedEventArgs e)
        {
            var window = new RegexWindow();
            window.DataContext = this.DataContext as MainWindowViewModel;
            window.FindControl<TextBox>("InputText").Text = ((MainWindowViewModel)this.DataContext).Regex_Prev;
            window.ShowDialog((Window)this.VisualRoot);
        }
    }
}