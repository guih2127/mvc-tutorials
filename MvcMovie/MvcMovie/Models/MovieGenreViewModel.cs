using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies;
        public SelectList Genres;
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}

// Criamos a ViewModel MovieGenre. Aqui temos a lista de Movies, a string MovieGenre,
// SearchString, que é o texto contido na caixa de pesquisa e um SelectList de Genres,
// que permite que o usuário selecione um genêro na lista. 
