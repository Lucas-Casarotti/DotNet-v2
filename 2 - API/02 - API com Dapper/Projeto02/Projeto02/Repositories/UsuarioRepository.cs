using System.Collections.Generic;
using System;
using Api.Models;
using System.Data;
using Dapper;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;

        public UsuarioRepository()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-3KK17LJ\\SQLEXPRESS;Initial Catalog=Projeto01;Integrated Security=True;TrustServerCertificate=True;");
        }

        public List<Usuario> BuscarUsuarios()
        {
            return _connection.Query<Usuario>("SELECT * FROM dbo.Usuarios").ToList();
        }

        public Usuario BuscarUsuario(int id_usuario)
        {
            return _connection.QueryFirstOrDefault<Usuario>("SELECT * FROM dbo.Usuarios WHERE ID_Usuario = @ID_Usuario", new { ID_Usuario = id_usuario });
        }

        public void InserirUsuario(Usuario usuario)
        {
            string sql = @"INSERT INTO Usuarios(NM_Usuario 
                                               ,Email_Usuario
                                               ,CD_Inscricao_Nacional)  
                           VALUES(@NM_Usuario 
                                 ,@Email_Usuario
                                 ,@CD_Inscricao_Nacional);
                           SELECT CAST(SCOPE_IDENTITY() AS INT)";
            
            usuario.ID_Usuario = _connection.Query<int>(sql, usuario).First();
        }

        public void AlterarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void ExcluirUsuario(int id_usuario)
        {
            throw new NotImplementedException();
        }
    }
}
