using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab5.ViewModels;
using Avalonia.Interactivity;

namespace lab5.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OKButton").Click += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                context.Regex_New = context.Regex_Prev;
                Close();
            };

            this.FindControl<Button>("CancelButton").Click += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                context.Regex_Prev = context.Regex_New;
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
