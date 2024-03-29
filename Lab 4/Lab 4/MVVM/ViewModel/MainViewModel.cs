﻿using Lab_4.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_4.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private string _language;
        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;

                OnPropertyChanged();
            }
        }
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                Filters.Search = value;

                OnPropertyChanged();
            }
        }

        private Filters _filters;
        public Filters Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;

                FilterProducts();

                OnPropertyChanged();
            }
        }
        public List<Core.Product> Products { get; set; }
        public Core.Product ProductToEdit { get; set; }
        private List<Core.Product> _filteredProducts;
        public List<Core.Product> FilteredProducts
        {
            get { return _filteredProducts; }
            set
            {
                _filteredProducts = value;

                OnPropertyChanged();
            }
        }

        public RelayCommand EnterSearch { get; set; }
        public RelayCommand AddProduct { get; set; }
        public RelayCommand ChangeLanguage { get; set; }

        public ProductViewModel ProductVM { get; set; }
        public AddProductViewModel AddProductVM { get; set; }
        public EditProductViewModel EditProductVM { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                
                OnPropertyChanged();
            }
        }
        /*private readonly CommandManager _commandManager = new CommandManager();

        public ICommand UndoCommand => _commandManager.GetUndoCommand(() => _commandManager.CanUndo());


        public ICommand RedoCommand => _commandManager.GetRedoCommand(() => _commandManager.CanRedo());

        public class CommandManager
        {
        private readonly Stack<Action> _undoStack = new Stack<Action>();
        private readonly Stack<Action> _redoStack = new Stack<Action>();

        public bool CanUndo()
        {
        return _undoStack.Count > 0;
        }

        public bool CanRedo()
        {
        return _redoStack.Count > 0;
        }
        public void AddUndoAction(Action undoAction)
        {
        _undoStack.Push(undoAction);
        _redoStack.Clear();
        }

        public void Undo()
        {
        if (_undoStack.Count > 0)
        {
        var undoAction = _undoStack.Pop();
        undoAction();
        _redoStack.Push(undoAction);
        }
        }

        public void Redo()
        {
        if (_redoStack.Count > 0)
        {
        var redoAction = _redoStack.Pop();
        redoAction();
        _undoStack.Push(redoAction);
        }
        }*/
        public MainViewModel()
        {
            DeserializeProducts();

            Language = "EN";

            FilteredProducts = Products;

            ProductVM = new ProductViewModel(this);
            AddProductVM = new AddProductViewModel(this);
            EditProductVM = new EditProductViewModel(this);
            CurrentView = ProductVM;

            Filters = new Filters();

            EnterSearch = new RelayCommand(obj =>
            {
                FilterProducts();

                CurrentView = ProductVM;
            });

            AddProduct = new RelayCommand(obj =>
            {
                CurrentView = AddProductVM;
            });

            ChangeLanguage = new RelayCommand(obj =>
            {
                var app = Application.Current;

                if (Language == "EN")
                {
                    var uriRU = new Uri("../../Locales/LocaleRU.xaml", UriKind.Relative);

                    app.Resources.MergedDictionaries[0].MergedDictionaries.Clear();
                    app.Resources.MergedDictionaries[0].MergedDictionaries.Add(new ResourceDictionary() { Source = uriRU });

                    Language = "RU";

                    return;
                }

                
                var uriEN = new Uri("../../Locales/LocaleEN.xaml", UriKind.Relative);

                app.Resources.MergedDictionaries[0].MergedDictionaries.Clear();
                app.Resources.MergedDictionaries[0].MergedDictionaries.Add(new ResourceDictionary() { Source = uriEN });

                Language = "EN";
            });
        }

        public void FilterProducts()
        {
            var filteredProducts = Products
                .Where(product => product.Name.ToUpper().Contains(Filters.Search.ToUpper()));

            if (Filters.InStockOnly == true)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.InStock != false);
            }

            filteredProducts = filteredProducts
                .Where(product => product.Price <= Filters.MaximumPrice);

            filteredProducts = filteredProducts
                .Where(product => product.Price >= Filters.MinimumPrice);

            if (Filters.Categories[0] == false)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.Category != Product.Categories.Clothing);
            }

            if (Filters.Categories[1] == false)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.Category != Product.Categories.Accessories);
            }

            if (Filters.Categories[2] == false)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.Category != Product.Categories.Other);
            }

            FilteredProducts = filteredProducts.ToList();

            ProductVM.UpdateProducts();
        }

        public void SerializeProducts()
        {
            string json = JsonSerializer.Serialize(Products);
            File.WriteAllText(@"C:\Users\Maria\source\repos\OOP_4sem\Lab 4\Lab 4\Products.json", json);
        }

        public void DeserializeProducts()
        {
            string json = File.ReadAllText(@"C:\Users\Maria\source\repos\OOP_4sem\Lab 4\Lab 4\Products.json");
            Products = JsonSerializer.Deserialize<List<Core.Product>>(json);
        }
    }
}
