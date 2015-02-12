using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Windows;

namespace BiblioWPF.ViewModel
{
    class EmpruntManagerViewModel : ViewModelBase
    {

        public EmpruntManagerViewModel()
        {
            reloadListe();
        }

        private void reloadListe()
        {
            if (_emprunts == null)
                _emprunts = new ObservableCollection<EmpruntViewModel>();
            _emprunts.Clear();
            foreach (Emprunt a in BusinessLayer.BiblioManager.listeEmprunt())
            {
                MessageBox.Show(a.Id.ToString());
                EmpruntViewModel e = new EmpruntViewModel(new Emprunt(a));
                MessageBox.Show(e.Emprunt.Id.ToString());
                _emprunts.Add(e);

            }
        }





        private EmpruntViewModel _selectedItem;
        public EmpruntViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<EmpruntViewModel> _emprunts;

        public ObservableCollection<EmpruntViewModel> Emprunts
        {
            get { return _emprunts; }
            private set
            {
                _emprunts = value;
                OnPropertyChanged("Artistes");
            }
        }






        // Commande Add
        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            Emprunt e = new Emprunt();

            this.SelectedItem = new EmpruntViewModel(e);

            reloadListe();
        }

        // Commande Remove
        private RelayCommand _removeCommand;
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return _removeCommand;
            }
        }

        private bool CanRemove()
        {
            return (this.SelectedItem != null);
        }

        private void Remove()
        {
            if (this.SelectedItem != null) BusinessLayer.BiblioManager.removeEmprunt(this.SelectedItem.Emprunt);
            reloadListe();
        }

        // Commande Update
        private RelayCommand _updateCommand;
        public System.Windows.Input.ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(
                        () => this.Update(),
                        () => this.CanUpdate()
                        );
                }
                return _updateCommand;
            }
        }

        private bool CanUpdate()
        {
            return (this.SelectedItem != null);
        }

        private void Update()
        {
            BusinessLayer.BiblioManager.updateEmprunt(this.SelectedItem.Emprunt);

            reloadListe();
        }
    }
}
