using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Contants
{
    public static class Config
    {
        //Key de la api
        const string keyApi = "7da49c129edfb471e8c4e17d294e3960";

        const string language = "&language=es-es";

        //Base url del servicio
        public const string baseUrl = "https://api.themoviedb.org/3/{0}/&api_key="+keyApi+language;

        public const string baseUrlDetail = "https://api.themoviedb.org/3/movie/{0}?api_key=" + keyApi + language;

        //películas más populares
        /// <summary>
        /// The param1
        /// </summary>
        public const string param1 = "discover/movie?sort_by=popularity.desc";

        //¿Cuáles son las películas para niños más populares?
        /// <summary>
        /// The param2
        /// </summary>
        public const string param2 = "/discover/movie?certification_country=US&certification.lte=G&sort_by=popularity.desc";


        public const string imgSmall = "http://image.tmdb.org/t/p/w185//";

        public const string imgBig = "http://image.tmdb.org/t/p/w780/";





    }
}
