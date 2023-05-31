# SpecflowFrameVioti

## Solução utilizando Specflow+Selenium+Nunit com geração de evidências e Report

- Baixe o projeto na sua máquina. 
- Instale o Nuget e Specflow caso não tenha ainda
- Abra o projeto com o Visual Studio
- Abra a Solução Frame`Front.sln
- Compile a solução
- Vá em Gerenciador de testes e rode os testes de exemplo que estão prontos.
- Para rodar Headless vá na classe *DriverFactory.cs* dentro do *GerenciadorDriver* e descomente a linha<br/> " options.AddArgument("--headless"); "
- Para escolher o navegador pretendido, vá na DriverFactory e escolha o navegador preferido no BrowserType.<suaEscolhaNavegador>, por default está o Chrome. (Você precisa ter os navegadores instalados na sua máquina local, os drivers serão atualizados automaticamente)


Após rodar os testes, as evidencias e o report estarão salvos dentro da pasta bin do projeto:<br/>
*\bin\Debug\net6.0\Evidencias<br/>
*\bin\Debug\net6.0\Reporters

Espero que gostem e fiquem à vontade para utilizar como base. Melhorias sempre serão bem vindas. 

Abs
Vioti

** 31/05/2023 - Atualização da classe DriverFactory:<br/>
- Agora pode ser utilizado os navegadores Chrome, Firefox e Edge nas execução dos testes. <br/>
- Atualização da classe PrintaTela para suportar os novos navegadores no momento de capturar imagens. 
