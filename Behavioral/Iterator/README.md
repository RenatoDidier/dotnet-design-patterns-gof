Iterator is a behavioral design pattern that lets you traverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).

Percorre uma coleção sem expor sua estrutura interna.
	- Cliente não sabe se é List
	- Não sabe se é árvore
	- Não sabe se é banco
	- Não sabe se é stream

Aplicabilidade:
	- Use the Iterator pattern when your collection has a complex data structure under the hood, but you want to hide its complexity from clients (either for convenience or security reasons).
	- Use the pattern to reduce duplication of the traversal code across your app.
	- Use the Iterator when you want your code to be able to traverse different data structures or when types of these structures are unknown beforehand.

