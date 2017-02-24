using Forms.Dtos;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Mappers
{
    public static class ResultMapper
    {
        public static ResultResponse ToBusiness(this ResultResponseDto dto)
        {
            if (dto == null)
            {
                return new ResultResponse() { IsCorrect = false, Mensage = "Error al cargar los datos" };
            }

            ResultResponse response = new ResultResponse()
            {
                IsCorrect = dto.isCorrect == null ? false : dto.isCorrect.Value,
                Mensage = dto.mensage,
                Page = dto.page == null ? 0 : dto.page.Value,
                Results = dto.results.ToBusiness(),
                Total_pages = dto.total_pages == null ? 0 : dto.total_pages.Value,
                Total_results = dto.total_results == null ? 0 : dto.total_results.Value

            };

            return response;
        }

        public static List<Result> ToBusiness(this List<ResultDto> dtos)
        {
            if (dtos == null)
            {
                return new List<Result>(){ };
            }

            List<Result> group = new List<Result>();
            foreach (var dto in dtos)
            {
                Result item = new Result()
                {
                    Adult = dto.adult == null ? false : dto.adult.Value,
                    Backdrop_path = dto.backdrop_path == null ? Contants.Config.BannerGeneric : Contants.Config.imgBig + dto.backdrop_path,
                    Genre_ids = dto.genre_ids,
                    Id = dto.id == null ? 0 : dto.id.Value,
                    Original_language = dto.original_language,
                    Original_title = dto.original_title,
                    Overview = dto.overview,
                    Popularity = dto.popularity == null ? 0 : dto.popularity.Value,
                    Poster_path = Contants.Config.imgSmall + dto.poster_path,
                    Release_date = dto.release_date,
                    Title = dto.title,
                    Video = dto.video == null ? false : dto.video.Value,
                    Vote_average = dto.vote_average == null ? 0 : dto.vote_average.Value,
                    Vote_count = dto.vote_count == null ? 0 : dto.vote_count.Value,
                    PosterBig = dto.backdrop_path == null ? Contants.Config.BannerGeneric : Contants.Config.imgBig + dto.backdrop_path,
                    PosterSmall = dto.backdrop_path == null ? Contants.Config.BannerGeneric : Contants.Config.imgSmall + dto.backdrop_path,
                    PhotoBig = dto.poster_path == null ? Contants.Config.BannerGeneric : Contants.Config.imgBig + dto.poster_path,
                    PhotoSmall = dto.poster_path == null ? Contants.Config.BannerGeneric : Contants.Config.imgSmall + dto.poster_path,
                    Name = dto.name

            };
                group.Add(item);
            }
           

            return group;
        }
    }
}
