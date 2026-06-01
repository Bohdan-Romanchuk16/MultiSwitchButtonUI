using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiSwitchButtonUI
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      public void Button1_OnClick(object sender, RoutedEventArgs e)
      {
         Application.Current.Resources.MergedDictionaries.Clear();

         Application.Current.Resources.MergedDictionaries.Add(
             new ResourceDictionary
             {
                Source = new Uri("/Styles/button2_aktiv.xaml", UriKind.Relative)
             });

         Application.Current.Resources.MergedDictionaries.Add(
             new ResourceDictionary
             {
                Source = new Uri("/Styles/button1_unaktiv.xaml", UriKind.Relative)
             });
      }

      public void Button2_OnClick(object sender, RoutedEventArgs e)
      {
         Application.Current.Resources.MergedDictionaries.Clear();

         Application.Current.Resources.MergedDictionaries.Add(
             new ResourceDictionary
             {
                Source = new Uri("/Styles/button2_unaktiv.xaml", UriKind.Relative)
             });

         Application.Current.Resources.MergedDictionaries.Add(
             new ResourceDictionary
             {
                Source = new Uri("/Styles/button1_aktiv.xaml", UriKind.Relative)
             });
      }
   }
}