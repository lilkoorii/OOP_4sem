﻿using Lab_4.Core;
using Lab_4.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab_4.MVVM.ViewModel
{
    public class EditProductViewModel : ObservableObject
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

        public MainViewModel MainViewModel { get; set; }
        public RelayCommand SaveProduct { get; set; }
        public RelayCommand DeleteProduct { get; set; }
        public RelayCommand Exit { get; set; }

        public EditProductViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;

            ImagePath = "../../Images/noimg.png";

            CheckClothing = true;

            SaveProduct = new RelayCommand(obj =>
            {
                Core.Product product = mainViewModel.ProductToEdit;

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

                MainViewModel.FilterProducts();
                MainViewModel.SerializeProducts();
                MainViewModel.CurrentView = MainViewModel.ProductVM;
            });

            DeleteProduct = new RelayCommand(obj =>
            {
                MainViewModel.Products.Remove(MainViewModel.ProductToEdit);

                MainViewModel.FilterProducts();
                MainViewModel.SerializeProducts();
                MainViewModel.CurrentView = MainViewModel.ProductVM;
            });
            Exit = new RelayCommand(obj =>
            {
                MainViewModel.CurrentView = MainViewModel.ProductVM;
            });
        }

        public void UpdateUI()
        {
            Name = MainViewModel.ProductToEdit.Name;
            ShortName = MainViewModel.ProductToEdit.ShortName;
            ImagePath = MainViewModel.ProductToEdit.ImagePath;
            Price = MainViewModel.ProductToEdit.Price.ToString();
            InStock = MainViewModel.ProductToEdit.InStock;

            if (MainViewModel.ProductToEdit.Category == Product.Categories.Clothing)
            {
                CheckClothing = true;
            }
            if (MainViewModel.ProductToEdit.Category == Product.Categories.Accessories)
            {
                CheckAccessories = true;
            }
            if (MainViewModel.ProductToEdit.Category == Product.Categories.Other)
            {
                CheckOther = true;
            }
        }

        public class NotifyableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected void Notify(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
