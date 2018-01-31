using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using DesktopClient;
using Gtk;
using Newtonsoft.Json;
using RestSharp;

public partial class MainWindow : Gtk.Window
{
	private bool isContinueConnection = false;
	private bool isContinueCollecting = false;
    private bool isWaitingGpsData = false;

	private List<double> latList = new List<double>();
	private List<double> lonList = new List<double>();

	//private LatLongGps parkArea = new LatLongGps();
	private double parkAreaLat = 0;
	private double parkAreaLon = 0;
    private bool isParkSetted = false; 

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        SetUp();
    }

    private void SetUp()
    {
		Pango.FontDescription fontdesc = 
            Pango.FontDescription.FromString("Consolas 40");
        lblAverageChokePosition.ModifyFont(fontdesc);
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
   //         var p1_lat = double.Parse(p1.latitude);
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

    private bool SetParkArea(
        string lat,
        string lon)
    {
        try
        {
			parkAreaLat = double.Parse(lat);
            parkAreaLon = double.Parse(lon);

            //parkArea = new LatLongGps()
            //{
            //    latitude = lat,
            //    longitude = lon
            //};

            return true;
		}
        catch
        {
            return false;
        }
    }

	private void InfoNewLine(
        string line)
	{
        txtViewInfo.Buffer.Text = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: ";
        txtViewInfo.Buffer.Text += line;
	}

    private void InfoAppendLine(
        string line)
    {
        txtViewInfo.Buffer.Text += "\n";
        txtViewInfo.Buffer.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: ";
        txtViewInfo.Buffer.Text += line;
    }

	private void StartCollecting()
	{
		// Every second call `update_status' (30000 milliseconds)
		GLib.Timeout.Add(2000, new GLib.TimeoutHandler(CollectGpsData));
	}

    private bool CollectGpsData()
    {
        if (!isContinueCollecting)
            return isContinueCollecting;

        // Find average of latitude and longitude points
        double lat = latList.Average(d => d);
        double lon = lonList.Average(d => d);

        // Display the points
        lblAverageChokePosition.Text = $"{lat:F5}, {lon:F5}";

		// Clear the lists
		latList.Clear();
		lonList.Clear();

        if(isParkSetted)
        {
            double d = FindDistanceFromTwoPoints(
                lat, lon,
                parkAreaLat, parkAreaLon
            );

            lblDistance.Text = $"{d}";
        }

        return isContinueCollecting;
    }

	private void StartConnection()
	{
		// Every second call `ConnectToApi' (500 milliseconds)
		GLib.Timeout.Add(500, new GLib.TimeoutHandler(ConnectToApi));
	}

    private bool ConnectToApi()
    {
        if(!isContinueConnection)
            return isContinueConnection;
        
		try
		{
			var client = new RestClient(
                txtHost.Text);
			var request = new RestRequest(
                Method.GET);

            request.AddHeader(
            	"Content-Type",
            	"application/json");

            LatLongGps gps = null;
			IRestResponse response = client.Execute(request);
			if (response.IsSuccessful)
			{
                gps = JsonConvert.DeserializeObject<LatLongGps>(
                    response.Content);
			}
			else
			{
				txtViewInfo.Buffer.Text = 
                    $"FAIL: {response.StatusCode}";
			}

            if(gps != null)
            {
				//InfoAppendLine(
				//$"{gps.latitude}, {gps.longitude}");
				latList.Add(double.Parse(gps.latitude));
				lonList.Add(double.Parse(gps.longitude));

				InfoAppendLine("Data retrieved successfully...");

                isWaitingGpsData = false;
			}
            else
            {
                if (!isWaitingGpsData)
                {
                    InfoAppendLine(
                        $"Waiting...");

                    isWaitingGpsData = true;
                }
            }
		}
		catch (Exception e)
		{
			txtViewInfo.Buffer.Text = "Error: " + e.StackTrace;
		}

        return isContinueConnection;
    }

    protected void OnBtnChokeConnectClicked(object sender, EventArgs e)
    {
        if (btnChokeConnect.Label.Equals("Connect"))
        {
            InfoNewLine("Connecting...");
            btnChokeConnect.Label = "Disconnect";
            isContinueConnection = true;
            isContinueCollecting = true;
            StartCollecting();
            StartConnection();
        }
        else
        {
			btnChokeConnect.Label = "Connect";
            isContinueConnection = false;
            isContinueCollecting = false;
		}
    }

    protected void OnTxtViewInfoSizeAllocated(object o, SizeAllocatedArgs args)
    {
        txtViewInfo.ScrollToIter(txtViewInfo.Buffer.EndIter, 0, false, 0, 0);
    }

    protected void OnBtnSetLocationClicked(object sender, EventArgs e)
    {
        if (btnSetLocation.Label.Equals("Set Location"))
		{
            if(!SetParkArea(txtLatSetting.Text, txtLonSetting.Text))
            {
                MessageBox.Show("Invalid Latitude or Longitude");
                return;
            }
			btnSetLocation.Label = "Unset Location";
            //isContinueConnection = true;
            //StartConnection();
            isParkSetted = true;
		}
		else
		{
			btnSetLocation.Label = "Set Location";
            //isContinueConnection = false;
            isParkSetted = false;
		}
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

public static class MessageBox
{
	public static void Show(string msg)
	{
		MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Other, ButtonsType.Ok, msg);
		md.Run();
		md.Destroy();
	}
}