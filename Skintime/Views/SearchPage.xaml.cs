﻿using System;
using System.Collections.Generic;
using System.Linq;
using Akavache;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Skintime.Models;

namespace Skintime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            //searchhandler.Load(MyList);
            //Coll.ItemsSource = MyList;
        }

        List<String> MyList = new List<string>();
        IEnumerable<Cosmetics> mycosmetics = new List<Cosmetics>();
        //ItemSearchHandlerClass searchhandler = new ItemSearchHandlerClass();
        
        private async void Search_TextChange(object sender, TextChangedEventArgs e)
        {
            List<Key> search = await App.Keydatabase.GetKeyAsync();
            var SearchResult = search.Where(c =>
            {
                string text1 = Search.Text;
                return c.productname.ToLower().Contains(text1.ToLower());
            });
            
            List<Key> a = SearchResult.ToList();
            Coll.ItemsSource = a;
            //check.Text = a.Count().ToString();
        }
        
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                var cosmetics = (Cosmetics)e.CurrentSelection.FirstOrDefault();

                var DetailPage = new ProductDetailPage();
                DetailPage.BindingContext = cosmetics;
                await Navigation.PushAsync(DetailPage);
                //await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailPage.product)}={cosmetics}");
            }
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

    }
}