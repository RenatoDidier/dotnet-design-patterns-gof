Proxy is a structural design pattern that lets you provide a substitute or placeholder for another object. A proxy controls access to the original object, allowing you to perform something either before or after the request gets through to the original object.


Aplicabilidade:
- Controlar acesso a um objeto + Adicionar lógica antes/depois da chamada + Proteger recurso sensível + Adiar carregamento (lazy loading) + Controlar acesso remoto
- Você quer intermediar acesso
- Existe recurso sensível ou pesado
- Precisa controlar ou proteger
- Lazy initialization (virtual proxy). This is when you have a heavyweight service object that wastes system resources by being always up, even though you only need it from time to time.
- Access control (protection proxy). This is when you want only specific clients to be able to use the service object; for instance, when your objects are crucial parts of an operating system and clients are various launched applications (including malicious ones).
- Local execution of a remote service (remote proxy). This is when the service object is located on a remote server.
- Logging requests (logging proxy). This is when you want to keep a history of requests to the service object.
- Caching request results (caching proxy). This is when you need to cache results of client requests and manage the life cycle of this cache, especially if results are quite large.
- Smart reference. This is when you need to be able to dismiss a heavyweight object once there are no clients that use it.

Um dos objetivos principais do Proxy é controlar acesso a um objeto. O objetivo dele é interceptar a chamada para um objeto real.

Imagine um serviço que consulta:
	Histórico completo de transações de um cliente

Isso pode:
- Bater no banco
- Consultar sistema legado
- Fazer chamada externa
- Ser extremamente pesado

Mas precisamos:
- Validar permissão
- Logar auditoria
- Cachear resultado
