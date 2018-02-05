using System;
namespace DistanceCalc.Models
{
    public class HostAddress
    {
        public string Base
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public HostAddress(
            string address)
        {
            try
            {
                // Get base address and port
                string[] addresses = address.Split(
                    ':');

                if (addresses.Length != 2)
                {
                    //Console.WriteLine("Error: Invalid server address");
                    //Console.WriteLine("It must be like this: 127.0.0.1:8080");

                    this.Base = null;
                    this.Port = -1;
                }

                this.Base = addresses[0];
                this.Port = Int32.Parse(addresses[1]);
            }
            catch
            {
				this.Base = null;
				this.Port = -1;
            }
        }
    }
}
