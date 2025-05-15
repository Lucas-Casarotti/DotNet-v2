using System.Collections.Generic;
using Api.Models;
using System.Data;
using Dapper;
using System.Linq;
using Microsoft.Data.SqlClient;
using System;

namespace Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;

        public UsuarioRepository()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-3KK17LJ\\SQLEXPRESS;Initial Catalog=Projeto01;Integrated Security=True;TrustServerCertificate=True;");
        }

        public List<Usuarios> BuscarUsuarios()
        {
            try
            {
                _connection.Open();

                return _connection.Query<Usuarios>(@"SELECT * 
                                                     FROM dbo.Usuarios").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar usuários" + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Usuarios BuscarUsuario(int id_usuario)
        {
            try
            {
                _connection.Open();
 
                return _connection.QueryFirstOrDefault<Usuarios>(@"SELECT * 
                                                                   FROM dbo.Usuarios 
                                                                   WHERE ID_Usuario = @ID_Usuario", new { ID_Usuario = id_usuario });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar usuário" + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void InserirUsuario(Usuarios usuario)
        {
            try
            {
                _connection.Open();

                string sql = @"INSERT INTO dbo.Usuarios(NM_Usuario 
                                                       ,Email_Usuario
                                                       ,CD_Inscricao_Nacional)  
                               VALUES(@NM_Usuario 
                                     ,@Email_Usuario
                                     ,@CD_Inscricao_Nacional);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                usuario.ID_Usuario = _connection.Query<int>(sql, usuario).First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar usuário" + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AlterarUsuario(Usuarios usuario)
        {
            try
            {
                _connection.Open();

                string sql = @"UPDATE dbo.Usuarios 
                               SET NM_Usuario            = @NM_Usuario
                                  ,Email_Usuario         = @Email_Usuario
                                  ,CD_Inscricao_Nacional = @CD_Inscricao_Nacional
                               WHERE ID_Usuario = @ID_Usuario;";

                _connection.Execute(sql, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar usuário" + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void ExcluirUsuario(int id_usuario)
        {
            try
            {
                _connection.Open();

                _connection.Execute(@"DELETE 
                                      FROM dbo.Usuarios
                                      WHERE ID_Usuario = @ID_Usuario", new { ID_Usuario = id_usuario });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar usuário" + ex.Message);

            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
