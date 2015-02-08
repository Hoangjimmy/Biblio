using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using EntitiesLayer;

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour LivreManager.xaml
    /// </summary>
    public partial class LivreManager : Window
    {
        public LivreManager()
        {
            InitializeComponent();
            reloadListe();
        }

        private void mListeBoxLivre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mUC_livre.Livre = (Livre)mListeBoxLivre.SelectedItem;
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (mListeBoxLivre.SelectedItem != null)
            {
                Livre livre = (mListeBoxLivre.SelectedItem as Livre);

                BiblioManager.removeLivre(livre);
            }

            reloadListe();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            mUC_livre.Livre = null;
            mListeBoxLivre.SelectedItem = null;
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Livre livre = mUC_livre.getLivre();

                if (mListeBoxLivre.SelectedItem == null)
                {
                    BiblioManager.addLivre(livre);
                }

                reloadListe();

            }
            catch (FormatException)
            {
                MessageBox.Show("Nombre de pages ou Note incorrect");
            }
        }

        private void reloadListe()
        {
            mListeBoxLivre.DataContext = new ObservableCollection<Livre>(BiblioManager.listeLivre());
        }
    }
}
