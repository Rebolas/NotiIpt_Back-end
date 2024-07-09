using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotiIpt.Data;
using NotiIpt.Models;

namespace NotiIpt.Controllers
{
    public class FotosController : Controller
    {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// objeto que contém os dados referentes ao ambiente 
        /// do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;


        public FotosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Fotos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fotos.ToListAsync());
        }

        // GET: Fotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotos = await _context.Fotos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotos == null)
            {
                return NotFound();
            }

            return View(fotos);
        }

        // GET: Fotos/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Fotos fotos, IFormFile Foto)
        {// [Bind] - anotação para indicar que dados, vindos da View,
         //          devem ser 'aproveitados'

            // vars. auxiliares
            string nomeImagem = "";
            bool haImagem = false;

            // há ficheiro?
            if (Foto == null)
            {
                ModelState.AddModelError("",
                   "O fornecimento de um Logótipo é obrigatório!");
                return View(fotos);
            }
            else
            {
                // há ficheiro, mas é imagem?
                if (!(Foto.ContentType == "image/png" ||
                       Foto.ContentType == "image/jpeg")
                   )
                {
                    ModelState.AddModelError("",
                   "Tem de fornecer para o Logótipo um ficheiro PNG ou JPG!");
                    return View(fotos);
                }
                else
                {
                    // há ficheiro, e é uma imagem válida
                    haImagem = true;
                    // obter o nome a atribuir à imagem
                    nomeImagem = fotos.Nome;
                    // obter a extensão do nome do ficheiro
                    string extensao = Path.GetExtension(Foto.FileName);
                    // adicionar a extensão ao nome da imagem
                    nomeImagem += extensao;
                    // adicionar o nome do ficheiro ao objeto que
                    // vem do browser
                    fotos.Nome = nomeImagem;
                }
            }

            // avalia se os dados que chegam da View
            // estão de acordo com o Model
            if (ModelState.IsValid)
            {
                // adiciona os dados vindos da View à BD
                _context.Add(fotos);
                // efetua COMMIT na BD
                await _context.SaveChangesAsync();

                // se há ficheiro de imagem,
                // vamos guardar no disco rígido do servidor
                if (haImagem)
                {
                    // determinar onde se vai guardar a imagem
                    string Imagens =
                       _webHostEnvironment.WebRootPath;
                    // já sei o caminho até à pasta wwwroot
                    // especifico onde vou guardar a imagem
                    Imagens =
                       Path.Combine(Imagens, "Imagens");
                    // e, existe a pasta 'Imagens'?
                    if (!Directory.Exists(Imagens))
                    {
                        Directory.CreateDirectory(Imagens);
                    }
                    // juntar o nome do ficheiro à sua localização
                    string localImagem =
                       Path.Combine(Imagens, nomeImagem);

                    // guardar a imagem no disco rigído
                    using var stream = new FileStream(
                       localImagem, FileMode.Create
                       );
                    await Foto.CopyToAsync(stream);
                }


                // redireciona o utilizador para a página Index
                return RedirectToAction(nameof(Index));
            }

            // se cheguei aqui é pq alguma coisa correu mal :-(
            // volta à View com os dados fornecidos pela View
            return View(fotos);
        }

        // GET: Fotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotos = await _context.Fotos.FindAsync(id);
            if (fotos == null)
            {
                return NotFound();
            }
            return View(fotos);
        }

        // POST: Fotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Fotos fotos)
        {
            if (id != fotos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotosExists(fotos.Id))
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
            return View(fotos);
        }

        // GET: Fotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotos = await _context.Fotos.FirstOrDefaultAsync(m => m.Id == id);
            if (fotos == null)
            {
                return NotFound();
            }

            return View(fotos);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotos = await _context.Fotos.FindAsync(id);
            if (fotos != null)
            {
                // Caminho da imagem no servidor
                string caminhoImagem = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens", fotos.Nome);

                // Verificar se o arquivo existe
                if (System.IO.File.Exists(caminhoImagem))
                {
                    // Apagar o arquivo
                    System.IO.File.Delete(caminhoImagem);
                }

                // Remover a imagem da base de dados
                await _context.SaveChangesAsync();

                _context.Fotos.Remove(fotos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotosExists(int id)
        {
            return _context.Fotos.Any(e => e.Id == id);
        }
    }
}
