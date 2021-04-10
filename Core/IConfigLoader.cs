using WakeOnLan.Model;

namespace WakeOnLan.Core
{
    public interface IConfigLoader
    {
        DeviceList LoadConfig();
    }
}