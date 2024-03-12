using System;
using FrameVioti.Elementos;
using FrameVioti.GerenciadorDriver;
using OpenQA.Selenium.Support.UI;

namespace FrameVioti.Pages
{
    public class ExemploInsercaoArquivos : ProdutosElementos
    {

        //########################### INICIO DO EXEMPLO DE INSERÇÃO ARQUIVOS #######################################

        private string ANEXO;


        //Exemplo para trabalhar com subida de arquivos na tela do DOM
        public ExemploInsercaoArquivos GerenciamentoArquivos()
        {
            //Para setar o caminho genérico para uma pasta (GerenciadorFiles) dentro do projeto mas fora da \bin\Debug
            string projetoPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
            string gerenciadorFilesPath = Path.Combine(projetoPath, "GerenciadorFiles");

            ANEXO = gerenciadorFilesPath;

            return this;

        }

        public ExemploInsercaoArquivos ExemploDeUsoArquivos()
        {
            //Exemplo de uso:
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(20));
            wait.Until((d) => d.FindElement(GetBtnCheckout()) != null);
            DriverFactory.GetDriver().FindElement(GetBtnCheckout()).SendKeys(Path.Combine(ANEXO, "ArquivoDesejado_xx-xx-2023.csv"));
            Console.WriteLine("Anexou com sucesso!!");

            return this;

        }
        //###### NÃO ESQUEÇA DE CRIAR A PASTA DESEJADA NO PROJETO !!!!!. #####
        //########################### FIM DO EXEMPLO ACIMA #######################################
    }
}


