// EjercicioE.cs
// SECCIÓN E - ¿QUÉ PATRÓN USARÍAS?

// -------------------------
// Ejercicio E1 - Escenario 1
// Patrón: Strategy
// ¿Por qué?: Ya que el costo del envío depende del medio de transporte (el síntoma clave es: "calcula el costo de forma distinta si va en..."), elegiría Strategy para encapsular cada cálculo. Esto evita usar varios if o switch y permite sumar el "envío con dron" mediante una clase nueva sin necesidad de modificar el código existente

// -------------------------
// Ejercicio E2 - Escenario 2
// Patrón: Observer
// ¿Por qué?: Elegiría este patrón porque hay un evento de cambio de estado (el síntoma es: "cuando un pedido pasa a listo, tienen que enterarse..."). Observer permite que un notificador avise a múltiples "suscriptores" (pantalla, tablet, caja), pudiendo agregar nuevos medios de aviso (como WhatsApp) a futuro sin alterar el código central

// -------------------------
// Ejercicio E3 - Escenario 3
// Patrón: Singleton
// ¿Por qué?: El síntoma del problema es que hoy "cada formulario crea su propio objeto" y los datos quedan desincronizados. Singleton garantiza que exista una única instancia de la configuración en memoria, logrando que cualquier cambio (como cambiar de sucursal) sea leído uniformemente por todas las pantallas del sistema

// -------------------------
// Ejercicio E4 - Escenario 4
// Patrón: Factory (Simple Factory o Factory Method)
// ¿Por qué?: Se justifica plenamente porque el síntoma indica que el tipo de pago llega "como texto" ("TARJETA", "EFECTIVO") desde un archivo, y en base a eso hay que "reconstruir el objeto" correcto. La Factory es ideal para aislar esa transformación dinámica de texto a instancias

// -------------------------
// Ejercicio E5 - Escenario 5
// Patrón: Ninguno (solo Inyección de Dependencias)
// ¿Por qué?: No implementaría ningún patrón de diseño creacional extra. Ya que el repositorio "se crea una sola vez al iniciar y nunca cambia durante la ejecución", agregar una Factory solo agregaría complejidad innecesaria (sobreingeniería); con inyectarlo por el constructor alcanza y sobra
// -------------------------