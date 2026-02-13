Memento is a behavioral design pattern that lets you save and restore the previous state of an object without revealing the details of its implementation.

No mercado financeiro isso aparece bastante em:
	- Simulações
	- Engines de risco
	- Backtesting
	- Ordens com possibilidade de cancelamento
	- Reprocessament

Estrutura clássica:
	- Originator (objeto que guarda estado)
	- Memento (snapshot do estado)
	- Caretaker (quem gerencia os snapshots)

Aplicabilidade:
	- Capturar estado interno
	- Restaurar estado anterior
	- Implementar rollback
	- Criar snapshot
	- Use the Memento pattern when you want to produce snapshots of the object’s state to be able to restore a previous state of the object
	- Use the pattern when direct access to the object’s fields/getters/setters violates its encapsulation