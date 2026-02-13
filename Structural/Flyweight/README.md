Flyweight is a structural design pattern that lets you fit more objects into the available amount of RAM by sharing common parts of state between multiple objects instead of keeping all of the data in each object.
Um padrão menos usado, mas extremamente poderoso quando há alto volume de objetos repetitivos. Flyweight deve ser imutável.

Flyweight geralmente fica no Domain
Factory pode ficar na Infrastructure se envolver cache distribuído
Pode usar ConcurrentDictionary para alta concorrência

Aplicabilidade:
- Milhões de objetos + Grande repetição de dados + Alto consumo de memória
- Use the Flyweight pattern only when your program must support a huge number of objects which barely fit into available RAM.