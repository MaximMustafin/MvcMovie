using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieQualityAndReleaseYearViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Qualities { get; set; }
        public SelectList ReleaseYears { get; set; }
        public string MovieQuality { get; set; }
        public int MovieReleaseYear { get; set; }
    }
}