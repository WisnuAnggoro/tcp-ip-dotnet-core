using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Client.Models;
using RestSharp;

namespace Client
{
    public class Program
    {
        private static bool PostToDatabase(
            string dbAddress,
            GPSLLH gpsDataFromDevice
        )
        {
            try
            {
                var client = new RestClient(
                    dbAddress);
                var request = new RestRequest(
                    Method.POST);

                request.AddHeader(
                    "Content-Type", 
                    "application/json");
                request.AddJsonBody(
                    new LatLongGps()
                    {
                        latitude = gpsDataFromDevice.latitude,
                        longitude = gpsDataFromDevice.longitude
                    });

                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    Console.WriteLine(
                        "Succesfully sent data to database :-)");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed in sending data :'(");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                return false;
            }
        }

        private static GPSLLH ParseLLHData(
            string LLHDataInStringLine
        )
        {
            string[] LLHArray = LLHDataInStringLine.Split(
                ' ', StringSplitOptions.RemoveEmptyEntries
            );

            int LLHArrayLength = LLHArray.Length;
            if (LLHArrayLength != 15)
            {
                // Console.WriteLine($"Data Error: Data Length = {LLHArrayLength}");
                // Console.WriteLine(LLHDataInStringLine);
                // for (int i = 0; i < LLHArrayLength; i++)
                // {
                //     Console.WriteLine(LLHArray[i]);
                // }
                return null;
            }

            return new GPSLLH
            {
                date = LLHArray[0],
                time = LLHArray[1],
                latitude = LLHArray[2],
                longitude = LLHArray[3],
                height = LLHArray[4],
                Q = LLHArray[5],
                ns = LLHArray[6],
                sdn = LLHArray[7],
                sde = LLHArray[8],
                sdu = LLHArray[9],
                sdne = LLHArray[10],
                sdeu = LLHArray[11],
                sdun = LLHArray[12],
                age = LLHArray[13],
                ratio = LLHArray[14]
            };
        }

        private static bool ConnectToDevice(
            string deviceAddress,
            string databaseAddress
        )
        {
            TcpClient tcpclnt = new TcpClient();
            bool boRet = true;

            try
            {
                // Get base address and port
                string[] address = deviceAddress.Split(
                    ':',
                    StringSplitOptions.RemoveEmptyEntries);

                if (address.Length != 2)
                {
                    Console.WriteLine("Error: Invalid server address");
                    Console.WriteLine("It must be like this: 127.0.0.1:8080");
                    return false;
                }

                // Connect to  server
                Console.WriteLine("Try to connect to server.....");
                tcpclnt.Connect(address[0], Int32.Parse(address[1]));
                Console.WriteLine($"Connected to {deviceAddress}");

                // Read data from server
                Stream stm = tcpclnt.GetStream();
                string packetData;
                int packetLength = 1024;
                byte[] packetBytes = new byte[packetLength];
                while (true)
                {
                    int totalLength = stm.Read(packetBytes, 0, packetLength);
                    packetData = String.Empty;
                    for (int i = 0; i < totalLength; ++i)
                        packetData += Convert.ToChar(packetBytes[i]);
                    // Console.Write(packetData);
                    GPSLLH gpsLLH = ParseLLHData(packetData);
                    if (gpsLLH != null)
                    {
                        // Notify user
                        Console.WriteLine(
                            $"[{gpsLLH.date} {gpsLLH.time}]:  {gpsLLH.latitude}  {gpsLLH.longitude}  {gpsLLH.height}");
                        
                        // Sent data to database
                        PostToDatabase(
                            databaseAddress,
                            gpsLLH);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                boRet = false;
            }
            finally
            {
                tcpclnt.Close();
            }

            return boRet;
        }
        static void Main(string[] args)
        {
            int argsLength = args.Length;
            if(argsLength != 2)
            {
                Console.WriteLine("Usage: Client <Device URL> <Request URL>");
                Console.WriteLine();
                Console.WriteLine("Arguments:");
                Console.Write("  <Device URL>\t");
                Console.Write("Device address containing base address and port ");
                Console.WriteLine("(ex. 127.0.0.1:8080)");
                Console.Write("  <Post URL>\t");
                Console.Write("REST request URL in POST verb that accept JSON format ");
                Console.WriteLine("(ex. http://127.0.0.1:8080/api/post)");

                return;
            }

            bool isSuccess = ConnectToDevice(
                args[0],
                args[1]);
            if(isSuccess == false)
                return;
        }
    }
}
