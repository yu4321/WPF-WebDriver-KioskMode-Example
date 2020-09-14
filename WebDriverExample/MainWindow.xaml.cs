using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebDriverExample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        IWebDriver driverNaver = null;
        IWebDriver driverGoogle = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            driverNaver.SwitchTo().Window(driverNaver.CurrentWindowHandle);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            driverGoogle.SwitchTo().Window(driverGoogle.CurrentWindowHandle);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            driverNaver.Url = "http://www.naver.com";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            driverGoogle.Url = "http://google.com";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            driverNaver.Manage().Window.Size = new System.Drawing.Size(960, 540);
            driverGoogle.Manage().Window.Size = new System.Drawing.Size(960, 540);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            driverNaver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driverGoogle.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--kiosk");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);

            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            driverNaver = new ChromeDriver(service, options);
            driverGoogle = new ChromeDriver(service, options);
            driverNaver.Url = "http://www.naver.com";
            driverGoogle.Url = "http://google.com";

            //Button_Click_4(null, null);
            Button_Click(null, null);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (driverNaver != null)
            {
                driverNaver.Close();
                driverNaver.Dispose();
            }

            if (driverGoogle != null)
            {
                driverGoogle.Close();
                driverGoogle.Dispose();
            }
        }
    }
}
