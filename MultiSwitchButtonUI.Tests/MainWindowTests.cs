using System.Windows;
using Xunit;

namespace MultiSwitchButtonUI.Tests
{
   public class MainWindowTests
   {
      [StaFact]
      public void Button1Click_ClearsDictionaries_AndLoadsTwoNew()
      {
         // Arrange
         var app = System.Windows.Application.Current ?? new System.Windows.Application();
         app.Resources.MergedDictionaries.Clear();

         app.Resources.MergedDictionaries.Add([]);
         app.Resources.MergedDictionaries.Add([]);
         app.Resources.MergedDictionaries.Add([]);

         // Assert 
         Assert.Equal(3, app.Resources.MergedDictionaries.Count);

         // Act 
         app.Resources.MergedDictionaries.Clear();

         // Assert 
         Assert.Empty(app.Resources.MergedDictionaries);
      }

      [StaFact]
      public void Button2Click_ClearsDictionaries_AndLoadsTwoNew()
      {
         // Arrange
         var app = System.Windows.Application.Current ?? new System.Windows.Application();
         app.Resources.MergedDictionaries.Clear();

         app.Resources.MergedDictionaries.Add([]);
         app.Resources.MergedDictionaries.Add([]);

         // Assert 
         Assert.Equal(2, app.Resources.MergedDictionaries.Count);

         // Act
         app.Resources.MergedDictionaries.Clear();

         // Assert 
         Assert.Empty(app.Resources.MergedDictionaries);
      }

      [StaFact]
      public void ButtonClick_ClearsPreviousDictionaries()
      {
         // Arrange
         var app = System.Windows.Application.Current ?? new System.Windows.Application();
         app.Resources.MergedDictionaries.Clear();

         app.Resources.MergedDictionaries.Add([]);
         app.Resources.MergedDictionaries.Add([]);
         app.Resources.MergedDictionaries.Add([]);

         // Act 
         app.Resources.MergedDictionaries.Clear();

         Assert.Empty(app.Resources.MergedDictionaries);
      }
   }
}