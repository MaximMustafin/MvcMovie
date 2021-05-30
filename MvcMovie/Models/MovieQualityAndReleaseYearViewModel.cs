using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.NLayerApp.BLL.DTO;
using System.Collections.Generic;


namespace MvcMovie.NLayerApp.WEB.Models
{
    public class MovieQualityAndReleaseYearViewModel
    {
        public List<MovieDTO> Movies { get; set; }
        public SelectList Qualities { get; set; }
        public SelectList ReleaseYears { get; set; }
        public string MovieQuality { get; set; }
        public int MovieReleaseYear { get; set; }
    }
}
