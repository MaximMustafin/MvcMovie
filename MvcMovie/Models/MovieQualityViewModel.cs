using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieQualityViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Qualities { get; set; }
        public string MovieQuality { get; set; }
    }
}