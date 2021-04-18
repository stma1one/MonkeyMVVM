using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MonkeyMVVM.Models;
using MonkeyMVVM.Service;
namespace MonkeyMVVM.ViewModels
{
    public class MonkeysCollectionViewModel:INotifyPropertyChanged
    {
        private bool isRefresh;
        public ObservableCollection<Monkey> MonkeyList { get; set; }
        public bool IsRefresh
        {
            get { return isRefresh; }
            set
            {
                if (IsRefresh != value)
                {
                    isRefresh = value;
                    OnPropertyChanged("IsRefresh");
                }
            }
        }

        public MonkeysCollectionViewModel()
        {
            MonkeyList = new ObservableCollection<Monkey>();
            #region using webservice
            CreateMonkeysList();           
            #endregion


            #region if not using webService

            //Monkeys m = new Monkeys(); 
            //foreach(Monkey o in m.MonkeyList)
            //{
            //    MonkeyList.Add(o);
            //}
            #endregion
            isRefresh = false;
        }

        private async void CreateMonkeysList()
        {
            MonkeysWebServiceProxy proxy = new MonkeysWebServiceProxy();
            List<Monkey> m =await proxy.GetAllMonkeysAsync();
            foreach (Monkey o in m)
            {
                MonkeyList.Add(o);
            }
        }
        #region INOTIFYEVENT
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region events
        public ICommand DeleteCommand => new Command<Monkey>(Delete);


        private void Delete(Monkey m)
        {
            if (MonkeyList.Contains(m))
                MonkeyList.Remove(m);
        }
        public ICommand RefreshCommand => new Command(Refresh);
    
        private void Refresh()
        {
            MonkeyList.Clear();
            #region if not using webService
            //Monkeys m= new Monkeys();
            // foreach (Monkey o in m.MonkeyList)
            // {
            //     MonkeyList.Add(o);
            // }
            #endregion
            CreateMonkeysList();

            IsRefresh = false;
        }

        public ICommand SelectionChanged => new Command<Monkey>(OnSelectionChanged);

        private void OnSelectionChanged(Monkey obj)
        {
            Page p = new MonkeyPage();
            p.BindingContext = new MonkeyPageViewModel()
            {
                Name = obj.Name,
                ImageUrl = obj.ImageUrl,
                Details = obj.Details

            };
            if (NavigateToPageEvent != null)
                NavigateToPageEvent(p);
            
                
            
        }
        public Action<Page> NavigateToPageEvent;
        #endregion


    }
}
