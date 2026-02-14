Observer is a behavioral design pattern that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.

Define uma dependência um-para-muitos
Quando o objeto principal muda de estado
Todos os observadores são notificados automaticamente

Quando o preço muda:
	- Atualiza carteira
	- Atualiza risco
	- Atualiza PnL
	- Atualiza dashboard
	- Dispara alerta

Aplicabilidade:
	- Use the Observer pattern when changes to the state of one object may require changing other objects, and the actual set of objects is unknown beforehand or changes dynamically.
	- Use the pattern when some objects in your app must observe others, but only for a limited time or in specific cases.