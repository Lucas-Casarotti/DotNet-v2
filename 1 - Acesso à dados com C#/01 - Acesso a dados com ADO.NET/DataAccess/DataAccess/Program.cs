using System;
using System.Data.SqlClient;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con;
            SqlCommand Cmd;
            SqlDataReader Dr;

            con = new SqlConnection("Data Source=DESKTOP-3KK17LJ\\SQLEXPRESS;Initial Catalog=Pessoas;Integrated Security=True");

            int continua = 1;
            while (continua == 1)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Funcionalidades");
                Console.WriteLine("1 - Cadastrar usuário");
                Console.WriteLine("2 - Atualizar usuário");
                Console.WriteLine("3 - Excluir usuário");
                Console.WriteLine("4 - Listar usuários");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("------------------------------------");
                Console.Write("Escolha uma funcionalidade:");
                int opc = Convert.ToInt32(Console.ReadLine());

                if (opc == 1)
                {
                    Console.Write("Nome: ");
                    string Nome = Console.ReadLine();
                    Console.Write("Endereço: ");
                    string Endereco = Console.ReadLine();
                    Console.Write("Email: ");
                    string Email = Console.ReadLine();

                    try
                    {
                        con.Open();
                        string sql = @"INSERT INTO dbo.Pessoas (Nome, Endereco, Email) VALUES (@V1, @V2, @V3)";
                        Cmd = new SqlCommand(sql, con);
                        Cmd.Parameters.AddWithValue("@V1", Nome);
                        Cmd.Parameters.AddWithValue("@V2", Endereco);
                        Cmd.Parameters.AddWithValue("@V3", Email);
                        Cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao gravar usuário: " + ex.Message);
                    }
                    finally 
                    {
                        Console.WriteLine("Usuário cadastrado!");
                        con.Close(); 
                    }

                }
                else if (opc == 2)
                {
                    Console.Write("Informe o código do usuário: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Digite o número de qual campo deseja alterar");
                    Console.WriteLine("1 - Nome");
                    Console.WriteLine("2 - Endereço");
                    Console.WriteLine("3 - Email");
                    Console.Write(":");
                    int opcAtualizar = Convert.ToInt32(Console.ReadLine());

                    if (opcAtualizar == 1)
                    {
                        Console.Write("Digite o novo nome: ");
                        string nome = Console.ReadLine();

                        try
                        {
                            con.Open();
                            string sql = @"UPDATE dbo.Pessoas SET Nome = @V1 WHERE Codigo = @V2";
                            Cmd = new SqlCommand(sql, con);
                            Cmd.Parameters.AddWithValue("@V1", nome);
                            Cmd.Parameters.AddWithValue("@V2", codigo);
                            Cmd.ExecuteNonQuery();
                        }
                        catch(Exception ex) {

                            throw new Exception("Erro ao atualizar usuário: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        
                    }
                    else if (opcAtualizar == 2)
                    {
                        Console.Write("Digite o novo endereço: ");
                        string endereco = Console.ReadLine();

                        try
                        {
                            con.Open();
                            string sql = @"UPDATE dbo.Pessoas SET Endereco = @V1 WHERE Codigo = @V2";
                            Cmd = new SqlCommand(sql, con);
                            Cmd.Parameters.AddWithValue("@V1", endereco);
                            Cmd.Parameters.AddWithValue("@V2", codigo);
                            Cmd.ExecuteNonQuery();
                        }
                        catch(Exception ex)
                        {
                            throw new Exception("Erro ao atualizar usuário: " + ex.Message);
                        }
                        finally 
                        { 
                            con.Close(); 
                        }
                    }
                    else if (opcAtualizar == 3)
                    {
                        Console.Write("Digite o novo email: ");
                        string email = Console.ReadLine();

                        try
                        {
                            con.Open();
                            string sql = @"UPDATE dbo.Pessoas SET Email = @V1 WHERE Codigo = @V2";
                            Cmd = new SqlCommand(sql, con);
                            Cmd.Parameters.AddWithValue("@V1", email);
                            Cmd.Parameters.AddWithValue("@V2", codigo);
                            Cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao atualizar usuário: " + ex.Message);
                        }
                        finally 
                        { 
                            con.Close(); 
                        }
                    }
                }
                else if (opc == 3)
                {
                    Console.Write("Informe o código do usuário: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Deseja realmente excluir esse usuário?");
                    Console.WriteLine("1 - Sim 2 - Não");
                    Console.Write(": ");
                    int opcExcluir = Convert.ToInt32(Console.ReadLine());   
                    if (opcExcluir == 1)
                    {
                        try
                        {
                            con.Open();
                            string sql = @"DELETE FROM dbo.Pessoas WHERE Codigo = @V1";
                            Cmd = new SqlCommand(sql, con);
                            Cmd.Parameters.AddWithValue("@V1", codigo);
                            Cmd.ExecuteNonQuery();
                        }
                        catch(Exception ex)
                        {
                            throw new Exception("Erro ao excluir usuário: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                    else if(opc == 2) 
                    {
                        Console.WriteLine("Usuário não excluído");
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção valida");
                    }
                }
                else if (opc == 4)
                {
                    try
                    {
                        con.Open();
                        string sql = @"SELECT * FROM dbo.Pessoas ORDER BY Codigo ASC";
                        Cmd = new SqlCommand(sql, con);
                        Dr = null;
                        Dr = Cmd.ExecuteReader();

                        while (Dr.Read())
                        {
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Código:   " + Convert.ToInt32(Dr[0]));
                            Console.WriteLine("Nome:     " + Convert.ToString(Dr[1]));
                            Console.WriteLine("Endereço: " + Convert.ToString(Dr[2]));
                            Console.WriteLine("E-mail:   " + Convert.ToString(Dr[3]));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao listar usuários: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    
                }
                else if (opc == 5)
                {
                    Console.WriteLine("Programa finalizado");
                    continua++;
                }
                else
                {
                    Console.WriteLine("Selecione uma funcionalidade existente");
                }
            }
        }
    }
}
