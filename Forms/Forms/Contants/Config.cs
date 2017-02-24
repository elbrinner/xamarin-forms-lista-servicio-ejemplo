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

        const string language = "&amp;language=es-es";

        //Base url del servicio
        public const string baseUrl = "https://api.themoviedb.org/3/{0}/&api_key="+keyApi+language;
        public const string baseUrlMovieDb = "http://api.themoviedb.org/3/";
        public const string baseUrlDetail = "https://api.themoviedb.org/3/movie/{0}?api_key=" + keyApi + language;

        //Peliculas populares - https://api.themoviedb.org/3/movie/popular?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1
        public const string urlBase =  "https://api.themoviedb.org/3/movie/popular?api_key=" + keyApi + language;
        
        //Mejores valoradas
        public const string TopRatedMoviesKey = baseUrlMovieDb + "movie/top_rated/?api_key="+keyApi+language+"&page={0}";
        //https://api.themoviedb.org/3/movie/top_rated?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	200	GET	api.themoviedb.org	/3/movie/top_rated?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	Wed Feb 15 20:34:56 CET 2017	156	7628	Complete	

        //Próximamente      
          public const string ComingSoonMoviesKey = baseUrlMovieDb + "movie/upcoming/?api_key=" + keyApi + language + "&page={0}";
        //https://api.themoviedb.org/3/movie/upcoming?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1

        public const string BannerGeneric = "http://www.peliculaxd.com/wp-content/themes/wovie/images/no_play.jpg";

        //now_playing

        public const string CineMoviesKey = baseUrlMovieDb + "movie/now_playing/?api_key=" + keyApi + language + "&amp;page={0}";

        //Populares
        public const string DiscoverMoviesKey = baseUrlMovieDb + "discover/movie/?api_key=" + keyApi + language + "&page={0}&sort_by=popularity.desc&primary_release_date.lte={1}&primary_release_date.gte={2}";
        //https://api.themoviedb.org/3/discover/movie?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1&sort_by=popularity.desc&primary_release_date.lte=2017-02-17&primary_release_date.gte=2017-01-21	
        //https://api.themoviedb.org/3/discover/movie/?api_key=7da49c129edfb471e8c4e17d294e3960&language=es-es&page=1&sort_by=popularity.desc&primary_release_date.lte=2017-02-19&primary_release_date.gte=2017-03-06
        public const string DetailMoviesKey = baseUrl ;


        //detalle de una pelicula - nombre, imagem, descripcion
        //https://api.themoviedb.org/3/movie/324849?api_key=a103367a91b648e561c12948632c9d88&language=es-ES	200	GET	api.themoviedb.org	/3/movie/324849?api_key=a103367a91b648e561c12948632c9d88&language=es-ES	Wed Feb 15 20:54:44 CET 2017	116	1893	Complete	
        //video del detalle
        //https://api.themoviedb.org/3/movie/324849/videos?api_key=a103367a91b648e561c12948632c9d88&language=es-ES	200	GET	api.themoviedb.org	/3/movie/324849/videos?api_key=a103367a91b648e561c12948632c9d88&language=es-ES	Wed Feb 15 20:54:45 CET 2017	120	1046	Complete	
        //
        //

        //Para serie
        //https://api.themoviedb.org/3/tv/airing_today?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	200	GET	api.themoviedb.org	/3/tv/airing_today?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	Wed Feb 15 21:05:42 CET 2017	128	6574	Complete	
        //https://api.themoviedb.org/3/tv/top_rated?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	200	GET	api.themoviedb.org	/3/tv/top_rated?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	Wed Feb 15 21:05:42 CET 2017	132	9238	Complete	
        //https://api.themoviedb.org/3/discover/tv?air_date.lte=2017-02-22&air_date.gte=2017-02-15&sort_by=popularity.desc&language=es-ES&page=1&api_key=a103367a91b648e561c12948632c9d88	200	GET	api.themoviedb.org	/3/discover/tv?air_date.lte=2017-02-22&air_date.gte=2017-02-15&sort_by=popularity.desc&language=es-ES&page=1&api_key=a103367a91b648e561c12948632c9d88	Wed Feb 15 21:05:42 CET 2017	127	9442	Complete	
        //https://api.themoviedb.org/3/tv/popular?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	200	GET	api.themoviedb.org	/3/tv/popular?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1	Wed Feb 15 21:05:42 CET 2017	127	9695	Complete	

        public const string SerieTodayKey = baseUrlMovieDb + "tv/airing_today/?api_key=" + keyApi + language + "&amp;page={0}";
        public const string SerieTopRatedKey = baseUrlMovieDb + "tv/top_rated/?api_key=" + keyApi + language + "&amp;page={0}";
        public const string SerieDiscoverKey = baseUrlMovieDb + "discover/tv/?api_key=" + keyApi + language + "&page={0}&sort_by=popularity.desc&primary_release_date.lte={1}&primary_release_date.gte={2}";
        public const string SeriePopularKey = baseUrlMovieDb + "tv/popular/?api_key=" + keyApi + language + "&amp;page={0}";


        //Buscar por pelicula y serie
        //https://api.themoviedb.org/3/discover/movie?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1&sort_by=popularity.desc&vote_average.gte=10&with_genres=80,16,99,12,28,10751,18,35	200	GET	api.themoviedb.org	/3/discover/movie?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1&sort_by=popularity.desc&vote_average.gte=9&with_genres=80,16,99,12,28,10751,18,35	
        //https://api.themoviedb.org/3/discover/tv?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1&sort_by=rating.asc&vote_average.gte=5&with_genres=18,80,35,16,99,12,28	200	GET	api.themoviedb.org	/3/discover/tv?api_key=a103367a91b648e561c12948632c9d88&language=es-ES&page=1&sort_by=rating.asc&vote_average.gte=5&with_genres=18,80,35,16,99,12,28



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
