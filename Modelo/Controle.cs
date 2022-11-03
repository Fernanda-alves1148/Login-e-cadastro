
using Login.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Login.Modelo
{
    public class Controle
    {
        public bool tem;
        public string mensagem ="";
        public bool acessar(String login, String senha)
        {
            // instanceia a classe 
            LoginDalComandos loginDal = new LoginDalComandos();
            // usa o metodo verificarLogin da classe LoginDalComandos 
            tem = loginDal.verificarLogin(login, senha);
            //verifica se a variavel mensagem esta vasia ou seja se não tem erros
            if(!loginDal.mensagem.Equals(""))
            {
                this.mensagem = loginDal.mensagem;

            }
            return tem;
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            this.mensagem = loginDal.cadastrar(email, senha, confSenha);
            if (loginDal.tem)
            {
                this.tem = true;
            }
            return mensagem;
            
        }
    }
}
