using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
           
        [Display(Name = "Release Date")] // Corrigindo o nome, que antes estava junto.
        [DataType(DataType.Date)] 
        // Utilizamos DataType.Date para que apenas a data seja necessária para inserção,
        // e que só ela seja mostrada, retirando informações de horário, etc.
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        // Utilizamos o DataTipe para especificar o tipo de dados, 
        // assim definimos que os valores serão decimais com casas 18 e 2.
        // A partir disso, o Entity Framework mapeia corretamente o Price para
        // moeda no banco de dados.
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}