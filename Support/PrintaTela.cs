using FluentAssertions.Extensions;
using FrameVioti.GerenciadorDriver;
using NPOI.SS.Util;
using OpenQA.Selenium;
using System.IO;
using System;

namespace FrameVioti.Support
{
    public class PrintaTela
    {
        public void TakeScreenshot(BrowserType browserType = BrowserType.Chrome)
        {
            try
            {
                // ***** Salva na pasta Evidencias dentro da pasta bin->Debug->net.6.0 *** //

                // Obter o diretório base do projeto
                string pastaProjeto = AppDomain.CurrentDomain.BaseDirectory;

                // Construir o caminho para a pasta Evidencias
                string pastaEvidencias = Path.Combine(pastaProjeto, "Evidencias");

                // Certificar-se de que a pasta Evidencias existe, caso contrário, criar
                if (!Directory.Exists(pastaEvidencias))
                    Directory.CreateDirectory(pastaEvidencias);

                using (IWebDriver driver = DriverFactory.GetDriver(browserType))
                {
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                    DateTime dataAtual = DateTime.Now;
                    string filename = dataAtual.ToString("dd-MM-yyyy-hhmmss");
                    string caminhoArquivo = Path.Combine(pastaEvidencias, $"Evidencia-{filename}.png");
                    ss.SaveAsFile(caminhoArquivo, ScreenshotImageFormat.Png);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
