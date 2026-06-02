using System.Windows;
using System.Windows.Media;

namespace MultiSwitchButtonUI
{
   public partial class MainWindow : Window
   {
      public bool Led1Active { get; private set; }
      public bool Led2Active { get; private set; }

      public MainWindow()
      {
         InitializeComponent();
         SetState(false, false);
      }

      public void Button1_OnClick(object sender, RoutedEventArgs e)
      {
         SetState(true, false);
      }

      public void Button2_OnClick(object sender, RoutedEventArgs e)
      {
         SetState(false, true);
      }

      public void ButtonAll_OnClick(object sender, RoutedEventArgs e)
      {
         SetState(true, true);
      }

      public void SetState(bool led1, bool led2)
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