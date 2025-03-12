using Api.Models;
using System.Collections.Generic;

namespace Api.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> BuscarUsuarios();
        public Usuario BuscarUsuario(int id_usuario);
        public void InserirUsuario(Usuario usuario);
        public void AlterarUsuario(Usuario usuario);
        public void ExcluirUsuario(int id_usuario);
    }
}
