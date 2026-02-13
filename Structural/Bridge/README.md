Quando você tem:
- Uma abstração
- E múltiplas variações dessa abstração
- E múltiplas variações da implementação

Bridge is a structural design pattern that lets you split a large class or a set of closely related classes into two separate hierarchies—abstraction and implementation—which can be developed independently of each other.

Tipo de ativo × Provedor de dados
Tipo de ordem × Canal de execução
Tipo de cálculo × Fonte de preço
Tipo de relatório × Formato de exportação

Aplicabilidade:
- Você tem duas hierarquias que podem crescer independentemente
- Use the Bridge pattern when you want to divide and organize a monolithic class that has several variants of some functionality (for example, if the class can work with various database servers).
- Use the pattern when you need to extend a class in several orthogonal (independent) dimensions.
- Use the Bridge if you need to be able to switch implementations at runtime.