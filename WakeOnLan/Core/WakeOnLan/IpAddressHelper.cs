using System;
using System.Net;
using System.Text.RegularExpressions;

namespace WakeOnLan.WakeOnLan.Core.WakeOnLan
{
    public static class IpAddressHelper
    {
        public static long Ipv4FromString(string ipAddress)
        {
            if (!Regex.IsMatch(ipAddress, @"(?:\d{1,3}\.){3}\d{1,3}$"))
            {
                throw new ArgumentException($"Ip address {ipAddress} is not in a valid format");
            }

            string fullAdress = "";
            string[] addressAsOctets = ipAddress.Split(".");
            Array.Reverse(addressAsOctets);


            Console.WriteLine($"reversed: {string.Join(".", addressAsOctets)}");

            foreach (string octetAsString in addressAsOctets)
            {
                int octet = Convert.ToInt32(octetAsString);
                fullAdress += Convert.ToString(octet, 16).PadLeft(2, '0');
            }

            Console.WriteLine(fullAdress);

            return Convert.ToInt64(fullAdress.ToUpper(), 16);
        }

        public static IPAddress Ipv4AddressFromString(string ipAddress)
        {
            return new IPAddress(Ipv4FromString(ipAddress));
        }
    }
}