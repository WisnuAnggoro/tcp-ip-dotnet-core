
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;

	private global::Gtk.Frame frame1;

	private global::Gtk.Alignment GtkAlignment;

	private global::Gtk.VBox vbox2;

	private global::Gtk.HBox hbox4;

	private global::Gtk.Label label7;

	private global::Gtk.Entry txtHost;

	private global::Gtk.Button btnChokeConnect;

	private global::Gtk.Label lblAverageChokePosition;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TextView txtViewInfo;

	private global::Gtk.Label frameChokePosition;

	private global::Gtk.Frame frame2;

	private global::Gtk.Alignment GtkAlignment1;

	private global::Gtk.VBox vbox4;

	private global::Gtk.HBox hbox7;

	private global::Gtk.VBox vbox5;

	private global::Gtk.HBox hbox8;

	private global::Gtk.Label label12;

	private global::Gtk.Entry txtLatSetting;

	private global::Gtk.HBox hbox9;

	private global::Gtk.Label label13;

	private global::Gtk.Entry txtLonSetting;

	private global::Gtk.HBox hbox10;

	private global::Gtk.Label label16;

	private global::Gtk.Entry txtRadius;

	private global::Gtk.Button btnSetLocation;

	private global::Gtk.Label lblDistance;

	private global::Gtk.Label lblParkingStatus;

	private global::Gtk.Label GtkLabel2;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		this.DefaultWidth = 800;
		this.DefaultHeight = 600;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		this.vbox1.BorderWidth = ((uint)(5));
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame1 = new global::Gtk.Frame();
		this.frame1.Name = "frame1";
		this.frame1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.label7 = new global::Gtk.Label();
		this.label7.Name = "label7";
		this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("API Address:");
		this.hbox4.Add(this.label7);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label7]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.txtHost = new global::Gtk.Entry();
		this.txtHost.CanFocus = true;
		this.txtHost.Name = "txtHost";
		this.txtHost.Text = global::Mono.Unix.Catalog.GetString("http://35.197.144.181/gps_api/get");
		this.txtHost.IsEditable = true;
		this.txtHost.InvisibleChar = '•';
		this.hbox4.Add(this.txtHost);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.txtHost]));
		w2.Position = 1;
		this.vbox2.Add(this.hbox4);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.btnChokeConnect = new global::Gtk.Button();
		this.btnChokeConnect.CanFocus = true;
		this.btnChokeConnect.Name = "btnChokeConnect";
		this.btnChokeConnect.UseUnderline = true;
		this.btnChokeConnect.BorderWidth = ((uint)(2));
		this.btnChokeConnect.Label = global::Mono.Unix.Catalog.GetString("Connect");
		this.vbox2.Add(this.btnChokeConnect);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.btnChokeConnect]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.lblAverageChokePosition = new global::Gtk.Label();
		this.lblAverageChokePosition.Name = "lblAverageChokePosition";
		this.lblAverageChokePosition.Ypad = 20;
		this.lblAverageChokePosition.LabelProp = global::Mono.Unix.Catalog.GetString("{init}");
		this.vbox2.Add(this.lblAverageChokePosition);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.lblAverageChokePosition]));
		w5.Position = 2;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.txtViewInfo = new global::Gtk.TextView();
		this.txtViewInfo.CanFocus = true;
		this.txtViewInfo.Name = "txtViewInfo";
		this.txtViewInfo.Editable = false;
		this.GtkScrolledWindow.Add(this.txtViewInfo);
		this.vbox2.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
		w7.Position = 3;
		this.GtkAlignment.Add(this.vbox2);
		this.frame1.Add(this.GtkAlignment);
		this.frameChokePosition = new global::Gtk.Label();
		this.frameChokePosition.Name = "frameChokePosition";
		this.frameChokePosition.Xpad = 2;
		this.frameChokePosition.Ypad = 2;
		this.frameChokePosition.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Choke Position</b>");
		this.frameChokePosition.UseMarkup = true;
		this.frame1.LabelWidget = this.frameChokePosition;
		this.vbox1.Add(this.frame1);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.frame1]));
		w10.Position = 0;
		w10.Padding = ((uint)(2));
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame2 = new global::Gtk.Frame();
		this.frame2.Name = "frame2";
		this.frame2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child frame2.Gtk.Container+ContainerChild
		this.GtkAlignment1 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment1.Name = "GtkAlignment1";
		this.GtkAlignment1.LeftPadding = ((uint)(12));
		// Container child GtkAlignment1.Gtk.Container+ContainerChild
		this.vbox4 = new global::Gtk.VBox();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		// Container child vbox4.Gtk.Box+BoxChild
		this.hbox7 = new global::Gtk.HBox();
		this.hbox7.Name = "hbox7";
		this.hbox7.Spacing = 6;
		// Container child hbox7.Gtk.Box+BoxChild
		this.vbox5 = new global::Gtk.VBox();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbox8 = new global::Gtk.HBox();
		this.hbox8.Name = "hbox8";
		this.hbox8.Spacing = 6;
		// Container child hbox8.Gtk.Box+BoxChild
		this.label12 = new global::Gtk.Label();
		this.label12.Name = "label12";
		this.label12.LabelProp = global::Mono.Unix.Catalog.GetString("Latitude:");
		this.hbox8.Add(this.label12);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.label12]));
		w11.Position = 0;
		w11.Expand = false;
		w11.Fill = false;
		// Container child hbox8.Gtk.Box+BoxChild
		this.txtLatSetting = new global::Gtk.Entry();
		this.txtLatSetting.CanFocus = true;
		this.txtLatSetting.Name = "txtLatSetting";
		this.txtLatSetting.IsEditable = true;
		this.txtLatSetting.InvisibleChar = '•';
		this.hbox8.Add(this.txtLatSetting);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.txtLatSetting]));
		w12.Position = 1;
		this.vbox5.Add(this.hbox8);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox8]));
		w13.Position = 0;
		w13.Expand = false;
		w13.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbox9 = new global::Gtk.HBox();
		this.hbox9.Name = "hbox9";
		this.hbox9.Spacing = 6;
		// Container child hbox9.Gtk.Box+BoxChild
		this.label13 = new global::Gtk.Label();
		this.label13.Name = "label13";
		this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("Longitude:");
		this.hbox9.Add(this.label13);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.label13]));
		w14.Position = 0;
		w14.Expand = false;
		w14.Fill = false;
		// Container child hbox9.Gtk.Box+BoxChild
		this.txtLonSetting = new global::Gtk.Entry();
		this.txtLonSetting.CanFocus = true;
		this.txtLonSetting.Name = "txtLonSetting";
		this.txtLonSetting.IsEditable = true;
		this.txtLonSetting.InvisibleChar = '•';
		this.hbox9.Add(this.txtLonSetting);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.txtLonSetting]));
		w15.Position = 1;
		this.vbox5.Add(this.hbox9);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox9]));
		w16.Position = 1;
		w16.Expand = false;
		w16.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbox10 = new global::Gtk.HBox();
		this.hbox10.Name = "hbox10";
		this.hbox10.Spacing = 6;
		// Container child hbox10.Gtk.Box+BoxChild
		this.label16 = new global::Gtk.Label();
		this.label16.Name = "label16";
		this.label16.LabelProp = global::Mono.Unix.Catalog.GetString("Radius (in meters):");
		this.hbox10.Add(this.label16);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.label16]));
		w17.Position = 0;
		w17.Expand = false;
		w17.Fill = false;
		// Container child hbox10.Gtk.Box+BoxChild
		this.txtRadius = new global::Gtk.Entry();
		this.txtRadius.CanFocus = true;
		this.txtRadius.Name = "txtRadius";
		this.txtRadius.IsEditable = true;
		this.txtRadius.InvisibleChar = '•';
		this.hbox10.Add(this.txtRadius);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.txtRadius]));
		w18.Position = 1;
		this.vbox5.Add(this.hbox10);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox10]));
		w19.Position = 2;
		w19.Expand = false;
		w19.Fill = false;
		this.hbox7.Add(this.vbox5);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.vbox5]));
		w20.Position = 0;
		// Container child hbox7.Gtk.Box+BoxChild
		this.btnSetLocation = new global::Gtk.Button();
		this.btnSetLocation.CanFocus = true;
		this.btnSetLocation.Name = "btnSetLocation";
		this.btnSetLocation.UseUnderline = true;
		this.btnSetLocation.Label = global::Mono.Unix.Catalog.GetString("Set Location");
		this.hbox7.Add(this.btnSetLocation);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.btnSetLocation]));
		w21.Position = 1;
		w21.Expand = false;
		w21.Fill = false;
		w21.Padding = ((uint)(2));
		this.vbox4.Add(this.hbox7);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox7]));
		w22.Position = 0;
		w22.Expand = false;
		w22.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.lblDistance = new global::Gtk.Label();
		this.lblDistance.Name = "lblDistance";
		this.lblDistance.Ypad = 8;
		this.lblDistance.LabelProp = global::Mono.Unix.Catalog.GetString("{init}");
		this.vbox4.Add(this.lblDistance);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.lblDistance]));
		w23.Position = 1;
		w23.Expand = false;
		w23.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.lblParkingStatus = new global::Gtk.Label();
		this.lblParkingStatus.Name = "lblParkingStatus";
		this.lblParkingStatus.Ypad = 29;
		this.lblParkingStatus.LabelProp = global::Mono.Unix.Catalog.GetString("{init}");
		this.vbox4.Add(this.lblParkingStatus);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.lblParkingStatus]));
		w24.Position = 2;
		w24.Expand = false;
		w24.Fill = false;
		this.GtkAlignment1.Add(this.vbox4);
		this.frame2.Add(this.GtkAlignment1);
		this.GtkLabel2 = new global::Gtk.Label();
		this.GtkLabel2.Name = "GtkLabel2";
		this.GtkLabel2.Xpad = 2;
		this.GtkLabel2.Ypad = 2;
		this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Setting Park Area</b>");
		this.GtkLabel2.UseMarkup = true;
		this.frame2.LabelWidget = this.GtkLabel2;
		this.vbox1.Add(this.frame2);
		global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.frame2]));
		w27.Position = 1;
		w27.Expand = false;
		w27.Fill = false;
		w27.Padding = ((uint)(2));
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.btnChokeConnect.Clicked += new global::System.EventHandler(this.OnBtnChokeConnectClicked);
		this.txtViewInfo.SizeAllocated += new global::Gtk.SizeAllocatedHandler(this.OnTxtViewInfoSizeAllocated);
		this.btnSetLocation.Clicked += new global::System.EventHandler(this.OnBtnSetLocationClicked);
	}
}
