using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.MVVMLightDemo.ViewModels
{
    public class DevicesViewModel : BaseViewModel
    {
        private readonly IDevicesService devicesService;

        public ICollection<Device> Devices { get; set; }

        public DevicesViewModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;

            Load();
        }

        private void Load()
        {
            Devices = devicesService.Get();
        }
    }
}
