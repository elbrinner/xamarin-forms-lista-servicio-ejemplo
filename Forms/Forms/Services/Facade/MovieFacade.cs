using Forms.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Services.Facade
{
    public class MovieFacade
    {
        HttpClient client;

        public MovieFacade()
        {
            this.client = new HttpClient();
        }


        public  async Task<ResultResponseDto> MovieLast()
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.baseUrl, Contants.Config.param1));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                   return JsonConvert.DeserializeObject<ResultResponseDto>(content);
                }
                return new ResultResponseDto() { isCorrect = false, mensage = "Sin datos" };
            }
            return new ResultResponseDto() { isCorrect = false, mensage = result.ReasonPhrase };
        }

        public async Task<DetailResponseDto> DetailMovie(string id)
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.baseUrlDetail,id));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<DetailResponseDto>(content);
                }
                return new DetailResponseDto() { isCorrect = false, mensage = "Sin datos" };
            }
            return new DetailResponseDto() { isCorrect = false, mensage = result.ReasonPhrase };
        }
    }
}
