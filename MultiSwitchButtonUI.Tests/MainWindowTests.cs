using System.Windows;
using Xunit;

namespace MultiSwitchButtonUI.Tests
{
   public class MainWindowTests
   {
      [StaFact]
      public void Button1Click_ActivatesOnlyLed1()
      {
         // Arrange
         var window = new MainWindow();

         // Act
         window.Button1_OnClick(null, null);

         // Assert
         Assert.True(window.Led1Active);
         Assert.False(window.Led2Active);
      }

      [StaFact]
      public void Button2Click_ActivatesOnlyLed2()
      {
         // Arrange
         var window = new MainWindow();

         // Act
         window.Button2_OnClick(null, null);

         // Assert
         Assert.False(window.Led1Active);
         Assert.True(window.Led2Active);
      }

      [StaFact]
      public void AllButtonClick_ActivatesBothLeds()
      {
         // Arrange
         var window = new MainWindow();

         // Act
         window.ButtonAll_OnClick(null, null);

         // Assert
         Assert.True(window.Led1Active);
         Assert.True(window.Led2Active);
      }

      [StaFact]
      public void Button1AfterAll_ActivatesOnlyLed1()
      {
         // Arrange
         var window = new MainWindow();

         window.ButtonAll_OnClick(null, null);

         // Act
         window.Button1_OnClick(null, null);

         // Assert
         Assert.True(window.Led1Active);
         Assert.False(window.Led2Active);
      }

      [StaFact]
      public void Button2AfterAll_ActivatesOnlyLed2()
      {
         // Arrange
         var window = new MainWindow();

         window.ButtonAll_OnClick(null, null);

         // Act
         window.Button2_OnClick(null, null);

         // Assert
         Assert.False(window.Led1Active);
         Assert.True(window.Led2Active);
      }
   }
}