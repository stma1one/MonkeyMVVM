using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeyMVVM
{
    public partial class MainPage : ContentPage
    {
       public ICommand RefreshCommand => new Command(Refresh);
        public bool IsRefresh { get; set; }
        private void Refresh()
        {
            BindingContext = new PageNavigationMonkeys.Monkeys();
            IsRefresh = false;
        }

        public MainPage()
        {
            BindingContext = new PageNavigationMonkeys.Monkeys();
            InitializeComponent();
        }

        private async void ColView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 1)
            {
                Page p = new MonkeyPage
                {
                    BindingContext = e.CurrentSelection[0]
                };
                await Navigation.PushAsync(p);
            }
        }
    }
}
