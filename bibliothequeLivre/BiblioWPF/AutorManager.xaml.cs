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
using EntitiesLayer;
using System.Collections.ObjectModel;

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour AutorManager.xaml
    /// </summary>
    public partial class AutorManager : Window
    {
        public AutorManager()
        {
            InitializeComponent();
            mComboBoxSexe.ItemsSource = Enum.GetValues(typeof(ESexe));

            reloadListe();
            desactiverFormulaire();
            mButtonAjouter.IsEnabled = true;
        }

        private void desactiverFormulaire()
        {
            mButtonModifier.IsEnabled = false;
            mButtonSupprimer.IsEnabled = false;
            mButtonAjouter.IsEnabled = false;

            mTextBoxNom.IsEnabled = false;
            mTextBoxPrenom.IsEnabled = false;
            mComboBoxSexe.IsEnabled = false;
            mDataPickerNaissance.IsEnabled = false;
            mCheckBoxGoncourt.IsEnabled = false;
            mDataPickerMort.IsEnabled = false;
        }

        private void activerFormulaire()
        {
            mButtonModifier.IsEnabled = true;
            mButtonSupprimer.IsEnabled = true;
            mButtonAjouter.IsEnabled = true;

            mTextBoxNom.IsEnabled = true;
            mTextBoxPrenom.IsEnabled = true;
            mComboBoxSexe.IsEnabled = true;
            mDataPickerNaissance.IsEnabled = true;
            mCheckBoxGoncourt.IsEnabled = true;
            mDataPickerMort.IsEnabled = true;
        }

        private void viderFormulaire()
        {
            mGridItem.DataContext = null;
        }

        private void reloadListe()
        {
            mListeBoxAuteur.DataContext = new ObservableCollection<Auteur>(BiblioManager.listeAuteur());
        }

        private void mListeBoxAuteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mGridItem.DataContext = mListeBoxAuteur.SelectedItem;
            activerFormulaire();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            /** Si on n'est pas en creation */
            if (mListeBoxAuteur.SelectedItem != null)
            {
                Auteur auteur = (mListeBoxAuteur.SelectedItem as Auteur);

                /** Suppression de l'emprunteur */
                BiblioManager.removeAuteur(auteur);
            }

            reloadListe();
            desactiverFormulaire();
            mButtonAjouter.IsEnabled = true;

            /* On vide les données emprunteur affiches */
            viderFormulaire();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            activerFormulaire();
            mButtonAjouter.IsEnabled = false;
            viderFormulaire();
            mListeBoxAuteur.SelectedItem = null;
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            Auteur auteur;
            bool creation = false;
            bool erreur = false;

            /** Test des donnees */
            

            if (mGridItem.DataContext != null)
            {
                auteur = (mGridItem.DataContext as Auteur);
            }
            else
            {
                creation = true;
                auteur = new Auteur();
            }

            /** Mise a jour de l'emprunteur */
            auteur.Nom = mTextBoxNom.Text;
            auteur.Prenom = mTextBoxPrenom.Text;
            auteur.DateNaissance = mDataPickerNaissance.SelectedDate;
            if (mComboBoxSexe.SelectedValue != null)
                auteur.Sexe = (ESexe)mComboBoxSexe.SelectedValue;
            else
                auteur.Sexe = ESexe.Indetermine;

            //MessageBox.Show(mGridItem.DataContext.ToString());
            if (creation)
            {
                /** Ajout de l'emprunteur */
                BiblioManager.addAuteur(auteur);
            }

            reloadListe();
            /* On vide les données emprunteur affiches */
            mListeBoxAuteur.SelectedItem = auteur;
            viderFormulaire();
            /** On enleve toute selection */
            mListeBoxAuteur.SelectedItem = null;
            /** On desactive le formulaire */
            desactiverFormulaire();
            mButtonAjouter.IsEnabled = true;
        }
    }
}
