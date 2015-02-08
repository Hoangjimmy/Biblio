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
using EntitiesLayer;
using BusinessLayer;

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour CtrlLivre.xaml
    /// </summary>
    public partial class CtrlLivre : UserControl
    {
        private Livre _livre;

        public Livre Livre {
            get
            {
                return _livre;
            }
            set
            {
                _livre = value;
                this.DataContext = _livre;
            }
        }

        public CtrlLivre()
        {
            InitializeComponent();
            mComboBoxAuteur.ItemsSource = BiblioManager.listeAuteur();
            mComboBoxGenre.ItemsSource = BiblioManager.listeGenre();
        }

        public Livre getLivre()
        {
            if (Livre == null)
                _livre = new Livre();

            /** Mise a jour du Livre */
            Livre.Titre = mTextBoxTitre.Text;
            Livre.Editeur = mTextBoxEditeur.Text;
            if(mDataPickerParution.SelectedDate != null)
                Livre.DateParution = (DateTime)mDataPickerParution.SelectedDate;
            Livre.NombrePages = int.Parse(mTextBoxPages.Text);
            Livre.ISBN = mTextBoxISBN.Text;
            if (mComboBoxGenre.SelectedValue != null)
                Livre.Genre = (Genre)mComboBoxGenre.SelectedValue;
            else
                Livre.Genre = null;
            if (mComboBoxAuteur.SelectedValue != null)
                Livre.Auteur = (Auteur)mComboBoxAuteur.SelectedValue;
            else
                Livre.Auteur = null;
            Livre.Note = int.Parse(mTextBoxNote.Text);

            return Livre;
        }
    }
}
