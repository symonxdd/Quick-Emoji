using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace QuickEmoji
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer objTimer = new DispatcherTimer();
        DispatcherTimer objTimer2 = new DispatcherTimer();
        NotifyIcon myNotifyIcon = new NotifyIcon();
        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            

            //FIRSTRUN
            if (Properties.Settings.Default.FirstRun == true)
            {
                //app was run the first time + this code won't be executed anymore!

                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save(); //!!!

                rk.SetValue("Quick Emoji", System.Windows.Forms.Application.ExecutablePath.ToString());//because the Checkbox is default True!
                chkStartup.IsChecked = true;
                chkMinimized.IsChecked = true;
            }

            if (Properties.Settings.Default.Startup == true)
            {
                chkStartup.IsChecked = true;
                if (Properties.Settings.Default.Minimized == true)
                {
                    chkMinimized.IsChecked = true;
                }
            }
            else
            {
                if(Properties.Settings.Default.Minimized == true)
                {
                    chkMinimized.IsChecked = true;
                }
                chkMinimized.IsEnabled = false;
            }

            objTimer.Interval = new TimeSpan(0, 0, 0, 0, 450);
            objTimer.Tick += ObjTimer_Tick;

            objTimer2.Interval = new TimeSpan(0, 0, 0, 0, 450);
            objTimer2.Tick += ObjTimer2_Tick;
        }

        private void ObjTimer2_Tick(object sender, EventArgs e)
        {
            lblCopyConfirm.Content = "";
            objTimer.Stop();
        }

        private void ObjTimer_Tick(object sender, EventArgs e)
        {
            objTimer2.Start();
        }

        private void image7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("😂");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void image8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("😍");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void image9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("😏");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void image10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("😒");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void image11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("✌️");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void image12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("👌");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void image13_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("🖕");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetText("❤️");
            lblCopyConfirm.Content = "Succesfully Copied to Clipboard!";
            objTimer.Start();
        }

        private void grdSecretGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("Bonita ❤️ xoxo", "dit bericht tho");
        }

        private void chkStartup_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Startup = true;
            Properties.Settings.Default.Save();

            rk.SetValue("Quick Emoji", System.Windows.Forms.Application.ExecutablePath.ToString());//because the Checkbox is default True!
            chkMinimized.IsEnabled = true;
        }

        private void chkStartup_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Startup = false;
            Properties.Settings.Default.Save();

            rk.DeleteValue("Quick Emoji", true);
            chkMinimized.IsEnabled = false;
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CopyrightWindow objcw = new CopyrightWindow();
            objcw.Show();
        }

        private void chkMinimized_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Minimized = false;
            Properties.Settings.Default.Save();
        }

        private void chkMinimized_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Minimized = true;
            Properties.Settings.Default.Save();
        }
    }
}
