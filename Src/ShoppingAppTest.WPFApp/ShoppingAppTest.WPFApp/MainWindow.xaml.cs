using ShoppingAppTest.WPFApp.ViewModels;
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

namespace ShoppingAppTest.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel _appVM;
        public MainViewModel AppVM
        {
            get
            {
                if (_appVM == null)
                {
                    _appVM = new MainViewModel();
                }
                return _appVM;
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = AppVM;
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AppVM.FetchAllProducts();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
