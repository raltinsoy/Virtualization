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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private CustomerProvider customerProvider;
        private int pageSize = 100;
        private int timePageInMemory = 5000;

        private DataWrapper<Customer> _selected;
        public DataWrapper<Customer> Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public VirtualizingCollection<Customer> customerList { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            RefreshData();

            DataContext = this;
        }

        private void RefreshData()
        {
            customerProvider = new CustomerProvider();
            customerList = new VirtualizingCollection<Customer>(customerProvider, pageSize, timePageInMemory);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = Convert.ToInt32(selectedIndexTxt.Text);
                //TODO: buraya dikkat, eğer arama uzunsa sayfayı yüklemeye çalışıyor ve uzun sürüyor
                //var found = customerList.FirstOrDefault(x => x.Data.Id == index);
                var found = customerList[index];
                if (found != null)
                {
                    Selected = found;
                }

                Console.WriteLine("Found: " + found != null + " Index: " + index);
            }
            catch (Exception)
            {
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}