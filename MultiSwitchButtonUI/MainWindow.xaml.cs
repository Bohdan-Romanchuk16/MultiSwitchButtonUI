using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Media;

namespace MultiSwitchButtonUI
{
   public partial class MainWindow : Window
   {                                                                            //Alle Methoden sowie Zeile 8+9 würde ich von public auf privat setzen. 
      public bool Led1Active { get; private set; }                              // "privat bool"  
      public bool Led2Active { get; private set; }                              // "privat bool"

      private SerialPort arduinoPort;

      public MainWindow()
      {
         InitializeComponent();
         SetState(false, false);

         arduinoPort = new SerialPort("COM5", 9600);

         arduinoPort.DtrEnable = true; 
         arduinoPort.RtsEnable = true;  
         arduinoPort.WriteTimeout = 1500;
         arduinoPort.ReadTimeout = 1500;

         try
         {
            arduinoPort.Open();

            System.Threading.Thread.Sleep(2000);

            arduinoPort.Write("0");
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Fehler beim Öffnen von COM5: {ex.Message}");
         }
      }

      public void Button1_OnClick(object sender, RoutedEventArgs e)           // "privat void"
      {
         if (!arduinoPort.IsOpen) return;

         if (Led1Active == false)
         {
            arduinoPort.Write("1"); 
            SetState(true, Led2Active);
         }
         else
         {
            arduinoPort.Write("0");
            SetState(false, Led2Active);
         }
      }

      public void Button2_OnClick(object sender, RoutedEventArgs e)                      // "privat void"
      {
         if (!arduinoPort.IsOpen) return;

         if (Led2Active == false)
         {
            arduinoPort.Write("2");
            SetState(Led1Active, true);
         }
         else
         {
            arduinoPort.Write("3");
            SetState(Led1Active, false);
         }
      }

      public void ButtonAll_OnClick(object sender, RoutedEventArgs e)                      // "privat void"
      {
         if (!arduinoPort.IsOpen) return;

         arduinoPort.Write("4");
         SetState(true, true);
      }

      public void SetState(bool led1, bool led2)                                           // "privat void"
      {
         Led1Active = led1;
         Led2Active = led2;

         Button1.Background = led1 ? Brushes.LightGreen : Brushes.White;
         Button2.Background = led2 ? Brushes.LightGreen : Brushes.White;

         ButtonAll.Background = (led1 && led2) ? Brushes.LightBlue : Brushes.White;
      }

      protected override void OnClosed(EventArgs e)
      {
         if (arduinoPort != null && arduinoPort.IsOpen)
         {
            arduinoPort.Close();
         }
         base.OnClosed(e);
      }
   }
}
