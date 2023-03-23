using Lab_4.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab_4.MVVM.ViewModel
{
    public class AddProductViewModel : ObservableObject
    {
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set
            {
                _shortName = value;
                OnPropertyChanged();
            }
        }
        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public bool CheckClothing { get; set; }
        public bool CheckAccessories { get; set; }
        public bool CheckOther { get; set; }
        public bool InStock { get; set; }
        public RelayCommand Exit { get; set; }

        public MainViewModel MainViewModel { get; set; }
        public RelayCommand AddProduct { get; set; }

        public AddProductViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;

            ImagePath = "../../Images/noimg.png";

            CheckClothing = true;

            AddProduct = new RelayCommand(obj =>
            {
                Core.Product product = new Product();
                
                
                double price = 0;
                try
                {
                    price = Convert.ToDouble(Price);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!", ex.Message);
                    return;
                }
                product.Price = price;

                if (price <= 0 || price > 1000) { MessageBox.Show("Error!", "Неправильный диапазон цены"); return; }
                else { product.Price = price; }

                if (Int32.TryParse(Name, out int res3)) { MessageBox.Show("Error!", "Неправильное имя!"); return; }
                else { product.Name = Name; }

                if (Int32.TryParse(ShortName, out int res4)) { MessageBox.Show("Error!", "Неправильное короткое имя!"); return; }
                else { product.ShortName = ShortName; }

                product.ImagePath = ImagePath;
                product.InStock = InStock;

                if (CheckClothing == true)
                {
                    product.Category = Product.Categories.Clothing;
                }
                if (CheckAccessories == true)
                {
                    product.Category = Product.Categories.Accessories;
                }
                if (CheckOther == true)
                {
                    product.Category = Product.Categories.Other;
                }

                MainViewModel.Products.Add(product);
                MainViewModel.FilterProducts();
                MainViewModel.SerializeProducts();
                MainViewModel.CurrentView = MainViewModel.ProductVM;
            });
            Exit = new RelayCommand(obj =>
            {
                MainViewModel.CurrentView = MainViewModel.ProductVM;
            });
        }
    }
}
