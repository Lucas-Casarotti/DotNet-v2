using eCommerce.Models;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace eCommerce.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dr;

        public UsuarioRepository()
        {
            con = new SqlConnection("Data Source=DESKTOP-3KK17LJ\\SQLEXPRESS;Initial Catalog=eCommerceAPI;Integrated Security=True");
        }

        public List<Usuario> BuscarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = @"SELECT * FROM Usuarios";
                command.Connection = con;
                dr = command.ExecuteReader();

                while(dr.Read())
                {
                    Usuario usuario          = new Usuario();
                    usuario.Id               = Convert.ToInt32(dr["Id"]);
                    usuario.Nome             = Convert.ToString(dr["Nome"]);
                    usuario.Email            = Convert.ToString(dr["Email"]);
                    usuario.Sexo             = Convert.ToString(dr["Sexo"]);
                    usuario.RG               = Convert.ToString(dr["RG"]);
                    usuario.CPF              = Convert.ToString(dr["CPF"]);
                    usuario.NomeMae          = Convert.ToString(dr["NomeMae"]);
                    usuario.SituacaoCadastro = Convert.ToString(dr["SituacaoCadastro"]);
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar usuário" + ex.Message);
            }
            finally 
            { 
                con.Close(); 
            };

            return usuarios;
        }

        public Usuario BuscarUsuario(int id)
        {
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = @"SELECT * 
                                        FROM dbo.Usuarios 
                                             LEFT JOIN dbo.Contatos
                                             ON Contatos.UsuarioId = Usuarios.Id
                                        WHERE Usuarios.Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.Connection = con;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id               = Convert.ToInt32(dr["Id"]);
                    usuario.Nome             = Convert.ToString(dr["Nome"]);
                    usuario.Email            = Convert.ToString(dr["Email"]);
                    usuario.Sexo             = Convert.ToString(dr["Sexo"]);
                    usuario.RG               = Convert.ToString(dr["RG"]);
                    usuario.CPF              = Convert.ToString(dr["CPF"]);
                    usuario.NomeMae          = Convert.ToString(dr["NomeMae"]);
                    usuario.SituacaoCadastro = Convert.ToString(dr["SituacaoCadastro"]);

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
                command.CommandText = @"INSERT INTO Usuarios(Nome 
                                                            ,Email
                                                            ,Sexo 
                                                            ,RG 
                                                            ,CPF 
                                                            ,NomeMae
                                                            ,SituacaoCadastro
                                                            ,DataCadastro)  
                                        VALUES(@Nome 
                                              ,@Email
                                              ,@Sexo 
                                              ,@RG 
                                              ,@CPF 
                                              ,@NomeMae
                                              ,@SituacaoCadastro
                                              ,@DataCadastro)";
                command.Parameters.AddWithValue("@Nome",             usuario.Nome);
                command.Parameters.AddWithValue("@Email",            usuario.Email);
                command.Parameters.AddWithValue("@Sexo",             usuario.Sexo);
                command.Parameters.AddWithValue("@RG",               usuario.RG);
                command.Parameters.AddWithValue("@CPF",              usuario.CPF);
                command.Parameters.AddWithValue("@NomeMae",          usuario.NomeMae);
                command.Parameters.AddWithValue("@SituacaoCadastro", usuario.SituacaoCadastro);
                command.Parameters.AddWithValue("@DataCadastro",     usuario.DataCadastro);
                command.Connection = con;
                command.ExecuteNonQuery();

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
            con.Open();
            command = new SqlCommand();
            command.CommandText = "UPDATE dbo.Usuarios SET Nome = @Nome WHERE Id= @v1";
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@v1", usuario.Id);
            command.Connection = con;
            command.ExecuteNonQuery();
        }

        public void ExcluirUsuario(int id)
        {
            try
            {
                con.Open();
                command = new SqlCommand();
                command.CommandText = "DELETE dbo.Usuarios WHERE Id = @v1";
                command.Parameters.AddWithValue("@v1", id);
                command.Connection = con;
                command.ExecuteNonQuery();
            }
            catch(Exception ex) 
            { 
                throw new Exception("Erro ao deletar usuário" + ex.Message);
            
            }finally 
            {
                con.Close();
            }
        }
    }
}
