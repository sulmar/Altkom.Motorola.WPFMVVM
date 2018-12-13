using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.ViewModels
{
    public class DevicesViewModel : BaseViewModel
    {
        private readonly IDevicesService devicesService;


        private ObservableCollection<Device> _devices;

        public DevicesViewModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;

            Load();
        }

        public ObservableCollection<Device> Devices
        {
            get => _devices;
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }


        public void Load()
        {
            Devices = new ObservableCollection<Device>(devicesService.Get());
        }


    }
}
