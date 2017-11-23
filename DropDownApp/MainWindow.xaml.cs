using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DropDownApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Storyboard show;
        Storyboard hide;

        DateTime lastAnim;

        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            
            InitializeComponent();

            show = (FindResource("Show") as Storyboard);
            hide = (FindResource("Hide") as Storyboard);

            show.Completed += (s, e) => lastAnim = DateTime.Now;
            hide.Completed += (s, e) => lastAnim = DateTime.Now;
        }

        private void MainWindow_Deactivated(object sender, EventArgs e)
        {
            Console.WriteLine("Deactivation");
            AnimHide();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Activation");
            AnimShow();
        }

        private void AnimShow()
        {
            if (Top < 0 && DateTime.Now - lastAnim > AppInfos.HalfDureeAnim)
            {
                hide.Stop();
                show.Begin();
            }
        }

        private void AnimHide()
        {
            if (Top == 0 && DateTime.Now - lastAnim > AppInfos.HalfDureeAnim )
            {
                show.Stop();
                hide.Begin();
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InteropTools.EnableBlur(this);
            show.Begin();
            InteropTools.SetGlobalHotKey(this, Key.F10);
            
            Activated += MainWindow_Activated;
            Deactivated += MainWindow_Deactivated;
            KeyUp += MainWindow_KeyUp;
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key Pressed : " + e.Key.ToString() + " -> " + e.SystemKey.ToString());
            Console.WriteLine(Top);
            if (e.SystemKey == Key.F10 && Top == 0)
            {
                AnimHide();
            }
            else if (e.SystemKey == Key.F10 && Top < 0)
            {
                AnimShow();
            }
        }
    }
}
