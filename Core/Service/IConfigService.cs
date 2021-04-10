using System.Collections.Generic;
using WakeOnLan.Model;

namespace WakeOnLan.Core.Service
{
    public interface IConfigService
    {
        IList<Device> GetAllDevices();

        Device GetDeviceById(int id);

        Device GetDeviceByName(string name);
    }
}