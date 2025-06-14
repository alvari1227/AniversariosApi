using AniversariosApi.Models;
using System.Xml.Linq;

namespace AniversariosApi.Services
{
    public class AniversarioService
    {
        private static List<Aniversario> aniversarios = new();
        private static int proximoId = 1;

        public List<Aniversario> Listar() => aniversarios;

        public Aniversario? Obter(int id) =>
            aniversarios.FirstOrDefault(a => a.Id == id);

        public Aniversario Criar(Aniversario novo)
        {
            novo.Id = proximoId++;
            aniversarios.Add(novo);
            return novo;
        }

        public bool Atualizar(int id, Aniversario atualizado)
        {
            var existente = Obter(id);
            if (existente == null) return false;

            existente.Nome = atualizado.Nome;
            existente.Data = atualizado.Data;
            existente.Observacao = atualizado.Observacao;
            return true;
        }

        public bool Remover(int id)
        {
            var aniversario = Obter(id);
            if (aniversario == null) return false;
            aniversarios.Remove(aniversario);
            return true;
        }
    }
}
