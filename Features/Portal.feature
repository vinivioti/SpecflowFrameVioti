    Feature: Site de testes online
  Como um analista ,
  Quero efetuar consultas no site de testes online 
  Para que tenhamos visão se o teste está funcionando corretamente

       
    
    Background:
    Given Que o usuario acesse o site 


    @LoginValido
	Scenario: Validar login valido
    When utilizo uma credencial valida
    Then  o sistema loga corretamente sem falhas

    @LoginInvalidoPassword
    Scenario: Validar login invalido - password invalida
    When utilizo uma credencial invalida password errado
    Then  o sistema nao loga e apresenta mensagem amigavel

       
    @ConsultasTelaCobrancaDeChips
	Scenario: Compra com sucesso
    When utilizo uma credencial valida
	When ordeno o filtro por Z a A 
    When escolho um produto
    When clico no carrinho de compras 
    When clico no checkout
    When preencho os dados de minhas informações continuando
    When clico em Finish
    Then o sistema apresenta mensagem Thank you for your order!
    
    

 