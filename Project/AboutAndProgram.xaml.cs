using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для AboutAndProgram.xaml
    /// </summary>
    public partial class AboutAndProgram : Window
    {
        public AboutAndProgram()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void irina51a(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/irina51a"); //открытие ссылки в браузере
        }
        void pasha_p2(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/pasha_p2"); //открытие ссылки в браузере
        }
        void id279235945(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/id279235945"); //открытие ссылки в браузере
        }
    }
}
