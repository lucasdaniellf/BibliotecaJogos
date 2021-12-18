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
    public class EditModel : PageModel
    {
        private readonly string _conn;
        private readonly BibliotecaServiceNG _bibliotecaNG;
        private readonly BibliotecaServiceAD _bibliotecaAD;
        public SelectList selectEstudio { get; set; }
        public List<Genero> generoList { get; set; }
        public List<JogoGenero> jogoGeneroList { get; private set; }

        [BindProperty]
        public Jogo jogo { get; set; }
        [BindProperty]
        public int[] generosChecked { get; set; }

        public EditModel(IOptions<DataBaseContext> options, BibliotecaServiceNG serviceNG, BibliotecaServiceAD serviceAD)
        {
            _conn = options.Value.SqlConnection;
            _bibliotecaNG = serviceNG;
            _bibliotecaAD = serviceAD;
        }

        public void OnGet(int id)
        {
            if (TempData["sucesso_update"] != null || TempData["erro_update"] != null)
            {
                ViewData["status_update"] = TempData["erro_update"] ?? TempData["sucesso_update"];
                
                jogo = TempData["jogo_update"] != null ? 
                                                  JsonConvert.DeserializeObject<Jogo>((string) TempData["jogo_update"]) :
                                                  _bibliotecaNG.SelectJogoPorID(_conn, _bibliotecaAD, id) ;
                
                jogoGeneroList = TempData["jogoGenero_update"] != null ?
                                 JsonConvert.DeserializeObject <List<JogoGenero>>((string) TempData["jogoGenero_update"]) :
                                 jogoGeneroList = _bibliotecaNG.SelectJogoGenerosPorJogoId(_conn, _bibliotecaAD, jogo.idJogo) ;
                
                TempData.Clear();
            } else
            {
                jogo = _bibliotecaNG.SelectJogoPorID(_conn, _bibliotecaAD, id);
                jogoGeneroList = _bibliotecaNG.SelectJogoGenerosPorJogoId(_conn, _bibliotecaAD, jogo.idJogo);
            }
            selectEstudio = new SelectList(_bibliotecaNG.SelectTodosEstudios(_conn, _bibliotecaAD), "idEstudio", "nome", jogo.idEstudio);
            generoList = _bibliotecaNG.SelectTodosGeneros(_conn, _bibliotecaAD);
        }

        public ActionResult OnPostEditar()
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int row = _bibliotecaNG.UpdateJogo(_conn, _bibliotecaAD, jogo);
                    if (row > 0)
                    {
                        _bibliotecaNG.DeleteJogoGeneroPorJogoId(_conn, _bibliotecaAD, jogo.idJogo);

                        foreach (var item in generosChecked)
                        {
                            _bibliotecaNG.InsertJogoGeneroPorJogoId(_conn, _bibliotecaAD, new JogoGenero
                            {
                                idJogo = jogo.idJogo,
                                idGenero = item
                            });
                        }

                        TempData["sucesso_update"] = " 0 - Jogo atualizado com sucesso!";
                    }
                    else
                    {
                        TempData["erro_update"] = "1 - Falha ao atualizar o jogo!";
                    }
                } catch(NpgsqlException)
                {
                    return RedirectToPage("/Error");
                }

                TempData["jogo_update"] = JsonConvert.SerializeObject(jogo);
                TempData["jogoGenero_update"] = JsonConvert.SerializeObject(_bibliotecaNG.SelectJogoGenerosPorJogoId(_conn, _bibliotecaAD, jogo.idJogo));
            
            } else
            {
                TempData["erro_update"] = "1 - Falha no preenchimento dos campos!";
            }

            return RedirectToPage("/Edit", new { id = jogo.idJogo });
        }
    }
}
