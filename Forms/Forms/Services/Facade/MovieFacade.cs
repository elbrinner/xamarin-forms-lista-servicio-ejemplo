using Forms.Dtos;
using Forms.Mappers;
using Forms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }


        public  async Task<ResultResponse> MovieLast()
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.baseUrl, Contants.Config.param1));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                   return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
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

        /// <summary>
        /// Obtiene las peliculas con mejor valoracion
        /// </summary>
        /// <param name="page">Página a mostrar</param>
        /// <returns></returns>
        public async Task<ResultResponse> GetTopRatedMovies(int page = 1)
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.TopRatedMoviesKey,page));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }

        /// <summary>
        /// Obtiene las peliculas proximamente
        /// </summary>
        /// <param name="page">Página a mostrar</param>
        /// <returns></returns>
        public async Task<ResultResponse> GetComingSoonMovies(int page = 1)
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.ComingSoonMoviesKey, page));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }

        /// <summary>
        /// Peliculas en cartelera
        /// </summary>
        /// <param name="page">Página a mostrar</param>
        /// <returns></returns>
        public async Task<ResultResponse> GetCine(int page = 1)
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.CineMoviesKey, "1"));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }

        /// <summary>
        /// Populares
        /// </summary>
        /// <param name="page">Página a mostrar</param>
        /// <returns></returns>
        public async Task<ResultResponse> GetDiscoverMovies(int page = 1)
        {
            var DateTimeFrom = DateTime.Now.ToString("yyyy-MM-dd");
            var DateTimeTo = DateTime.Now.AddDays(21).ToString("yyyy-MM-dd");
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.DiscoverMoviesKey, page, DateTimeTo, DateTimeFrom));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }

        public async Task<ResultResponse> GetSerieDiscover(int page = 1)
        {

            var DateTimeFrom = DateTime.Now.ToString("yyyy-MM-dd");
            var DateTimeTo = DateTime.Now.AddDays(21).ToString("yyyy-MM-dd");
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.SerieDiscoverKey, page, DateTimeTo, DateTimeFrom));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }

        public async Task<ResultResponse> GetSeriePopular(int page = 1)
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.SeriePopularKey, page));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }

        public async Task<ResultResponse> GetSerieToday(int page = 1)
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.SerieTodayKey, page));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }

        public async Task<ResultResponse> GetSerieTopRated(int page = 1)
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, Contants.Config.SerieTopRatedKey, page));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<ResultResponseDto>(content).ToBusiness();
                }
                return new ResultResponse() { IsCorrect = false, Mensage = "Sin datos" };
            }
            return new ResultResponse() { IsCorrect = false, Mensage = result.ReasonPhrase };
        }
    }
}
