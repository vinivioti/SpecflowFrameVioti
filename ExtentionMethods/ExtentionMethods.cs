using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using FrameVioti.GerenciadorDriver;
using FrameVioti.Support;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow.Bindings;

namespace FrameVioti.ExtentionMethods
{
    public static class ScenarioExtensionMethod
    {
        private static ExtentTest CreateScenario(ExtentTest extent, StepDefinitionType stepDefinitionType)
        {
            var scenarioStepContext = ScenarioStepContext.Current.StepInfo.Text;
            ExtentTest stepNode = null;

            switch (stepDefinitionType)
            {
                case StepDefinitionType.Given:
                    stepNode = extent.CreateNode<Given>(scenarioStepContext);
                    break;

                case StepDefinitionType.When:
                    stepNode = extent.CreateNode<When>(scenarioStepContext);
                    break;

                case StepDefinitionType.Then:
                    stepNode = extent.CreateNode<Then>(scenarioStepContext);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null);
            }

            // Adicionar a captura de tela como Base64 logo após criar o passo
            AddScreenshotAsBase64(stepNode, stepNode.Model.Name);
            return stepNode;
        }

        private static void CreateScenarioFailOrError(ExtentTest extent, StepDefinitionType stepDefinitionType)
        {
            var error = ScenarioContext.Current.TestError;

            if (error.InnerException == null)
            {
                CreateScenario(extent, stepDefinitionType).Error(error.Message);
            }
            else
            {
                CreateScenario(extent, stepDefinitionType).Fail(error.InnerException);
            }
        }

        public static void StepDefinitionGiven(this ExtentTest extent)
        {
            if (ScenarioContext.Current.TestError == null)
            {
                CreateScenario(extent, StepDefinitionType.Given);
            }
            else
            {
                CreateScenarioFailOrError(extent, StepDefinitionType.Given);
            }
        }

        public static void StepDefinitionWhen(this ExtentTest extent)
        {
            if (ScenarioContext.Current.TestError == null)
            {
                CreateScenario(extent, StepDefinitionType.When);
            }
            else
            {
                CreateScenarioFailOrError(extent, StepDefinitionType.When);
            }
        }

        public static void StepDefinitionThen(this ExtentTest extent)
        {
            if (ScenarioContext.Current.TestError == null)
            {
                CreateScenario(extent, StepDefinitionType.Then);
            }
            else
            {
                CreateScenarioFailOrError(extent, StepDefinitionType.Then);
            }
        }

        // Método auxiliar para capturar e anexar screenshot como Base64
        private static void AddScreenshotAsBase64(ExtentTest extent, string stepName)
        {
            var printaTela = new PrintaTela();
            string screenshotBase64 = printaTela.CaptureScreenshotAsBase64();
            extent.AddScreenCaptureFromBase64String(screenshotBase64, $"Screenshot_{stepName}");

            string imgHtml = $"<img src='data:image/png;base64,{screenshotBase64}' width='300' height='150' />";
            extent.Log(Status.Pass, "Evidência: " + imgHtml); // Ajuste para adicionar como uma miniatura
        }

    }
}
