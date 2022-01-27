#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataVirtualization;

#endregion

namespace DVFilterSort
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerProvider customerProvider;
        private int pageSize = 100;
        private int timePageInMemory = 5000;

        public MainWindow()
        {
            InitializeComponent();

            RefreshData();
        }

        private void RefreshData()
        {
            customerProvider = new CustomerProvider();
            var customerList = new AsyncVirtualizingCollection<Customer>(customerProvider, pageSize, timePageInMemory);
            DataContext = customerList;
        }
    }
}