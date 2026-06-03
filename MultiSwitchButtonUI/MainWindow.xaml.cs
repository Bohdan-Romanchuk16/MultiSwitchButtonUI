using System.Windows;
using System.Windows.Media;

namespace MultiSwitchButtonUI
{
   public partial class MainWindow : Window
   {                                                                            //Alle Methoden sowie Zeile 8+9 würde ich von public auf privat setzen. 
      public bool Led1Active { get; private set; }                              // "privat bool"  
      public bool Led2Active { get; private set; }                              // "privat bool"

      public MainWindow()
      {
         InitializeComponent();
         SetState(false, false);
      }

      public void Button1_OnClick(object sender, RoutedEventArgs e)           // "privat void"
      {
         if (Led1Active == false)                                        //Hier könnte man ein if (!Led1Active) setzen
         {
            SetState(true, false);
         }
         else
         {
            SetState(false, false);
         }
      }

      public void Button2_OnClick(object sender, RoutedEventArgs e)                      // "privat void"
      {
         if (Led2Active == false)                                                    //Hier könnte man ein if (!Led2Active) setzen
         { 
            SetState(false, true);
         }
         else
         {
            SetState(false, false);
         }
      }

      public void ButtonAll_OnClick(object sender, RoutedEventArgs e)                      // "privat void"
      {
         SetState(true, true);
      }

      public void SetState(bool led1, bool led2)                                           // "privat void"
      {
         Led1Active = led1;
         Led2Active = led2;

         Button1.Background = led1 ? Brushes.LightGreen : Brushes.White;
         Button2.Background = led2 ? Brushes.LightGreen : Brushes.White;

         ButtonAll.Background = (led1 && led2)
             ? Brushes.LightBlue
             : Brushes.White;
      }
   }
}