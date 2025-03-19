using Api.Models;
using System.Collections.Generic;

namespace Api.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuarios> BuscarUsuarios();
        public Usuarios BuscarUsuario(int id_usuario);
        public void InserirUsuario(Usuarios usuario);
        public void AlterarUsuario(Usuarios usuario);
        public void ExcluirUsuario(int id_usuario);
    }
}
