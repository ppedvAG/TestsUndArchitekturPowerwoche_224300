using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Reflection;

namespace BooksManager.UI.Tests
{
    public class MainWindowTests
    {
        [Fact]
        public void Can_show_Demodata()
        {
            var appPath = typeof(MainWindow).Assembly.Location.Replace("dll", "exe");

            var app = FlaUI.Core.Application.Launch(appPath);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                var button1 = window.FindFirstDescendant(cf => cf.ByAutomationId("b1"))?.AsButton();
                button1?.Click();

                var grid = window.FindFirstDescendant(x => x.ByAutomationId("g1")).AsGrid();
                Assert.NotEqual(0, grid.RowCount);
            }

            app.Close();
        }
    }
}
