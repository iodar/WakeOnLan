using WakeOnLan.Model;

namespace WakeOnLan.Core
{
    public interface IConfigLoader
    {
        DeviceList LoadConfig();

        void UpdateAndReloadConfig(DeviceList devices);
    }
}