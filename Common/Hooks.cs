using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using FrameVioti.Support;
using System;
using System.IO;
using TechTalk.SpecFlow;
using DinkToPdf;
using DinkToPdf.Contracts;
using FrameVioti.ExtentionMethods;
using OpenQA.Selenium;
using FrameVioti.GerenciadorDriver;

namespace FrameVioti.Common
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;
        private static readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string reportersPath = Path.Combine(basePath, "Reporters");
        private static readonly string reportDateTime = DateTime.Now.ToString("ddMMyyyy_HHmmss");
        private static readonly string reportFileName = $"ReportFrame_{reportDateTime}.html";
        private static readonly string reportPath = Path.Combine(reportersPath, reportFileName);

        private static readonly IConverter _converter = new SynchronizedConverter(new PdfTools());

        [BeforeTestRun]
        public static void ConfigureReport()
        {
            if (!Directory.Exists(reportersPath))
                Directory.CreateDirectory(reportersPath);

            var reporter = new ExtentHtmlReporter(reportPath);
            Console.WriteLine($"Caminho do arquivo de relatório: {reportPath}");

            _extent = new ExtentReports();
            _extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void CreateFeature()
        {
            _feature = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void CreateScenario()
        {
            _scenario = _feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
            {
                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                    _scenario.StepDefinitionGiven();
                    break;
                case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                    _scenario.StepDefinitionWhen();
                    break;
                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                    _scenario.StepDefinitionThen();
                    break;
            }
        }

        [AfterTestRun]
        public static void FlushExtent()
        {
            _extent.Flush();

            var indexFilePath = Path.Combine(reportersPath, "index.html");
            var desiredFilePath = Path.Combine(reportersPath, reportFileName);

            if (File.Exists(indexFilePath))
            {
                File.Move(indexFilePath, desiredFilePath);
            }

            Console.WriteLine($"Relatório gerado: {desiredFilePath}");

            if (File.Exists(desiredFilePath))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = desiredFilePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao abrir o relatório HTML: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("O arquivo HTML não foi encontrado para abrir.");
            }
        }
    }
}
