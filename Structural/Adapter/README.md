Adapter converte a interface de uma classe em outra interface esperada pelo cliente, permitindo que classes incompatíveis trabalhem juntas.



An adapter wraps one of the objects to hide the complexity of conversion happening behind the scenes. The wrapped object isn’t even aware of the adapter. For example, you can wrap an object that operates in meters and kilometers with an adapter that converts all of the data to imperial units such as feet and miles.



Aplicabilidade:

Use the Adapter class when you want to use some existing class, but its interface isn’t compatible with the rest of your code.

Use the pattern when you want to reuse several existing subclasses that lack some common functionality that can’t be added to the superclass.



