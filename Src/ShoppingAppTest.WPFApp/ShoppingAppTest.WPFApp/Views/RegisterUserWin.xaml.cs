using ShoppingAppTest.Commons;
using ShoppingAppTest.Commons.Models;
using ShoppingAppTest.WPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShoppingAppTest.WPFApp.Views
{
    /// <summary>
    /// Interaction logic for RegisterUserWin.xaml
    /// </summary>
    public partial class RegisterUserWin : Window
    {

        MainViewModel mainViewModel;
        SelectableCustomer newCustomer;

        public RegisterUserWin()
        {
            InitializeComponent();
        }

        public RegisterUserWin(MainViewModel _MainViewModel)
        {
            try
            {
                InitializeComponent();

                this.mainViewModel = _MainViewModel;
                this.newCustomer = new SelectableCustomer();
                this.DataContext = this.newCustomer;
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteExceptionLog(ex);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string validationError = string.Empty;
            try
            {
                if (ValidateData(out validationError))
                {
                    this.mainViewModel.RegisterUserCommand.Execute(this.newCustomer);
                }
                else
                {
                    if(!string.IsNullOrEmpty(validationError))
                    {
                        MessageBox.Show(validationError);
                    }
                    else
                    {
                        MessageBox.Show("Unknown Error");
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteExceptionLog(ex);
            }
        }

        private bool ValidateData(out string validationError)
        {
            validationError = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(this.newCustomer.CustomerFName))
                {
                    validationError = "Please enter First Name";
                    return false;
                }


                if (string.IsNullOrEmpty(this.newCustomer.CustomerLName))
                {
                    validationError = "Please enter Last Name";
                    return false;
                }


                if (string.IsNullOrEmpty(this.newCustomer.ZipCode))
                {
                    validationError = "Please enter Zip code";
                    return false;
                }

                if (string.IsNullOrEmpty(this.newCustomer.City))
                {
                    validationError = "Please enter City";
                    return false;
                }


                if (string.IsNullOrEmpty(this.newCustomer.EmailAddress))
                {
                    validationError = "Please enter Email";
                    return false;
                }

                bool validEmail = Regex.IsMatch(this.newCustomer.EmailAddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!validEmail)
                {
                    validationError = "Please enter valid Email";
                    return false;
                }


            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteExceptionLog(ex);
            }

            return true;
        }
    }
}
