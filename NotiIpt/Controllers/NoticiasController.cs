using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NotiIpt.Data;
using NotiIpt.Models;
using NotiIpt.ViewModels;

namespace NotiIpt.Controllers
{
    public class NoticiasController : Controller
    {
        /// <summary>
        /// referência à BD do projeto
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// objeto que contém os dados referentes ao ambiente 
        /// do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NoticiasController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Noticias.Include(c => c.Categoria).ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticias = await _context.Noticias.FirstOrDefaultAsync(m => m.Id == id);
            if (noticias == null)
            {
                return NotFound();
            }

            return View(noticias);
        }

        // GET: Noticias/Create
        [HttpGet]
        public async Task <IActionResult> Create()
        {
            ViewData["CategoriaFK"] = await _context.Categorias.ToListAsync();
            NoticiasFotosViewMo noti = new NoticiasFotosViewMo();
            return View(noti);
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticiasFotosViewMo noticia, IFormFile ListaFotos)
        {
            ViewData["CategoriaFK"] = await _context.Categorias.ToListAsync();
            // [Bind] - anotação para indicar que dados, vindos da View,
            //          devem ser 'aproveitados'

            //Recebe ficheiro do utilizador
            var Fotos = HttpContext.Request.Form.Files;
            string msgErro = "";
            //vars. auxiliares
            string nomeImagem = "";
            bool haImagem = false;
            Dictionary<Fotos, IFormFile> mapFotos = new Dictionary<Fotos, IFormFile>();
            //verifica se existe ficheiro
            if (Fotos != null) 
            {
                int fotoIndex = 0;

                foreach (var foto in Fotos)
                {
                    if (!(foto.ContentType == "image/png" || foto.ContentType == "image/jpeg"))
                    {
                        msgErro = "A imagem tem de ser do tipo png ou jpeg!";
                        ModelState.AddModelError("Foto", msgErro);
                        
                    }
                    else
                    {
                        nomeImagem = $"{noticia.Nome}_{fotoIndex++}";
                        // obter a extensão do nome do ficheiro
                        string extensao = Path.GetExtension(foto.FileName);
                        nomeImagem += extensao;

                        Fotos f = new Fotos(nomeImagem);
                        noticia.Noticias.ListaFotos.Add(f);
                        mapFotos.Add(f, foto);
                        haImagem = true;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                Noticias n = noticia.Noticias;
                _context.Add(n);
                await _context.SaveChangesAsync();
                // se há ficheiro de imagem,
                // vamos guardar no disco rígido do servidor
                if (haImagem)
                {
                    // determinar onde se vai guardar a imagem
                    string localImagem = _webHostEnvironment.WebRootPath;
                    // já sei o caminho até à pasta wwwroot
                    // especifico onde vou guardar a imagem
                    localImagem = Path.Combine(localImagem, "Imagens");
                    // e, existe a pasta 'Imagens'?
                    if (!Directory.Exists(localImagem))
                    {
                        Directory.CreateDirectory(localImagem);
                    }
                    foreach (KeyValuePair<Fotos, IFormFile> i in mapFotos)
                    {
                        localImagem = Path.Combine(localImagem, i.Key.Nome);
                        using var stream = new FileStream(localImagem, FileMode.Create);
                        await i.Value.CopyToAsync(stream);
                        localImagem = _webHostEnvironment.WebRootPath;
                        localImagem = Path.Combine(localImagem, "Imagens");
                    }
                }
                // redireciona o utilizador para a página Index
                return RedirectToAction(nameof(Index));
            }
            // se cheguei aqui é pq alguma coisa correu mal
            // volta à View com os dados fornecidos pela View
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["CategoriaFK"] = await _context.Categorias.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            //lista de noticias
            var noticias = await _context.Noticias.Include(f => f.ListaFotos).Include(f => f.Categoria).Where(f => f.Id == id).FirstAsync();
            if (noticias == null)
            {
                return NotFound();
            }

            ViewData["CategoriaFK"] = await _context.Categorias.ToListAsync();
            NoticiasFotosViewMo noti = new NoticiasFotosViewMo();
            noti.Noticias = noticias;

            return View(noti);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NoticiasFotosViewMo noticia, IFormFile ListaFotos)
        {
            ViewData["CategoriaFK"] = await _context.Categorias.ToListAsync();
            // [Bind] - anotação para indicar que dados, vindos da View,
            //          devem ser 'aproveitados'

            //Recebe ficheiro do utilizador
            var Fotos = HttpContext.Request.Form.Files;
            string msgErro = "";
            //vars. auxiliares
            string nomeImagem = "";
            bool haImagem = false;
            Dictionary<Fotos, IFormFile> mapFotos = new Dictionary<Fotos, IFormFile>();
            //verifica se existe ficheiro
            if (Fotos != null)
            {
                int fotoIndex = 0;

                foreach (var foto in Fotos)
                {
                    if (!(foto.ContentType == "image/png" || foto.ContentType == "image/jpeg"))
                    {
                        msgErro = "A imagem tem de ser do tipo png ou jpeg!";
                        ModelState.AddModelError("Foto", msgErro);

                    }
                    else
                    {
                        nomeImagem = $"{noticia.Nome}_{fotoIndex++}";
                        // obter a extensão do nome do ficheiro
                        string extensao = Path.GetExtension(foto.FileName);
                        nomeImagem += extensao;

                        Fotos f = new Fotos(nomeImagem);
                        noticia.Noticias.ListaFotos.Add(f);
                        mapFotos.Add(f, foto);
                        haImagem = true;
                    }
                }
            }

            if (ModelState.IsValid)
            {

                Noticias n = noticia.Noticias;
                _context.Update(n);
                //mantém a data de criação original da noticia
                _context.Entry(n).Property(n => n.DataEscrita).IsModified = false;
                // Atribui a data e hora atual ao atributo DataEdicao
                n.DataEdicao = DateTime.Now; 
                await _context.SaveChangesAsync();
                // se há ficheiro de imagem,
                // vamos guardar no disco rígido do servidor
                if (haImagem)
                {
                    // determinar onde se vai guardar a imagem
                    string localImagem = _webHostEnvironment.WebRootPath;
                    // já sei o caminho até à pasta wwwroot
                    // especifico onde vou guardar a imagem
                    localImagem = Path.Combine(localImagem, "Imagens");
                    // e, existe a pasta 'Imagens'?
                    if (!Directory.Exists(localImagem))
                    {
                        Directory.CreateDirectory(localImagem);
                    }
                    foreach (KeyValuePair<Fotos, IFormFile> i in mapFotos)
                    {
                        localImagem = Path.Combine(localImagem, i.Key.Nome);
                        using var stream = new FileStream(localImagem, FileMode.Create);
                        await i.Value.CopyToAsync(stream);
                        localImagem = _webHostEnvironment.WebRootPath;
                        localImagem = Path.Combine(localImagem, "Imagens");
                    }
                }
                TempData["atualizado"] = "Noticia " + n.Titulo + " atualizada com sucesso!";
                // redireciona o utilizador para a página Index
                return RedirectToAction(nameof(Edit));
            }
            // se cheguei aqui é pq alguma coisa correu mal
            // volta à View com os dados fornecidos pela Vie
            return View(noticia);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoto(int fotoId, int noticiaId)
        {
            var foto = await _context.Fotos.FindAsync(fotoId);
            if (foto != null)
            {
                // Caminho da imagem no servidor
                string caminhoImagem = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens", foto.Nome);

                // Verificar se o arquivo existe
                if (System.IO.File.Exists(caminhoImagem))
                {
                    // Apagar o arquivo
                    System.IO.File.Delete(caminhoImagem);
                }

                // Remover a imagem da base de dados
                _context.Fotos.Remove(foto);
                await _context.SaveChangesAsync();
            }

            // Redirecionar para a página de edição da notícia
            return RedirectToAction("Edit", new { id = noticiaId });
        }
    

    // GET: Noticias/Delete/5
    public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticias = await _context.Noticias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticias == null)
            {
                return NotFound();
            }

            return View(noticias);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias != null)
            {
                _context.Noticias.Remove(noticias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiasExists(int id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }
    }
}
