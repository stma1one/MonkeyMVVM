using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MonkeyMVVM.ViewModels;
namespace MonkeyMVVM
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            BindingContext = new MonkeysCollectionViewModel();
            ((MonkeysCollectionViewModel)BindingContext).NavigateToPageEvent += NavigateToPageAsync;
            InitializeComponent();
        }

       public async void NavigateToPageAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }
    }
}
