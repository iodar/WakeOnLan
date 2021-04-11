using System.Collections.Generic;
using WakeOnLan.Model;

namespace WakeOnLan.Core.Service
{
    public interface IDeviceService
    {
        IList<Device> GetAllDevices();

        Device GetDeviceById(int id);

        Device GetDeviceByName(string name);
    }
}