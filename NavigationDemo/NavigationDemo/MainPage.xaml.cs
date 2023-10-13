using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace NavigationDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            string url = "https://randomuser.me/api/?results=" + myentry.Text;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsondata);
                List<Result> myval = new List<Result>();
                var myresponse = JsonConvert.DeserializeObject<MyValues>(jsondata);
                if (myresponse != null && myresponse.results.Count > 0)
                {
                    foreach (var res in myresponse.results)
                    {

                        myval.Add(res);
                    }
                    mylistview.ItemsSource = myval;
                }
            }
        }

        async void mylistview_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MyDetails(e.SelectedItem));

            }
        }
    }
}

