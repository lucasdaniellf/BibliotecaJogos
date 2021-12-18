using AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model;
using NG;
using Npgsql;
using System;
using System.Collections.Generic;


namespace BibliotecaJogos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string _conn;
        private readonly BibliotecaServiceNG _bibliotecaNG;
        private readonly BibliotecaServiceAD _bibliotecaAD;

        [BindProperty]
        public List<Jogo> listaJogos { get; set; }
        
        [BindProperty]
        public List<Estudio> listaEstudios { get; set; } 

        public IndexModel(IOptions<DataBaseContext> options, BibliotecaServiceNG serviceNG, BibliotecaServiceAD serviceAD)
        {
            _conn = options.Value.SqlConnection;
            _bibliotecaNG = serviceNG;
            _bibliotecaAD = serviceAD;
        }

        public void OnGet()
        {
            if(TempData["status"] != null)
            {
                ViewData["status"] = TempData["status"].ToString();
            }

            TempData.Remove("status");

            listaJogos = _bibliotecaNG.SelectTotosJogos(_conn, _bibliotecaAD);
            listaEstudios = _bibliotecaNG.SelectTodosEstudios(_conn, _bibliotecaAD);

            foreach(Jogo jogo in listaJogos)
            {
                Console.WriteLine($"Jogo: {jogo.nome}");
            }
        }

        public ActionResult OnPostDelete(int id)
        {
            try
            {
                int rows = _bibliotecaNG.DeleteJogo(_conn, _bibliotecaAD, id);
                if (rows > 0)
                {
                    TempData["status"] = "Jogo deletado com sucesso !";
                }
                return RedirectToPage("/Index");
            } catch (NpgsqlException)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
