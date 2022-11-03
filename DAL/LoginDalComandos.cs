using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.DAL
{
    class LoginDalComandos
    {
        public bool tem = false;
        public string mensagem ="";

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        Conexao con = new Conexao();
        public bool verificarLogin(String login, String senha)
        {
            //neste metodo vão os comandos sql para verificar se tem no banco 

            cmd.CommandText = "select * from login where email = @login and senha = @senha;";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados!";
                throw;
            }
            return tem;

        }
        
        public String cadastrar(String email, String senha, String confSenha)
        {
            tem = false;
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into login values (@email, @senha);";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "Cadastrado com sucesso!";
                    tem = true;
                }
                catch (SqlException)
                {
                    this.mensagem = "Erro com o banco de dados";
                }
            }
            else
            {
                this.mensagem = "As senhas não correspondem";
            }
            return mensagem;
        }
    }
}
