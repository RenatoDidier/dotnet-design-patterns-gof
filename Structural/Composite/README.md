Vantagens:
- Simplifica código cliente
- Remove condicionais
- Suporta estruturas recursivas naturais
- Excelente para modelagem de domínio

Desvantagens:
- Pode ficar pesado se árvore for muito grande
- Cuidado com performance em estruturas profundas
- Pode exigir caching

Composite is a structural design pattern that lets you compose objects into tree structures and then work with these structures as if they were individual objects.

Using the Composite pattern makes sense only when the core model of your app can be represented as a tree. For example, imagine that you have two types of objects: Products and Boxes. A Box can contain several Products as well as a number of smaller Boxes. These little Boxes can also hold some Products or even smaller Boxes, and so on.

Aplicabilidade:
 Use the Composite pattern when you have to implement a tree-like object structure.
 Use the pattern when you want the client code to treat both simple and complex elements uniformly.