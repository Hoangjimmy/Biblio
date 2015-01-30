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
using BusinessLayer;

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour EmprunteurManager.xaml
    /// </summary>
    public partial class EmprunteurManager : Window
    {
        public EmprunteurManager()
        {
            InitializeComponent();
            mListeBoxEmprunteur.DataContext = BiblioManager.listeEmprunteur();
           // mListeBoxEmprunteur.MouseLeftButtonDown += new MouseButtonEventHandler(eventButton);
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            mGridItem.DataContext = mListeBoxEmprunteur.SelectedItem;
        }
    }
}
