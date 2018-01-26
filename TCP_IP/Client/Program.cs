using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Client.Models;

namespace Client
{
    public class Program
    {
        private static GPSLLH ParseLLHData(
            string LLHDataInStringLine
        )
        {
            string[] LLHArray = LLHDataInStringLine.Split(
                ' ', StringSplitOptions.RemoveEmptyEntries
            );

            int LLHArrayLength = LLHArray.Length;
            if(LLHArrayLength != 15)
            {
                // Console.WriteLine($"Data Error: Data Length = {LLHArrayLength}");
                // Console.WriteLine(LLHDataInStringLine);
                // for (int i = 0; i < LLHArrayLength; i++)
                // {
                //     Console.WriteLine(LLHArray[i]);
                // }
                return null;
            }

            return new GPSLLH{
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

        private static bool ConnectToServer(
            string fullAddress
        )
        {
            TcpClient tcpclnt = new TcpClient();
            
            try
            {
                // Get base address and port
                string[] address = fullAddress.Split(
                    ':', 
                    StringSplitOptions.RemoveEmptyEntries);

                if(address.Length != 2)
                {
                    Console.WriteLine("Error: Invalid server address");
                    Console.WriteLine("It must be like this: 127.0.0.1:8080");
                    return false;
                }

                // Connect to  server
                Console.WriteLine("Try to connect to server.....");
                tcpclnt.Connect(address[0], Int32.Parse(address[1]));
                Console.WriteLine($"Connected to {fullAddress}");

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
                    if(gpsLLH != null)
                        Console.WriteLine(
                            $"[{gpsLLH.date} {gpsLLH.time}]:  {gpsLLH.latitude}  {gpsLLH.longitude}  {gpsLLH.height}");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
            }
            finally
            {
                tcpclnt.Close();
            }

            return true;
        }
        static void Main(string[] args)
        {
            int argsLength = args.Length;
            if(argsLength != 2)
            {
                Console.WriteLine("Usage: Client <Server URL> <Request URL>");
                Console.WriteLine();
                Console.WriteLine("Arguments:");
                Console.Write("  <Server URL>\t");
                Console.Write("Server address containing base address and port ");
                Console.WriteLine("(ex. 127.0.0.1:8080)");
                Console.Write("  <Post URL>\t");
                Console.Write("REST request URL in POST verb that accept JSON format ");
                Console.WriteLine("(ex. 127.0.0.1:8080/api/post)");

                return;
            }

            bool isSuccess = ConnectToServer(args[0]);

            if(isSuccess == false)
                return;
        }
    }
}
