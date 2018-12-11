using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Motorola.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public bool IsConnected { get; private set; }

        public Device SelectedDevice { get; set; }

        public ICollection<Device> Devices { get; set; }

        private readonly IDevicesService devicesService;

        public ShellViewModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;

            IsConnected = true;

            Load();
        }

        private void Load()
        {            
            Devices = devicesService.Get();

            SelectedDevice = Devices.FirstOrDefault();
        }
    }
}
