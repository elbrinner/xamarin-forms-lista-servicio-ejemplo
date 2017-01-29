using Forms.Dtos;
using Forms.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Forms.ViewModels
{
    public class MainViewModel : BaseViewModel 
    {

        private ResultResponseDto listData;
        private ResultDto selectedItem;


        public ResultDto SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                if (value != null)
                {
                    selectedItem = value;
                   // this.Detail();
                }
               
                OnPropertyChanged();

            }
        }



        public ResultResponseDto ListData
        {
            get
            {
                return this.listData;
            }

            set
            {
                this.listData = value;
                this.OnPropertyChanged();
            }
        }

        public async void LoadServiceInit()
        {
            this.IsBusy = true;
            try
            {
                var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.baseUrl, Contants.Config.param1));
                var cliente = new HttpClient();
                var result = await cliente.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        this.ListData = JsonConvert.DeserializeObject<ResultResponseDto>(content);
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally{
                this.IsBusy = false;
            }          

        }

        public async void Detail()
        {
            this.IsBusy = true;
            try
            {
                var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.baseUrlDetail, this.SelectedItem?.id));
                var cliente = new HttpClient();
                var result = await cliente.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        var response = JsonConvert.DeserializeObject<DetailResponseDto>(content);
                    }
                   
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Detalle no disponible");
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.IsBusy = false;
            }

        }

     

    }




}
