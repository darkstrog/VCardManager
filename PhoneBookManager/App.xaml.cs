﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBookManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            string fileName = e.Args?.FirstOrDefault();
            MainWindow mainWindow;

            if (fileName!=null)
                mainWindow = new MainWindow(fileName);
            else
                mainWindow = new MainWindow();
            
            mainWindow.Show();
            
        }
    }
}
