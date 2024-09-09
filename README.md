# SpecflowFrameVioti

## Solução utilizando Specflow+Selenium+Nunit com geração de evidências e Report

- Baixe o projeto na sua máquina. 
- Instale o Nuget caso não tenha ainda
- Instale o Specflow caso não tenha ainda (Para perfeito funcionamento, instale no Visual Studio via Marketplace)
- Abra o projeto com o Visual Studio
- Abra a Solução Frame`Front.sln
- Abra o terminal ou o prompt de comando e rode o comando: dotnet restore
- Compile a solução
- Vá em Gerenciador de testes e rode os testes de exemplo que estão prontos.
- Para rodar Headless vá na classe *DriverFactory.cs* dentro do *GerenciadorDriver* e descomente a linha<br/> " options.AddArgument("--headless"); "
- Para escolher o navegador pretendido, vá na classe *DriverFactory.cs* e escolha o navegador preferido no BrowserType.<suaEscolhaNavegador>, por default está o Chrome. (Você precisa ter os navegadores instalados na sua máquina local, os drivers serão atualizados automaticamente)

Após rodar os testes, as evidencias e o report estarão salvos dentro da pasta bin do projeto:<br/>
*\bin\Debug\net6.0\Evidencias<br/>
*\bin\Debug\net6.0\Reporters

Espero que gostem e fiquem à vontade para utilizar como base.<br/>
--> Melhorias sempre serão bem vindas!. 

Abs
Vioti<br/>
  
  ### Diário de Melhorias efetuadas no projeto ###

** **09/09/2024** ** - Atualização classes Hooks, ExtentionMethods e PrintaTela para que o Report possa ser gerado com evidências de teste fixados. Quando enviar o Report, as evidências não se perderão.<br/>
** **31/05/2023** ** - Atualização da classe DriverFactory:<br/>
- Agora pode ser utilizado os navegadores Chrome, Firefox e Edge nas execução dos testes. <br/>
- Atualização da classe PrintaTela para suportar os novos navegadores no momento de capturar imagens.<br/>   
** **03/06/2023** ** - Inclusão da Biblioteca FAKER e Alteração para leitura e manipulação arquivos XLS,CSV,Word e PDF.<br/>
** **26/06/2023** ** - Alteração da classe PrintaTela para organizar e salvar na pasta do dia do teste.<br/>
** **12/07/2023** ** - Inclusão de um exemplo de como inserir um arquivo no DOM na classe ProdutosPage utilizando caminho genérico para chegar até o arquivo desejado, e adição da pasta GerenciadorFiles diretamente no projeto<br/>
** **12/03/2024** ** - Refatoração do codigo e adicao da BasePage com os métodos de limpeza de campos, escrita etc.<br/>
** **08/05/2024** ** - Melhoria na classe ExtentionMethods para considerar as exceptions como falha no relatório.<br/>


