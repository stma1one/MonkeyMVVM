using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyMVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonkeyPage : ContentPage
    {
        public MonkeyPage()
        {
            InitializeComponent();
        }
    }
}