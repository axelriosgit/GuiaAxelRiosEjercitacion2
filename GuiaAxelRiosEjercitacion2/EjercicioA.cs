// ----------------------
// SECCION A - Pregunta 1
// Respuesta : c) El constructor private AppLogger() { }
// ¿Por qué? : al no tener "private" en el constructor anula la capacidad de otras clases de utilizar la palabra reservada "new", obligando a todo el sistema a pedir la instancia a través del punto de acceso global de la clase.

// ----------------------
// SECCION A - Pregunta 2
// Respuesta : a) La instancia se crea la primera vez que alguien la pide, no antes
// ¿Por qué? : "Perezosa" implica postergar el consumo de recursos hasta que sea estrictamente necesario. Si el programa se ejecuta y nadie usa el Singleton, el objeto jamás llega a ocupar memoria.
// ¿Por que no es la opcion C? : La opción C describe una instanciación múltiple, lo cual destruye el propósito principal del patrón de mantener y proteger una única copia global.

// ----------------------
// SECCION A - Pregunta 3
// Respuesta : d) Reemplazar un condicional que elige entre variantes de un algoritmo por clases intercambiables detrás de una interfaz
// ¿Por qué? : Strategy encapsula el "cómo" se hace algo aislando cada variante en su propia clase, lo que permite cambiar el comportamiento dinámicamente sin tocar la lógica central.
// ¿Por que no es la opcion A? : Asegurar una única instancia es la responsabilidad de Singleton, un patrón creacional que no tiene relación con el intercambio de algoritmos en ejecución.

// ----------------------
// SECCION A - Pregunta 4
// Respuesta : b) Usa una estrategia a través de la interfaz y le delega el cálculo, sin saber cuál es
// ¿Por que? : El contexto actúa como un cliente ciego: solo sabe que posee un objeto que respeta un contrato (la interfaz), por ende le cede el control de la acción sin preocuparse de los detalles internos.
// ¿Por que no es la opcion D? : Mantener un switch dentro del contexto para decidir la operación es justamente el antipatrón de diseño que Strategy viene a solucionar.

// ----------------------
// SECCION A - Pregunta 5
// Respuesta : c) El medio de pago llega como texto ("QR", "EFECTIVO") desde un ComboBox y desde un JSON, y hay que crear el objeto correcto en varios lugares
// ¿Por que? : Cuando el tipo exacto a instanciar se decide en tiempo de ejecución en base a un string o parámetro, y además se repite, la Factory centraliza esa lógica de traducción de "dato" a "objeto".

// ----------------------
// SECCION A - Pregunta 
// Respuesta : a) En Factory Method, una superclase con lógica de negocio declara el método de creación y cada subclase decide qué producto concreto crear
// ¿Por que? : Simple Factory es solo una clase con un gran condicional estático. Factory Method (el patrón real del GoF) usa la herencia para que sean las clases hijas las que definan la instanciación mediante polimorfismo.

// ----------------------
// SECCION A - Pregunta 7
// Respuesta : b) Una lista de referencias a objetos que implementan la interfaz suscriptora
// ¿Por que? : El principio fundamental del Observer es el bajo acoplamiento. El notificador no puede depender de clases concretas; solo almacena una colección de punteros genéricos que respetan el contrato de la interfaz.

// ----------------------
// SECCION A - Pregunta 8
// Respuesta : d) El controller le sigue avisando a un formulario destruido: puede saltar una excepción y el objetonunca se libera de memoria
// ¿Por que? : Al no borrarse de la lista interna, el notificador retiene una referencia activa al formulario. Esto genera un "memory leak" (fuga de memoria) y hace que el programa falle al intentar actualizar una vista cerrada.

// ----------------------
// SECCION A - Pregunta 9
// Respuesta : b) Suscriptor
// ¿Por que? : El botón actúa como el origen del evento (el notificador), y el método `btnGuardar_Click` es la porción de código que se "engancha" para escuchar y reaccionar, asumiendo el rol de suscriptor.

// ----------------------
// SECCION A - Pregunta 10
// Respuesta : c) Creás una clase que implementa la interfaz suscriptora y la suscribís en Program.cs
// ¿Por que? : Cumplir con Open/Closed significa extender la funcionalidad creando código nuevo (una nueva clase que implemente la interfaz) sin alterar ni romper el código existente del notificador.
// ----------------------