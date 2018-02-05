using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using DistanceCalc.Models;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    private bool isConnectToBase = false;
    private bool isConnectToRover = false;

    private LatLon baseLatLon = new LatLon();
    private LatLon roverLatLon = new LatLon();

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        SetUp();
	}

	private void SetUp()
	{
		Pango.FontDescription fontdesc =
			Pango.FontDescription.FromString("Consolas 40");
		lblDistance.ModifyFont(fontdesc);
	}

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
	}

	private double FindDistanceFromTwoPoints(
		double p1_lat,
		double p1_lon,
		double p2_lat,
		double p2_lon)
	{
		try
		{
			//https://www.movable-type.co.uk/scripts/latlong.html

			// Convert string to double
			//var p1_lat = double.Parse(p1.latitude);
			//var p1_lon = double.Parse(p1.longitude);
			//var p2_lat = double.Parse(p2.latitude);
			//var p2_lon = double.Parse(p2.longitude);

			// Earth radius = 6371km
			var R = 6371000;

			var lat1 = p1_lat.ToRadians();
			var lon1 = p1_lon.ToRadians();
			var lat2 = p2_lat.ToRadians();
			var lon2 = p2_lon.ToRadians();

			var lat_delta = (lat2 - lat1).ToRadians();
			var lon_delta = (lon2 - lon1).ToRadians();

			var a = Math.Sin(lat_delta / 2) * Math.Sin(lat_delta / 2) +
						Math.Cos(lat1) * Math.Cos(lat2) *
						Math.Sin(lon_delta / 2) * Math.Sin(lon_delta / 2);
			var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

			return R * c;
		}
		catch
		{
			return 0;
		}
	}

    private void AppendTextViewBase(string line)
    {
		txtViewBase.Buffer.Text += "\n";
        txtViewBase.Buffer.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]: ";
		txtViewBase.Buffer.Text += line;
    }

	private void AppendTextViewRover(string line)
	{
		txtViewRover.Buffer.Text += "\n";
		txtViewRover.Buffer.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]: ";
		txtViewRover.Buffer.Text += line;
	}

	private static GPSLLH ParseLLHData(
			string LLHDataInStringLine
		)
	{
		string[] LLHArray = LLHDataInStringLine.Split(
			' ');
		int LLHArrayLength = LLHArray.Length;

        // reconstruct array
        List<string> list = new List<string>();
        for (int i = 0; i < LLHArrayLength; ++i)
            if (!String.IsNullOrEmpty(LLHArray[i]))
                list.Add(LLHArray[i]);
            
        if (list.Count < 15)
		{
			return null;
		}

		return new GPSLLH
		{
			date = list[0],
			time = list[1],
			latitude = list[2],
			longitude = list[3],
			height = list[4],
			Q = list[5],
			ns = list[6],
			sdn = list[7],
			sde = list[8],
			sdu = list[9],
			sdne = list[10],
			sdeu = list[11],
			sdun = list[12],
			age = list[13],
			ratio = list[14]
		};
	}

    private LatLon ConnectToDevice(string deviceAddress)
	{

		TcpClient tcpclnt = new TcpClient();
        LatLon latlon = null;

		try
		{
			// Connect to base server
			//txtViewBase.Buffer.Text += ("Try to connect to base server.....");

			HostAddress addr = new HostAddress(deviceAddress);

			tcpclnt.Connect(addr.Base, addr.Port);
			//txtViewBase.Buffer.Text += ($"Connected to {deviceAddress}");

			// Read data from server
			Stream stm = tcpclnt.GetStream();
			string packetData;
			int packetLength = 512;
			byte[] packetBytes = new byte[packetLength];
			int totalLength = stm.Read(packetBytes, 0, packetLength);
			packetData = String.Empty;
			for (int i = 0; i < totalLength; ++i)
				packetData += Convert.ToChar(packetBytes[i]);
			GPSLLH gpsLLH = ParseLLHData(packetData);
			if (gpsLLH != null)
			{
				// Notify user
                //AppendTextViewBase($"{gpsLLH.latitude}, {gpsLLH.longitude}");

                // just convert string to double
                // if it's not compatible, an exception will be thrown
                latlon = new LatLon()
                {
                    Latitude = double.Parse(gpsLLH.latitude),
                    Longitude = double.Parse(gpsLLH.longitude)
                };
			}

            return latlon;
		}
		catch (Exception)
		{
			//AppendTextViewBase("Error: " + e.StackTrace);
            return latlon;
		}
		finally
		{
			tcpclnt.Close();
		}
	}

    private void StartBaseConnection()
    {
        GLib.Timeout.Add(500, new GLib.TimeoutHandler(ConnectToBase));
    }

    private bool ConnectToBase()
    {
        if (!isConnectToBase)
            return isConnectToBase;

        baseLatLon = ConnectToDevice(txtBaseAddress.Text);

        if (baseLatLon != null)
            AppendTextViewBase($"{baseLatLon.Latitude}, {baseLatLon.Longitude}");
        else
            AppendTextViewBase("Waiting for data...");
        
        return true;
    }

	private void StartRoverConnection()
	{
		GLib.Timeout.Add(500, new GLib.TimeoutHandler(ConnectToRover));
	}

	private bool ConnectToRover()
	{
		if (!isConnectToRover)
			return isConnectToRover;

		roverLatLon = ConnectToDevice(txtRoverAddress.Text);

		if (roverLatLon != null)
			AppendTextViewRover($"{roverLatLon.Latitude}, {roverLatLon.Longitude}");
		else
			AppendTextViewRover("Waiting for data...");
        
		return true;
	}

    protected void OnBtnBaseConnectClicked(object sender, EventArgs e)
    {
		if (btnBaseConnect.Label.Equals("Connect"))
		{
            txtViewBase.Buffer.Text = "Connecting...";
			btnBaseConnect.Label = "Disconnect";

            isConnectToBase = true;
            StartBaseConnection();
		}
		else
		{
			btnBaseConnect.Label = "Connect";

            isConnectToBase = false;
		}
    }

    protected void OnTxtViewBaseSizeAllocated(object o, SizeAllocatedArgs args)
    {
        txtViewBase.ScrollToIter(txtViewBase.Buffer.EndIter, 0, false, 0, 0);
    }

    protected void OnBtnRoverConnectClicked(object sender, EventArgs e)
    {
		if (btnRoverConnect.Label.Equals("Connect"))
		{
			txtViewRover.Buffer.Text = "Connecting...";
			btnRoverConnect.Label = "Disconnect";

			isConnectToRover = true;
			StartRoverConnection();
		}
		else
		{
			btnRoverConnect.Label = "Connect";

			isConnectToRover = false;
		}
    }

    protected void OnTxtViewRoverSizeAllocated(object o, SizeAllocatedArgs args)
    {
        txtViewRover.ScrollToIter(txtViewBase.Buffer.EndIter, 0, false, 0, 0);
    }
}

// https://stormconsultancy.co.uk/blog/development/code-snippets/convert-an-angle-in-degrees-to-radians-in-c/
/// <summary>
/// Convert to Radians.
/// </summary>
/// <param name="val">The value to convert to radians</param>
/// <returns>The value in radians</returns>
public static class NumericExtensions
{
	public static double ToRadians(this double val)
	{
		return (Math.PI / 180) * val;
	}
}
