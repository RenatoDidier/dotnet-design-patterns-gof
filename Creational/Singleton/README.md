Singleton is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.

Use quando:
	- Existe exatamente uma instância lógica
	- Representa um recurso global
	- É stateless ou imutável
	- Não depende de contexto por requisição

No mercado financeiro, um bom exemplo é:
	Configuração global de mercado

Exemplo:
	- Fuso horário do mercado
	- Horário de abertura/fechamento
	- Dias úteis


Aplicabilidade:
	- Use the Singleton pattern when a class in your program should have just a single instance available to all clients; for example, a single database object shared by different parts of the program.
	- Use the Singleton pattern when you need stricter control over global variables.


O singleton pattern foi concebido numa época que o DI não existia nas linguagens, portanto na literatura sobre esse pattern não falam sobre a utilização do Singleton com DI, no entanto, atualmente, é completamente possível utilizar esse pattern com DI.
A sua estrutura clássica é utilizada em linguagens legadas principalmente.

* Singleton Pattern é controle de instância.
* DI Singleton é sobre controle de ciclo de vida de instâncias.