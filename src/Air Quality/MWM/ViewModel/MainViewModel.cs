﻿using System;

namespace AirQuality.MWM.ViewModel
{
    class MainViewModel  
    {

        //public RelayCommand HomeViewCommand { get; set; }

        private object _currentView;

        //public HomeViewModel HomeVM { get; set; }
        //public LoginViewModel LoginVM { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                //OnPropertyChanged();
            }
        }
        

        public MainViewModel() 
        {
            //HomeVM = new HomeViewModel();
            //LoginVM = new LoginViewModel();
 
            //CurrentView = HomeVM;

            //HomeViewCommand = new RelayCommand(o => 
            //{
            //    CurrentView = HomeVM;
            //});

        }

    }

}
