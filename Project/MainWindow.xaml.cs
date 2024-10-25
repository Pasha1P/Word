﻿using System;
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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            Project_2 project_2 = new Project_2();
            project_2.Show();

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Exit2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Entrance2_Click(object sender, RoutedEventArgs e)
        {
            Project_2 project_2 = new Project_2();
            project_2.Show();
        }
        
        private void AboutAndProgram_Click(object sender, RoutedEventArgs e)
        {
            AboutAndProgram aboutAndProgram = new AboutAndProgram();
            aboutAndProgram.Show();
        }
    }
}
