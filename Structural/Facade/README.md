Facade is a structural design pattern that provides a simplified interface to a library, a framework, or any other complex set of classes.


Aplicabilidade:
- Vários subsistemas + Integrações complexas + Muitas dependências + Ordem específica de execução
- Você quer esconder complexidade estrutural. E oferecer uma API simples para algo complexo.
- Use the Facade pattern when you need to have a limited but straightforward interface to a complex subsystem.
- Use the Facade when you want to structure a subsystem into layers.

O que o Facade NÃO é
- Não é Orchestrator complexo de domínio
- Não é Application Service rico
- Não contém regra de negócio profunda
-- Simplifica acesso a um conjunto de subsistemas.