using Altkom.Motorola.Fakers;
using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Motorola.FakeServices
{
    public class FakeDevicesService : IDevicesService
    {
        private readonly ICollection<Device> devices;

        public FakeDevicesService()
        {
            DeviceFaker deviceFaker = new DeviceFaker();
            devices = deviceFaker.Generate(100);
        }

        public void Add(Device device)
        {
            devices.Add(device);
        }        

        public ICollection<Device> Get()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));

            return devices;
        }

        public Device Get(int id)
        {
            return devices.SingleOrDefault(d => d.Id == id);
        }

        public Task<ICollection<Device>> GetAsync()
        {
            return Task.Run(() => Get());
        }

        public void Remove(int id)
        {
            devices.Remove(Get(id));
        }

        public void Update(Device device)
        {
            throw new NotImplementedException();
        }
    }
}
