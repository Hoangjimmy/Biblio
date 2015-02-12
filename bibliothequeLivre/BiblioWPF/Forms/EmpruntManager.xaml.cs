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
using BiblioWPF.ViewModel;


namespace BiblioWPF
{
    /// <summary>
    /// Logique d'interaction pour EmpruntManager.xaml
    /// </summary>
    public partial class EmpruntManager : Window
    {
        public EmpruntManager()
        {
            InitializeComponent();
            EmpruntManagerViewModel emv = new EmpruntManagerViewModel();
            mStackPanelEmpruntManager.DataContext = emv;
        }
    }
}
