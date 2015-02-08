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
using System.Net.Mail;

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour EmprunteurManager.xaml
    /// </summary>
    public partial class EmprunteurManager : Window
    {
        //private bool estEnCreation = false;

        public EmprunteurManager()
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

            mTextBoxAdresse.IsEnabled = false;
            mTextBoxEmail.IsEnabled = false;
            mTextBoxNom.IsEnabled = false;
            mTextBoxPrenom.IsEnabled = false;
            mTextBoxTelephone.IsEnabled = false;
            mComboBoxSexe.IsEnabled = false;
            mDataPickerNaissance.IsEnabled = false;
        }

        private void activerFormulaire()
        {
            mButtonModifier.IsEnabled = true;
            mButtonSupprimer.IsEnabled = true;
            mButtonAjouter.IsEnabled = true;

            mTextBoxAdresse.IsEnabled = true;
            mTextBoxEmail.IsEnabled = true;
            mTextBoxNom.IsEnabled = true;
            mTextBoxPrenom.IsEnabled = true;
            mTextBoxTelephone.IsEnabled = true;
            mComboBoxSexe.IsEnabled = true;
            mDataPickerNaissance.IsEnabled = true;
        }

        private void mListeBoxEmprunteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mGridItem.DataContext = mListeBoxEmprunteur.SelectedItem;
            activerFormulaire();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            /** Si on n'est pas en creation */
            if (mListeBoxEmprunteur.SelectedItem != null)
            {
                Emprunteur emprunteur = (mListeBoxEmprunteur.SelectedItem as Emprunteur);

                /** Suppression de l'emprunteur */
                BiblioManager.removeEmprunteur(emprunteur);
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
            mListeBoxEmprunteur.SelectedItem = null;
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            Emprunteur emprunteur;
            bool creation = false;
            bool erreur = false;

            /** Test des donnees */
            string tel = mTextBoxTelephone.Text;
            String mail = mTextBoxEmail.Text;
            if (tel != null && tel.Length > 0)
            {
                try
                {
                    long test = long.Parse(tel);
                }
                catch (FormatException)
                {
                    erreur = true;
                }
                if (tel.Length != 10)
                {
                    erreur = true;
                }
                if(erreur)
                {
                    MessageBox.Show("Numero de telephone invalide !");
                    return;
                }
            }
            if (mail != null)
            {
                try
                {
                    MailAddress test = new MailAddress(mail);
                }
                catch (FormatException)
                {
                    erreur = true;
                }
                if (erreur)
                {
                    MessageBox.Show("E-mail invalide !");
                    return;
                }
            }

            if(mGridItem.DataContext != null)
            {
                emprunteur = (mGridItem.DataContext as Emprunteur);
            }
            else
            {
                creation = true;
                emprunteur = new Emprunteur();
            }

            /** Mise a jour de l'emprunteur */
            emprunteur.Nom = mTextBoxNom.Text;
            emprunteur.Prenom = mTextBoxPrenom.Text;
            emprunteur.Adresse = mTextBoxAdresse.Text;
            emprunteur.Email = mTextBoxEmail.Text;
            emprunteur.Tel = mTextBoxTelephone.Text;
            emprunteur.DateNaissance = mDataPickerNaissance.SelectedDate;
            if (mComboBoxSexe.SelectedValue != null)
                emprunteur.Sexe = (ESexe)mComboBoxSexe.SelectedValue;
            else
                emprunteur.Sexe = ESexe.Indetermine;

            //MessageBox.Show(mGridItem.DataContext.ToString());
            if (creation)
            {
                /** Ajout de l'emprunteur */
                BiblioManager.addEmprunteur(emprunteur);
            }

            reloadListe();
            /* On vide les données emprunteur affiches */
            mListeBoxEmprunteur.SelectedItem = emprunteur;
            viderFormulaire();
            /** On enleve toute selection */
            mListeBoxEmprunteur.SelectedItem = null;
            /** On desactive le formulaire */
            desactiverFormulaire();
            mButtonAjouter.IsEnabled = true;
        }

        private void viderFormulaire()
        {
            mGridItem.DataContext = null;
        }

        private void reloadListe()
        {
            mListeBoxEmprunteur.DataContext = new ObservableCollection<Emprunteur>(BiblioManager.listeEmprunteur());
        }
    }
}
