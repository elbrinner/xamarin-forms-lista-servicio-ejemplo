﻿using Forms.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Forms.ViewModels
{
    public class BaseViewModel : BindableObject
    {

        #region variables y propiedades
        protected bool isBusy;
        protected string title;
        protected Page CurrentPage { get; private set; }
        public MasterDetailPage CurrentMasterPage { get; set; }

        #endregion

        public void Initialize(Page page)
        {
           
            CurrentPage = page;
            CurrentPage.Appearing += CurrentPageOnAppearing; // Arranca al cargar el viewModel
            CurrentPage.Disappearing += CurrentPageOnDisappearing;// Arranca al salir del viewModel
        }

        public void Initialize(MasterDetailPage page)
        {
           this.CurrentMasterPage = page;
           this.CurrentMasterPage.Appearing += CurrentPageOnAppearing; // Arranca al cargar el viewModel
           this.CurrentMasterPage.Disappearing += CurrentPageOnDisappearing;// Arranca al salir del viewModel
        }

        public void Initialize(MasterDetailPage currentMasterPage, Page page)
        {
            this.CurrentPage = page;
            this.CurrentMasterPage = currentMasterPage;
        }

        protected virtual void CurrentPageOnAppearing(object sender, EventArgs eventArgs) {
            this.CurrentMasterPage = CurrentMasterPage;
            this.CurrentPage = CurrentPage;
        }

        protected virtual void CurrentPageOnDisappearing(object sender, EventArgs eventArgs) {
            this.CurrentMasterPage = CurrentMasterPage;
            this.CurrentPage = CurrentPage;
        }      
    
        #region propiedades
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                    this.isBusy = value;
                    this.OnPropertyChanged("IsBusy");
            }
        }


  
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }

        #endregion



    }
}
