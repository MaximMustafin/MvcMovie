using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.NLayerApp.BLL.DTO;
using System.Collections.Generic;

namespace MvcMovie.NLayerApp.WEB.Models
{
    public class MovieGenreViewModel
    {
        public List<MovieDTO> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}