using Altkom.Motorola.Framework;
using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Altkom.Motorola.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public bool IsConnected { get; private set; }

        public Device SelectedDevice { get; set; }

        public ICollection<Device> Devices { get; set; }

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

        private readonly IDevicesService devicesService;

        public ShellViewModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;

            LoadCommand = new RelayCommand(p => Load(), p => CanLoad);

            IsConnected = false;

            Load();
        }

        private void Load()
        {            
            Devices = devicesService.Get();

            SelectedDevice = Devices.FirstOrDefault();
        }

        private bool CanLoad => IsConnected;

    }
}
