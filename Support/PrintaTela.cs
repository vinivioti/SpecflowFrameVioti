using FrameVioti.GerenciadorDriver;
using OpenQA.Selenium;
using System;
using System.IO;

namespace FrameVioti.Support
{
    public class PrintaTela
    {
        public void TakeScreenshot()
        {
            try
            {
                string pastaProjeto = AppDomain.CurrentDomain.BaseDirectory;
                string pastaEvidencias = Path.Combine(pastaProjeto, "Evidencias");

                // Obter a data e hora atual
                DateTime dataAtual = DateTime.Now;

                // Criar o nome da pasta com base na data e hora atual
                string nomePastaData = dataAtual.ToString("dd-MM-yyyy");

                // Combinar o caminho da pasta Evidencias com o nome da pasta de data
                string caminhoPastaData = Path.Combine(pastaEvidencias, nomePastaData);

                // Certificar-se de que a pasta da data existe, caso contrário, criar
                if (!Directory.Exists(caminhoPastaData))
                    Directory.CreateDirectory(caminhoPastaData);

                Screenshot ss = ((ITakesScreenshot)DriverFactory.GetDriver(BrowserType.Chrome)).GetScreenshot();

                string nomeArquivo = dataAtual.ToString("dd-MM-yyyy-HHmmss");
                string caminhoArquivo = Path.Combine(caminhoPastaData, $"Evidencia-{nomeArquivo}.png");
                ss.SaveAsFile(caminhoArquivo, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


    }
}
