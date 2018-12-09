using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;

namespace Altkom.Motorola.IServices
{
    public interface IDevicesService
    {
        ICollection<Device> Get();
        Device Get(int id);
        void Add(Device device);
        void Update(Device device);
        void Remove(int id);
    }
}
