using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace procesamiento_asincrono_davisbd100
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

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            Camarero camarero = new Camarero();
            tblStatus.Text = "Llegue al bar";
            var waitTask = camarero.Wait();
            waitTask.Start();
            await waitTask;

            tblStatus.Text = "Me sente junto a mi amigo";
            waitTask = camarero.Wait();
            waitTask.Start();
            await waitTask;

            tblStatus.Text = "Pedi una cerveza";
            waitTask = camarero.Wait();
            waitTask.Start();
            await waitTask;

            tblSay.Text = DateTime.Now.ToString();
            var task = camarero.ServeBeer("Root Beer");
            task.Start();
            tblStatus.Text = "Charlando";
            var beer = await task;
            tblGet.Text = DateTime.Now.ToString();
            tblStatus.Text = "Brindando";
        }
        class Camarero
        {
            public Task<String> ServeBeer(String name)
            {
                return new Task<String>(() =>
                {
                    GoToStorage();
                    return name;
                });
            }
            public Task Wait()
            {
                return new Task(() =>
                {
                    WaitForSeconds();
                });
            }
            void WaitForSeconds()
            {
                Thread.Sleep(4000);
            }
            void GoToStorage()
            {
                for (int i = 0; i < 60; i++)
                {
                    Thread.Sleep(100);
                }
            }
            
        }
    }
}
