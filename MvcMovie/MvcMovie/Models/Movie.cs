using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // O ApplyFormatInEditMode aplica a mesma formatação para os formulários.
        // É importante utilizar o DisplayFormat em conjunto com o DataType.
        [Display(Name = "Release Date")] // Corrigindo o nome, que antes estava junto.
        [DataType(DataType.Date)] 
        // Utilizamos DataType.Date para que apenas a data seja necessária para inserção,
        // e que só ela seja mostrada, retirando informações de horário, etc.
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        // Utilizamos o DataTipe para especificar a formatação dos dados, 
        // assim definimos que os valores serão decimais com casas 18 e 2.
        // A partir disso, o Entity Framework mapeia corretamente o Price para
        // moeda no banco de dados.

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
        
        // Estamos também adicionanso uma nova propriedade Rating, iremos fazer
        // a migration e ela será adicionada ao bando de dados.

        // Adicionamos também decorators de validação, como Required e StringLength,
        // Eles irão fazer com que apareça uma notificação na tela caso o usuário
        // não insira algum dado condizente com as validações definidas. Tudo isso
        // funcionando para o metódo edit e também para o create.
    }
}