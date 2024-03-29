﻿using System;
using System.Collections.Generic;
using System.Linq;
using Akavache;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Skintime.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Skintime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            
            InitializeComponent();
            BlobCache.ApplicationName = "Skintime";
            //Registrations.Start("Skintime");
            BlobCache.EnsureInitialized();
            BlobCache.Secure.GetAllObjects<Cosmetics>().Subscribe(x => mycosmetics = x.ToList());
            //Hàm GetAllObjects trả giá trị IEnumerable nên phải chuyển về dạng list mới gắn cho List được
            Coll.ItemsSource = mycosmetics;
            //Search.Text = mycosmetics.Count.ToString();
        }

        //List<Key> MyList = new List<Key>();
        List<Cosmetics> mycosmetics = new List<Cosmetics>();

        private void Search_TextChange(object sender, TextChangedEventArgs e)
        {
            //Search.Text = mycosmetics.Count.ToString();
            //MyList = await App.Keydatabase.GetKeyAsync();
            var SearchResult1 = mycosmetics.Where(c =>
            {
                string text1 = Search.Text;
                return c.name.ToLower().Contains(text1.ToLower());
            });
            var SearchResult2 = mycosmetics.Where(c =>
            {
                string text1 = Search.Text;
                return c.brand.ToLower().Contains(text1.ToLower());
            });
            List<Cosmetics> a = SearchResult1.ToList();
            List<Cosmetics> a2 = SearchResult2.ToList();
            //Đây là nơi các bạn thêm tìm kiếm theo brand nếu cần
            //              (viết sẵn ngay dưới)
            a = a.Union(a2).ToList();
            Coll.ItemsSource = a;
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                var cosmetics = (Cosmetics)e.CurrentSelection.FirstOrDefault();

                var DetailPage = new ProductDetailPage("search");
                DetailPage.BindingContext = cosmetics;
                await Navigation.PushAsync(DetailPage);
                
            }
            
        }

        
    }

}