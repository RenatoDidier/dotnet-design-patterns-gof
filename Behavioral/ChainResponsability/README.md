Chain of Responsibility is a behavioral design pattern that lets you pass requests along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.

Chain of Responsibility é muito usado em sistemas financeiros, principalmente para:
	- Validações em pipeline
	- Aprovação de crédito
	- Processamento de ordens
	- Regras regulatórias
	- Antifraude

Antes da execução, ela precisa passar por várias validações:
	- Validar horário de mercado
	- Validar saldo do cliente
	- Validar limite de risco
	- Validar compliance
Essas validações:
	- Devem ser encadeadas
	- Devem ser independentes
	- Devem poder ser adicionadas/removidas
	- Não devem virar um if gigante


Aplicabilidade:
	- Você tem um pipeline de processamento && Onde múltiplos passos podem validar, modificar ou interromper.
	- Use the Chain of Responsibility pattern when your program is expected to process different kinds of requests in various ways, but the exact types of requests and their sequences are unknown beforehand.
	- Use the pattern when it’s essential to execute several handlers in a particular order.
	- Use the CoR pattern when the set of handlers and their order are supposed to change at runtime.