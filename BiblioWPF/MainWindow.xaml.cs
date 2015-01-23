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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using Microsoft.Win32;

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEmprunts_Click(object sender, RoutedEventArgs e)
        {
            mListBoxContenu.ItemsSource = BiblioManager.Instance.listeDesEmpruntsEnCours();
        }

        private void btnAuteurs_Click(object sender, RoutedEventArgs e)
        {
            mListBoxContenu.ItemsSource = BiblioManager.Instance.listeDesAuteursAvecPrixGoncourt();
        }

        private void btnLivreSup5_Click(object sender, RoutedEventArgs e)
        {
            mListBoxContenu.ItemsSource = BiblioManager.Instance.listeDesLivresAvecNoteSuperieurACinq();
        }

        private void btnLivreSup5EtGoncourt_Click(object sender, RoutedEventArgs e)
        {
            mListBoxContenu.ItemsSource = BiblioManager.Instance.listeDesLivresAvecNoteSuperieurACinqEtAuteurAvecPrixGoncourt();
        }

        private void btnExporter_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();
            BiblioManager.exportLivres(dialog.FileName);
        }
    }
}
