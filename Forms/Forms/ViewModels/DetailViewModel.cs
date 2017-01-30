using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms.Dtos;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;

namespace Forms.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private ResultDto item;
        private string img;
        private DetailResponseDto detailItem;

        public DetailResponseDto DetailItem
        {
            get
            {
                return this.detailItem;
            }

            set
            {
                this.detailItem = value;
                this.OnPropertyChanged();
            }
        }

        public string Img
        {
            get
            {
                return this.img;
            }

            set
            {
                this.img = value;
                this.OnPropertyChanged();
            }
        }
        public ResultDto Item
        {
            get
            {
                return this.item;
            }

            set
            {
                this.item = value;
                this.OnPropertyChanged();
            }
        }

        public DetailViewModel(ResultDto item)
        {
            this.Img = Contants.Config.imgBig + item.poster_path;
            this.Item = item;
        }

        public async Task<bool> DetailService()
        {
            this.IsBusy = true;
            try
            {
                var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.baseUrlDetail, this.Item?.id));
                var cliente = new HttpClient();
                var result = await cliente.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        this.DetailItem = JsonConvert.DeserializeObject<DetailResponseDto>(content);
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
                return false;
            }
            finally
            {
                this.IsBusy = false;
               
            }
            return true;
        }
    }
}
