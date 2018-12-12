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

        public bool IsConnected { get; private set; }

        private Device _selectedDevice;
        public Device SelectedDevice
        {
            get => _selectedDevice;
            set
            {
                _selectedDevice = value;
                OnPropertyChanged();

                
                UpdateCommand.OnCanExecuteChanged();
                RemoveCommand.OnCanExecuteChanged();
                
            }
        }

        private ObservableCollection<Device> _devices;
        public ObservableCollection<Device> Devices
        {
            get => _devices;
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }

        //private ICommand _LoadCommand;
        //public ICommand LoadCommand
        //{
        //    get
        //    {
        //        if (_LoadCommand == null)
        //        {
        //            _LoadCommand = new RelayCommand(p => Load(), p => CanLoad);
        //        }

        //        return _LoadCommand;
        //    }
        //}

        public ICommand LoadCommand { get; private set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }

        private readonly IDevicesService devicesService;

        public bool IsSelectedDevice => SelectedDevice != null;


        public ShellViewModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;

            LoadCommand = new RelayCommand(p => Load(), p => CanLoad);
            UpdateCommand = new RelayCommand(p => Update(), p => IsSelectedDevice);
            RemoveCommand = new RelayCommand(p => Remove(), p => IsSelectedDevice);
            
            IsConnected = true;

            

            // Load();
        }

        private void Load()
        {
            Devices = new ObservableCollection<Device>(devicesService.Get());

            SelectedDevice = Devices.FirstOrDefault();
        }

        private bool CanLoad => IsConnected;


        public void Update()
        {
            SelectedDevice.Color = "Red";
            SelectedDevice.Name = "Moje radio";

            
        }

        public void Remove() => Devices.Remove(SelectedDevice);


        

    }
}
