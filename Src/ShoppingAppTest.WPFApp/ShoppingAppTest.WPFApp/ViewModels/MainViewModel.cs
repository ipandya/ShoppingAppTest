using ShoppingAppTest.Commons;
using ShoppingAppTest.Commons.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ShoppingAppTest.Commons.Utilities;
using System.Windows.Input;
using ShoppingAppTest.WPFApp.Views;
using System.Windows;

namespace ShoppingAppTest.WPFApp.ViewModels
{
    public class MainViewModel : BaseModel
    {
        #region Ctor
        public MainViewModel()
        {

        }
        #endregion

        #region Properties

        private bool _isUserRegistered;
        public bool IsUserRegistered
        {
            get { return _isUserRegistered; }
            set { _isUserRegistered = value; OnPropertyChanged("IsUserRegistered"); }
        }


        private bool _ShowThankYouMessage;
        public bool ShowThankYouMessage
        {
            get { return _ShowThankYouMessage; }
            set { _ShowThankYouMessage = value; OnPropertyChanged("ShowThankYouMessage"); }
        }
        

        ObservableCollection<SelectableProducts> _AllProducts = new ObservableCollection<SelectableProducts>();
        public ObservableCollection<SelectableProducts> AllProducts
        {
            get
            {
                return _AllProducts;
            }
            set
            {
                _AllProducts = value;
                OnPropertyChanged("AllProducts");
            }
        }

        private SelectableProducts _selectProduct;
        public SelectableProducts SelectedProduct
        {
            get { return _selectProduct; }
            set { _selectProduct = value; OnPropertyChanged("SelectedProduct"); }
        }


        private ObservableCollection<SelectableProducts> _ProductsInCart = new ObservableCollection<SelectableProducts>();
        public ObservableCollection<SelectableProducts> ProdutcsInCart
        {
            get { return _ProductsInCart; }
            set { _ProductsInCart = value; OnPropertyChanged("ProdutcsInCart"); }
        }

        public decimal TotalAmountForCart
        {
            get
            {
                decimal price = 0;
                foreach (SelectableProducts product in ProdutcsInCart)
                {
                    price += product.SubTotal;
                }
                return price + TotalVATOnAmountForCart;
            }
        }

        public decimal TotalAmountForCartWithoutVAT
        {
            get
            {
                decimal price = 0;
                foreach (SelectableProducts product in ProdutcsInCart)
                {
                    price += product.SubTotal;
                }
                return price;
            }
        }


        public decimal TotalVATOnAmountForCart
        {
            get
            {
                decimal price = 0;
                foreach (SelectableProducts product in ProdutcsInCart)
                {
                    price += product.SubTotal;
                }

                return price * 20 / 100;
            }
        }

        public long CartItemsCount
        {
            get { return _ProductsInCart.Count; }
        }



        #endregion

        #region Commands
        private DelegateCommand _ShowProductDetailsCommand;
        public ICommand ShowProductDetailsCommand
        {
            get
            {
                if (_ShowProductDetailsCommand == null)
                {
                    _ShowProductDetailsCommand = new DelegateCommand(OnShowProductDetailsCommandInvoked);
                }
                return _ShowProductDetailsCommand;
            }
        }

        void OnShowProductDetailsCommandInvoked(object productObj)
        {
            try
            {
                #region Show product details
                if (productObj != null)
                {
                    SelectableProducts selectedProduct = productObj as SelectableProducts;

                    if (selectedProduct == null)
                        return;

                    ProductDetailsWin prodDetWin = new ProductDetailsWin();
                    prodDetWin.Owner = App.Current.MainWindow;
                    prodDetWin.DataContext = selectedProduct;
                    prodDetWin.WindowState = System.Windows.WindowState.Maximized;
                    prodDetWin.ShowDialog();
                }
                #endregion
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
        }

        private DelegateCommand _AddItemToCartCommand;
        public ICommand AddItemToCartCommand
        {
            get
            {
                if (_AddItemToCartCommand == null)
                {
                    _AddItemToCartCommand = new DelegateCommand(OnAddItemToCartCommandInvoked);
                }
                return _AddItemToCartCommand;
            }
        }

        void OnAddItemToCartCommandInvoked(object productObj)
        {
            try
            {
                #region Add Item to cart
                if (productObj != null)
                {
                    SelectableProducts selectedProduct = productObj as SelectableProducts;

                    if (selectedProduct == null)
                        return;

                    SelectableProducts itemAlreadyInCart = this.ProdutcsInCart.Where(p => p.ProductID == selectedProduct.ProductID).FirstOrDefault();
                    if (itemAlreadyInCart == null)
                    {
                        this.ProdutcsInCart.Add(selectedProduct);
                        OnPropertyChanged("ProdutcsInCart");
                        OnPropertyChanged("CartItemsCount");
                        OnPropertyChanged("TotalVATOnAmountForCart");
                        OnPropertyChanged("TotalAmountForCart");
                        OnPropertyChanged("TotalAmountForCartWithoutVAT");
                    }
                    else
                    {
                        MessageBox.Show("Item Already in Cart");
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
        }


        private DelegateCommand _ShowCartItemsCommand;
        public ICommand ShowCartItemsCommand
        {
            get
            {
                if (_ShowCartItemsCommand == null)
                {
                    _ShowCartItemsCommand = new DelegateCommand(OnAShowCartItemsCommandInvoked);
                }
                return _ShowCartItemsCommand;
            }
        }

        void OnAShowCartItemsCommandInvoked(object productObj)
        {
            try
            {
                #region Show Cart
                CartWindow cartWin = new CartWindow();
                cartWin.DataContext = this;
                cartWin.Owner = App.Current.MainWindow;
                cartWin.ShowDialog();
                ShowThankYouMessage = false;
                #endregion
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
        }



        private DelegateCommand _RegisterUserCommand;
        public ICommand RegisterUserCommand
        {
            get
            {
                if (_RegisterUserCommand == null)
                {
                    _RegisterUserCommand = new DelegateCommand(OnRegisterUserCommandInvoked);
                }
                return _RegisterUserCommand;
            }
        }

        async void OnRegisterUserCommandInvoked(object userObj)
        {
            try
            {
               if(userObj != null)
               {
                   SelectableCustomer customer = userObj as SelectableCustomer;

                   if (customer == null)
                       return;

                   Task<bool> result = RegisterUser(customer);
                   IsUserRegistered = result.Result;
               }
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
        }



        private DelegateCommand _CheckOutCartItemsCommand;
        public ICommand CheckOutCartItemsCommand
        {
            get
            {
                if (_CheckOutCartItemsCommand == null)
                {
                    _CheckOutCartItemsCommand = new DelegateCommand(OnCheckOutCartItemsCommandInvoked);
                }
                return _CheckOutCartItemsCommand;
            }
        }

        void OnCheckOutCartItemsCommandInvoked(object productObj)
        {
            try
            {
                bool dialogResult = false;
                #region Checkout content of cart
               
                if(!IsUserRegistered)
                {
                    RegisterUserWin registerUserWin = new RegisterUserWin(this);
                    dialogResult = registerUserWin.ShowDialog().Value;
                }

                if(dialogResult)
                {
                    this.ProdutcsInCart.Clear();
                    OnPropertyChanged("ProdutcsInCart");
                    OnPropertyChanged("CartItemsCount");
                    OnPropertyChanged("TotalVATOnAmountForCart");
                    OnPropertyChanged("TotalAmountForCart");
                    OnPropertyChanged("TotalAmountForCartWithoutVAT");
                    ShowThankYouMessage = true;
                }



                #endregion
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
        }

        private DelegateCommand _RemoveItemToCartCommand;
        public ICommand RemoveItemToCartCommand
        {
            get
            {
                if (_RemoveItemToCartCommand == null)
                {
                    _RemoveItemToCartCommand = new DelegateCommand(OnRemoveItemToCartCommandInvoked);
                }
                return _RemoveItemToCartCommand;
            }
        }

        void OnRemoveItemToCartCommandInvoked(object productObj)
        {
            try
            {
                #region Add Item to cart
                if (productObj != null)
                {
                    SelectableProducts selectedProduct = productObj as SelectableProducts;

                    if (selectedProduct == null)
                        return;

                    SelectableProducts itemAlreadyInCart = this.ProdutcsInCart.Where(p => p.ProductID == selectedProduct.ProductID).FirstOrDefault();
                    if (itemAlreadyInCart != null)
                    {
                        this.ProdutcsInCart.Remove(selectedProduct);
                        OnPropertyChanged("ProdutcsInCart");
                        OnPropertyChanged("CartItemsCount");
                        OnPropertyChanged("TotalVATOnAmountForCart");
                        OnPropertyChanged("TotalAmountForCart");
                        OnPropertyChanged("TotalAmountForCartWithoutVAT");
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
        }
        #endregion

        #region Methods
        public async Task FetchAllProducts()
        {
            try
            {
                #region Fetch All Products
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync(Constants.GET_ALL_PRODUCTS);
                    if (response.IsSuccessStatusCode)
                    {
                        List<SelectableProducts> products = await response.Content.ReadAsAsync<List<SelectableProducts>>();
                        this.AllProducts = products.ToObservableCollection();
                        GlobalExceptionHandling.WriteTraceLogs("Products Fetched " + this.AllProducts.Count);
                    }
                    else
                    {
                        GlobalExceptionHandling.WriteTraceLogs("Failed Fetching Products ");
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
        }


        public async Task<bool> RegisterUser(SelectableCustomer user)
        {
            try
            {
                #region Register User
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    //HttpResponseMessage response = await client.GetAsync(Constants.GET_ALL_PRODUCTS);
                    var response = client.PostAsJsonAsync(new Uri(Constants.POST_CUSTOMER), user).Result;
                    if(response.IsSuccessStatusCode)
                    {
                        Uri gizmoUrl = response.Headers.Location;
                        return true;
                    }
                    
                }
                #endregion
            }
            catch (Exception ex)
            {
                GlobalExceptionHandling.WriteTraceLogs(ex.ToString());
            }
            return false;
        }
        #endregion


    }
}
