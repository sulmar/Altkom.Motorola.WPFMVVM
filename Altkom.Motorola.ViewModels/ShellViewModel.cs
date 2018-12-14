using Altkom.Motorola.Framework;
using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Altkom.Motorola.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {

        public double MyWidth { get; set; } = 100;


        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        //private Device _selectedDevice;
        //public Device SelectedDevice
        //{
        //    get => _selectedDevice;
        //    set
        //    {
        //        _selectedDevice = value;
        //        OnPropertyChanged();


        //        UpdateCommand.OnCanExecuteChanged();
        //        RemoveCommand.OnCanExecuteChanged();

        //    }
        //}

        private bool _isConnected;


        

        public ICommand LoadCommand { get; private set; }

        public ICommand ContactsCommand { get; set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand OnOffCommand { get; private set; }

        private readonly INavigationService navigationService;

        public ShellViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            LoadCommand = new RelayCommand(p => Load(), p => CanLoad);
            ContactsCommand = new RelayCommand(p => navigationService.Navigate("Contacts"));

            // UpdateCommand = new RelayCommand(p => Update(), p => IsSelectedDevice);
            //   RemoveCommand = new RelayCommand(p => Remove(), p => IsSelectedDevice);
            OnOffCommand = new RelayCommand(p => OnOff());

            IsConnected = true;



            // Load();
        }

        private void Load()
        {
            navigationService.Navigate("Devices", IsConnected);
        }

        private bool CanLoad => IsConnected;


        public void Update()
        {
            //SelectedDevice.Color = "Red";
            //SelectedDevice.Name = "Moje radio";


        }

        // public void Remove() => Devices.Remove(SelectedDevice);


        public void OnOff()
        {
            IsConnected = !IsConnected;
        }




    }
}
