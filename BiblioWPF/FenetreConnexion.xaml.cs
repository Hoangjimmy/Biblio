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

namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour FenetreConnexion.xaml
    /// </summary>
    public partial class FenetreConnexion : Window
    {
        public FenetreConnexion()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {

            if (BiblioManager.Instance.CheckConnexionUser(mTextBoxLogin.Text, mPasswordBoxPassword.Password))
            {
                MainWindow win = new MainWindow();
                win.Show();

                this.Close();
            }
            else
                MessageBox.Show("Erreur, Veuillez réessayer !");
        }


    }
}
