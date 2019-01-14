using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)] 
        // Utilizamos DataType.Date para que apenas a data seja necessária para inserção,
        // e que só ela seja mostrada, retirando informações de horário, etc.
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}