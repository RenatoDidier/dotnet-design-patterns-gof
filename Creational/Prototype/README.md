Prototype is a creational design pattern that lets you copy existing objects without making your code dependent on their classes.
O objeto precisa ser imutável e o clone precisa ser um deep copy.

Imagine que você tem um modelo padrão de:
	Ordem institucional complexa
		Ela já vem com:
			- Regras padrão
			- Taxas padrão
			- Tipo de liquidação
	Configuração de risco
	Mas cada cliente pode:
		- Alterar quantidade
		- Alterar preço
		- Alterar validade
	Você não quer:
		- Reconstruir o objeto inteiro toda vez
		- Duplicar lógica de configuração
		- Reaplicar todas as regras manualmente

Aplicabilidade:
	- Use the Prototype pattern when your code shouldn’t depend on the concrete classes of objects that you need to copy.
	- Use the pattern when you want to reduce the number of subclasses that only differ in the way they initialize their respective objects.
