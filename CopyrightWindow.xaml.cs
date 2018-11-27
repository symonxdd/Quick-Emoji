using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace QuickEmoji
{
    /// <summary>
    /// Interaction logic for CopyrightWindow.xaml
    /// </summary>
    public partial class CopyrightWindow : Window
    {
        public CopyrightWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
