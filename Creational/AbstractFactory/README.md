Abstract Factory is a creational design pattern that lets you produce families of related objects without specifying their concrete classes.

A diferença chave para Factory comum é:
- Factory comum → cria um objeto
- Abstract Factory → cria conjunto coerente de objetos


Aplicabilidade:
- Use the Abstract Factory when your code needs to work with various families of related products, but you don’t want it to depend on the concrete classes of those products—they might be unknown beforehand or you simply want to allow for future extensibility.
- Consider implementing the Abstract Factory when you have a class with a set of Factory Methods that blur its primary responsibility.
- Existem múltiplas famílias de objetos && Esses objetos precisam ser compatíveis && Você quer garantir consistência entre eles
