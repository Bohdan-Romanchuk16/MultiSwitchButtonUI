using System.Windows;

namespace ArduinoAutomaticHeatingControl;

public partial class MainWindow
{
   private const string ModbusTcpServerIp = "192.168.1.20";

   private readonly ArduinoFinderOptaModbusTcp _opta = new(ModbusTcpServerIp);

   private bool _led1State;

   private bool _led2State;

   public MainWindow()
   {
      InitializeComponent();
      {
         _opta.Connect();

         for (var i = 0; i < 3; i++)
         {

            _opta.SetOutputOn(0);

            Thread.Sleep(100);

            _opta.SetOutputOff(0);

            _opta.SetOutputOn(1);

            Thread.Sleep(100);

            _opta.SetOutputOff(1);

            _opta.SetOutputOn(2);

            Thread.Sleep(100);

            _opta.SetOutputOff(2);

            _opta.SetOutputOn(3);

            Thread.Sleep(100);

            _opta.SetOutputOff(3);
            Thread.Sleep(100);

         }

         //_opta.Disconnect();
      }
   }

   private void Button1_OnClick(object sender, RoutedEventArgs e)
   {
      try
      {
         _opta.Connect();
         _led1State = !_led1State;
         _opta.SetOutputOn(0);
         _opta.SetOutputOff(1);

      }
      catch (Exception ex)
      {
         MessageBox.Show("Fehler: " + ex.Message);
      }

   }

   private void Button2_OnClick(object sender, RoutedEventArgs e)
   {
      try
      {
         _opta.Connect();
         _led2State = !_led2State;
         _opta.SetOutputOn(1);
         _opta.SetOutputOff(0);

      }
      catch (Exception ex)
      {
         MessageBox.Show("Fehler: " + ex.Message);
      }
   }

   private void ButtonAll_OnClick(object sender, RoutedEventArgs e)
   {
      try
      {
         _opta.Connect();
         _led2State = !_led2State;
         _opta.SetOutputOn(0);
         _opta.SetOutputOn(1);

      }
      catch (Exception ex)
      {
         MessageBox.Show("Fehler: " + ex.Message);
      }
   }
}