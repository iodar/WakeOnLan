using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace WakeOnLan.WakeOnLan.Core.WakeOnLan
{
    public class WakeOnLanHelper
    {
        public static void WakeFunction(string macAddress, string ipAddress)
        {
            //set sending bites
            //buffer to be send
            MagicPacket magicPacket = CreateMagicPacket(macAddress);

            IPAddress address = IpAddressHelper.Ipv4AddressFromString(ipAddress);
            UdpClient client = new UdpClient();
            client.EnableBroadcast = true;
            client.Connect(address, 12287);
            //now send wake up packet
            int reterned_value = client.Send(magicPacket.PacketBytes, magicPacket.PacketLength);
        }

        private static MagicPacket CreateMagicPacket(string MAC_ADDRESS)
        {
            MagicPacket magicPacket = new MagicPacket(new byte[1024]);
            int counter = 0;
            for (int y = 0; y < 6; y++)
            {
                magicPacket.PacketBytes[counter++] = 0xFF;
            }
            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    magicPacket.PacketBytes[counter++] =
                        byte.Parse(MAC_ADDRESS.Substring(i, 2), NumberStyles.HexNumber);
                    i += 2;
                }
            }

            return magicPacket;
        }

        internal class MagicPacket
        {
            public byte[] PacketBytes;
            public int PacketLength;

            internal MagicPacket(byte[] packetBytes)
            {
                PacketBytes = packetBytes;
                PacketLength = packetBytes.Length;
            }
        }
    }
}