using eCommerce.Models;

namespace eCommerce.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> BuscarUsuarios();
        public Usuario BuscarUsuario(int id);
        public void InserirUsuario(Usuario usuario);
        public void AlterarUsuario(Usuario usuario);
        public void ExcluirUsuario(int id);  
    }
}
