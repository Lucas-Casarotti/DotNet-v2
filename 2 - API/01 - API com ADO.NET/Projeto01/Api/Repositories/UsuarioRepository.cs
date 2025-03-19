using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Api.Models;

namespace Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dr;

        public UsuarioRepository()
        {
            con = new SqlConnection("Data Source=DESKTOP-3KK17LJ\\SQLEXPRESS;Initial Catalog=Projeto01;Integrated Security=True");
        }

        public List<Usuario> BuscarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = @"SELECT * FROM dbo.Usuarios;";
                command.Connection = con;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.ID_Usuario            = Convert.ToInt32(dr["ID_Usuario"]);
                    usuario.NM_Usuario            = Convert.ToString(dr["NM_Usuario"]);
                    usuario.Email_Usuario         = Convert.ToString(dr["Email_Usuario"]);
                    usuario.CD_Inscricao_Nacional = Convert.ToString(dr["CD_Inscricao_Nacional"]);
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar usuários" + ex.Message);
            }
            finally
            {
                con.Close();
            };

            return usuarios;
        }

        public Usuario BuscarUsuario(int id_usuario)
        {
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = @"SELECT * 
                                        FROM dbo.Usuarios 
                                        WHERE Usuarios.ID_Usuario = @ID_Usuario;";
                command.Parameters.AddWithValue("@ID_Usuario", id_usuario);
                command.Connection = con;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.ID_Usuario            = Convert.ToInt32(dr["ID_Usuario"]);
                    usuario.NM_Usuario            = Convert.ToString(dr["NM_Usuario"]);
                    usuario.Email_Usuario         = Convert.ToString(dr["Email_Usuario"]);
                    usuario.CD_Inscricao_Nacional = Convert.ToString(dr["CD_Inscricao_Nacional"]);

                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar usuário" + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public void InserirUsuario(Usuario usuario)
        {
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = @"INSERT INTO Usuarios(NM_Usuario 
                                                            ,Email_Usuario
                                                            ,CD_Inscricao_Nacional)  
                                        VALUES(@NM_Usuario 
                                              ,@Email_Usuario
                                              ,@CD_Inscricao_Nacional);
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
                command.Parameters.AddWithValue("@NM_Usuario",            usuario.NM_Usuario);
                command.Parameters.AddWithValue("@Email_Usuario",         usuario.Email_Usuario);
                command.Parameters.AddWithValue("@CD_Inscricao_Nacional", usuario.CD_Inscricao_Nacional);
                command.Connection = con;

                usuario.ID_Usuario = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar usuário" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void AlterarUsuario(Usuario usuario)
        {
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = @"UPDATE dbo.Usuarios SET NM_Usuario            = @NM_Usuario
                                                               ,Email_Usuario         = @Email_Usuario
                                                               ,CD_Inscricao_Nacional = @CD_Inscricao_Nacional
                                        WHERE ID_Usuario = @ID_Usuario;";
                command.Parameters.AddWithValue("@NM_Usuario",   usuario.NM_Usuario);
                command.Parameters.AddWithValue("@Email_Usuario", usuario.Email_Usuario);
                command.Parameters.AddWithValue("@CD_Inscricao_Nacional", usuario.CD_Inscricao_Nacional);
                command.Parameters.AddWithValue("@ID_Usuario", usuario.ID_Usuario);
                command.Connection = con;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar usuário" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void ExcluirUsuario(int id_usuario)
        {
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = @"DELETE dbo.Usuarios 
                                        WHERE ID_Usuario = @ID_Usuario;";
                command.Parameters.AddWithValue("@ID_Usuario", id_usuario);
                command.Connection = con;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar usuário" + ex.Message);

            }
            finally
            {
                con.Close();
            }
        }
    }
}
