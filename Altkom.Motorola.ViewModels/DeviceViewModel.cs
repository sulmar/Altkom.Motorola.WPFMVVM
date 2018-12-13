using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.ViewModels
{
    public class DeviceViewModel : BaseViewModel
    {
        private readonly IDevicesService devicesService;

        public Device SelectedDevice { get; set; }

        public DeviceViewModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;

            Load();
        }

        private void Load()
        {
            SelectedDevice = devicesService.Get(1);
        }
    }
}
