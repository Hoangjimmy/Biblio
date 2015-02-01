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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindowsBinding.xaml
    /// </summary>
    public partial class MainWindowsBinding : Window
    {
        public MainWindowsBinding()
        {
            InitializeComponent();
        }

        private void Button_Click_Auteur(object sender, RoutedEventArgs e)
        {
            AutorManager win = new AutorManager();
            win.Show();
        }

        private void Button_Click_Livres(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Emprunts(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Emprunteurs(object sender, RoutedEventArgs e)
        {
            EmprunteurManager win = new EmprunteurManager();
            win.Show();
        }
    }
}
