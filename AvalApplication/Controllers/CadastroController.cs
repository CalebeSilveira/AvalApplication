using AvalApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvalApplication.Controllers
{
    public class CadastroController : Controller
    {
        private static List<DevedorModel> _listaDevedor = new List<DevedorModel>()
        {
            new DevedorModel(){ Id=1, Nome="Maria Aparecida", CPF="463.399.558-02", Telefones=996775522, Contrato= 1000001, Parcelas=1},
            new DevedorModel(){ Id=2, Nome="Rita Gonzaga", CPF="245.889.669-34", Telefones=986758932, Contrato= 1000002, Parcelas=2},
            new DevedorModel(){ Id=3, Nome="Alexandre da Silva",  CPF="955.142.485-77",Telefones=994521459, Contrato= 1000003, Parcelas=1},
            new DevedorModel(){ Id=4, Nome="Germano Nascimento",  CPF="255.941.325-48",Telefones=971468255, Contrato= 1000004, Parcelas=3},
            new DevedorModel(){ Id=5, Nome="Herminia da Silva Souza",  CPF="669.988.756-32",Telefones=966559472, Contrato= 1000005, Parcelas=5},
            new DevedorModel(){ Id=6, Nome="Roberto Carlos",  CPF="601.239.878-X",Telefones=39026376, Contrato= 1000006, Parcelas=12}
        };
        public IActionResult Devedor()
        {
            return View(_listaDevedor);
        }

        [HttpPost]
        public IActionResult RecuperarDevedor(int id)
        {
            return Json(_listaDevedor.Find(x => x.Id == id));
        }
        [HttpPost]
        public IActionResult ExcluirDevedor(int id)
        {
            var ret = false;

            var registroDB = _listaDevedor.Find(x => x.Id == id);
            if (registroDB != null)
            {
                _listaDevedor.Remove(registroDB);
                ret = true;
            }
            return Json(ret);
        }
        [HttpPost]
        public IActionResult SalvarDevedor(DevedorModel model)
        {
            var registroBD = _listaDevedor.Find(x => x.Id == model.Id);

            if(registroBD == null)
            {
                registroBD = model;
                registroBD.Id = _listaDevedor.Max(x => x.Id) + 1;
                _listaDevedor.Add(registroBD);
            }
            else
            {
                registroBD.Nome = model.Nome;
                registroBD.CPF = model.CPF;
                registroBD.Telefones = model.Telefones;
                registroBD.Contrato = model.Contrato;
                registroBD.Parcelas = model.Parcelas;
            }
            return Json(registroBD);
        }
    }
}
