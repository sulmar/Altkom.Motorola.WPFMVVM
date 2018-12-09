using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.WPFClient.ViewModels
{
    class DevicesViewModel
    {
        private ICollection<Device> devices;



        public DevicesViewModel(IDevicesService devicesService)
        {
            devices = devicesService.Get();
        }
    }
}
