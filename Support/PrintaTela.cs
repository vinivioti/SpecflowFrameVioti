using FrameVioti.GerenciadorDriver;
using OpenQA.Selenium;
using System;
using System.IO;

namespace FrameVioti.Support
{
    public class PrintaTela
    {
        // Método para capturar screenshot e salvar em arquivo
        public string TakeScreenshot()
        {
            try
            {
                string pastaProjeto = AppDomain.CurrentDomain.BaseDirectory;
                string pastaEvidencias = Path.Combine(pastaProjeto, "Evidencias");

                // Obter a data e hora atual
                DateTime dataAtual = DateTime.Now;
                string nomePastaData = dataAtual.ToString("dd-MM-yyyy");
                string caminhoPastaData = Path.Combine(pastaEvidencias, nomePastaData);

                // Certificar-se de que a pasta da data existe, caso contrário, criar
                if (!Directory.Exists(caminhoPastaData))
                    Directory.CreateDirectory(caminhoPastaData);

                Screenshot ss = ((ITakesScreenshot)DriverFactory.GetDriver(BrowserType.Edge)).GetScreenshot();

                string nomeArquivo = dataAtual.ToString("dd-MM-yyyy-HHmmss");
                string caminhoArquivo = Path.Combine(caminhoPastaData, $"Evidencia-{nomeArquivo}.png");
                ss.SaveAsFile(caminhoArquivo, ScreenshotImageFormat.Png);
                return caminhoArquivo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Método para capturar screenshot e retornar como Base64
        public string CaptureScreenshotAsBase64()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)DriverFactory.GetDriver(BrowserType.Edge)).GetScreenshot();
                return ss.AsBase64EncodedString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
