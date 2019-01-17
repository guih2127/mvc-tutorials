using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

// Nosso MovieController foi criado a partir do scaffolding.
namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
            // O construtor injeta o dbContext no controller, isso é utilizado
            // em cada uma das operações do CRUD criadas pelo scaffolding.
        }

        // GET: Movies
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            // Agora, passamos como parâmetro para a função Index uma searchString,
            // se ela existir (não for null ou empty), mudamos a variável movies
            // utilizando o contains, a partir da searchString passada.
            // O código acima faz uma consulta através de uma expressão LAMBDA. 
            // Expressões lambda são executados em consultas, que utilizam operadores
            // de consulta padrão, como o Where, OrderBy e Contains.
            // A partir de agora, então se chamarmos uma url tal com o parametro ?searchString=Ghost
            // conseguiremos obter os filmes que tenham apenas Ghost em seu Title.

            return View(await movies.ToListAsync());
			// No caso da Index, passamos uma lista de Movies para a View,
			// utilizando o metódo ToListAsync().

            // modificamos o que retornaremos na view. Não retornaremos mais _context.Movie
            // e sim nossa variável movies.
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
			// Nosso metódo Details recebe um Id, que normalmente é passado como dados de rota,
			// por ex: /movies/details/1. O firstOrDefaultAsync recebe uma lista de elementos,
			// no caso, a lista de movies, como argumento, e então obtém o primeiro elemento
			// que seja compatível com a expressão definida. Ou seja, se o id do movie for igual
			// ao id fornecido na requisição, esse objeto será armazenado na variável. Por fim,
			// passamos essa variável como parâmetro para a view.
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        // Nosso metódo create (HttpPost), através do model binding, obtém o form postado e
        // cria um novo objeto Movie, que é passado como o parâmetro Movie recebido pela ação,
        // o ModelState.IsValid verifica se os dados submetidos podem ser utilizados para modificar
        // um objeto movie realmente. O controller então adiciona os dados no context e salva as
        // alterações, chamando SaveChangesAsync. Por último, o controller redireciona o usuário
        // para o Index.

        // É importante dizer também que antes do form ser postado no servidor, há também
        // validações do lado do cliente, através de javascript, caso dele esteja habilitado.

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
            // O metódo HttpGet Edit recebe o parâmetro do id, e utiliza do EF para
            // encontrar o movie, utilizando o FindAsync, então esse movie é
            // passado para a view.
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        // O HttpPost define que o esse metódo pode ser invocado apenas por requisições POST.
        // O default é HttpGet, então não precisamos colocá-lo nos outros.
        [ValidateAntiForgeryToken]
        // O Bind é um jeito de se proteger contra over-posting. No bind devem ser incluídos apenas
        // dados que você quer que possam ser trocados.
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
