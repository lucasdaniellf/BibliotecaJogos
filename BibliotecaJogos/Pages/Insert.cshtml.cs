using AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Model;
using Newtonsoft.Json;
using NG;
using Npgsql;
using System;
using System.Collections.Generic;

namespace BibliotecaJogos.Pages
{
    public class InsertModel : PageModel
    {
        private readonly string _conn;
        private readonly BibliotecaServiceNG _bibliotecaNG;
        private readonly BibliotecaServiceAD _bibliotecaAD;
        public SelectList selectEstudio { get; set; }
        public List<Genero> generoList { get; set;}

        [BindProperty]
        public Jogo jogo { get; set; }
        [BindProperty]
        public int[] generosChecked { get; set; }

        public InsertModel(IOptions<DataBaseContext> options, BibliotecaServiceNG serviceNG, BibliotecaServiceAD serviceAD)
        {
            _conn = options.Value.SqlConnection;
            _bibliotecaNG = serviceNG;
            _bibliotecaAD = serviceAD;

            jogo = new Jogo()
            {
                dataCompra = DateTime.Now.Date
            };
        }

        public void OnGet()
        {
            selectEstudio = new SelectList(_bibliotecaNG.SelectTodosEstudios(_conn, _bibliotecaAD), "idEstudio", "nome");
            generoList = _bibliotecaNG.SelectTodosGeneros(_conn, _bibliotecaAD);

            if (TempData["erro_insert"] != null)
            {
                ViewData["erro_insert"] = TempData["erro_insert"];
                jogo = JsonConvert.DeserializeObject<Jogo>((string)TempData["jogo_insert"]);

                TempData.Clear();
            }
        }

        public ActionResult OnPostInserir()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = _bibliotecaNG.InsertJogo(_conn, _bibliotecaAD, jogo);
                    if (id > 0)
                    {
                        foreach (var item in generosChecked)
                        {
                            _bibliotecaNG.InsertJogoGeneroPorJogoId(_conn, _bibliotecaAD, new JogoGenero
                            {
                                idJogo = id,
                                idGenero = item
                            });
                        }

                        TempData["status"] = "Jogo adicionado com sucesso!";
                        return RedirectToPage("/Index");
                    }

                    TempData["erro_insert"] = "Falha ao inserir o jogo!";
                    TempData["jogo_insert"] = JsonConvert.SerializeObject(jogo);

                } catch(NpgsqlException)
                {
                    return RedirectToPage("/Error");
                }
            }
            else
            {
                TempData["erro_insert"] = "Falha no preenchimento dos campos!";
                TempData["jogo_insert"] = JsonConvert.SerializeObject(new Jogo()
                {
                    dataCompra = DateTime.Now.Date
                });
            }
            return RedirectToPage("/Insert");
        }
    }
}
