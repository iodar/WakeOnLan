using WakeOnLan.Model;

namespace WakeOnLan.Core
{
    public interface IConfigLoader
    {
        DeviceList GetConfig();

        void UpdateAndReloadConfig(DeviceList devices);
    }
}