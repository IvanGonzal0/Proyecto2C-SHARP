# Proyecto C# 2 - Gestor de Tareas para Elon Musk

Proyecto 2 Tema 3

Este proyecto es una aplicación de gestión de tareas desarrollada en C# utilizando Windows Forms.

## Resumen

La aplicación permite a los usuarios crear y eliminar tareas. La lógica de la aplicación se basa en la interacción entre los formularios (interfaz gráfica de usuario) y las clases (lógica de la aplicación).

Para una explicación más detallada de la lógica de la aplicación, las decisiones de diseño tomadas, y cómo interactúa el código con la interfaz gráfica de usuario, continúe leyendo este archivo README.

# Proyecto FERNANDES_ROCCIA_TAPIA

Este proyecto es una aplicación de Windows Forms desarrollada en C#. Se trata de una aplicación de gestión de vehiculos que permite a los usuarios crear, editar y eliminar vehiculos.

## Funcionamiento del Program.cs

El archivo `Program.cs` es el punto de entrada principal de la aplicación. Aquí es donde comienza y termina la ejecución del programa.

El método `Main()` es el primer método que se ejecuta cuando se inicia la aplicación. Dentro de este método, se realizan tres operaciones principales:

1. `Application.EnableVisualStyles()`: Este método habilita los estilos visuales para la aplicación. Los estilos visuales son las características de diseño que definen la apariencia y la sensación de los controles y elementos de la interfaz de usuario.

2. `Application.SetCompatibleTextRenderingDefault(false)`: Este método se utiliza para controlar cómo se renderiza el texto en los controles y garantizar la compatibilidad con versiones anteriores de .NET.

3. `Application.Run(new Form1())`: Este método inicia un bucle de mensajes estándar de la aplicación en el hilo actual y muestra el formulario especificado. En este caso, se muestra `Form1`, que es el formulario principal de la aplicación.

Por lo tanto, `Program.cs` es responsable de iniciar la aplicación, configurar los estilos visuales y el renderizado de texto, y mostrar el formulario principal.

## Estructura General del Proyecto

El proyecto está organizado en varias carpetas para mantener el código y los recursos bien estructurados y fácilmente accesibles. Aquí está una descripción general de la estructura del proyecto:

1. **Entidades**: Esta carpeta contiene todas las clases que definen los objetos que se utilizan en la aplicación. Estas clases representan las "entidades" en la lógica de la aplicación y definen sus propiedades y comportamientos.

2. **Forms**: Esta carpeta contiene todos los formularios de la aplicación. Cada formulario consta de dos partes principales:

   - **Diseño gráfico**: Esta es la interfaz de usuario que ven los usuarios. Define la apariencia de la aplicación, incluyendo la disposición de los controles, los colores, las fuentes, etc.

   - **Código**: Este es el código que controla el comportamiento de la aplicación. Incluye el código para interactuar con el resto del programa (como las clases en la carpeta Entidades) y el código que controla el diseño gráfico.

3. **Recursos**: Esta carpeta contiene todos los recursos gráficos que se utilizan en la aplicación, como iconos e imágenes. Estos recursos se utilizan para mejorar la apariencia de la aplicación y hacerla más intuitiva para los usuarios.

La estructura del proyecto está diseñada para separar claramente la lógica de la aplicación (en la carpeta Entidades), la interfaz de usuario (en la carpeta Forms) y los recursos gráficos (en la carpeta Recursos). Esta organización facilita la navegación por el código y la modificación de diferentes partes de la aplicación.

# 1. **Entidades**

Carpeto de clases principales

### Clase Vehiculo (Vehiculo.cs)

La clase `Vehiculo.cs` es una clase abstracta que sirve como base para los diferentes tipos de vehículos que se pueden implementar en el programa. Esta clase contiene varias propiedades que son comunes a todos los vehículos, como:

- `CantCargas`: Cantidad de cargas que ha tenido el vehículo.
- `CantServices`: Cantidad de servicios que ha tenido el vehículo.
- `IntervaloService`: Intervalo de servicio del vehículo.
- `Modelo`: Modelo del vehículo.
- `Anio`: Año del vehículo.
- `Autonomia`: Autonomía del vehículo.
- `Color`: Color del vehículo.
- `Duenio`: Dueño del vehículo.
- `Marca`: Marca del vehículo.

Además, la clase `Vehiculo.cs` también define dos métodos abstractos: `ToString()` y `Escaneo()`. Estos métodos deben ser implementados en todas las clases que heredan de `Vehiculo.cs`.

El propósito de esta clase es proporcionar una estructura común para todos los vehículos y evitar la redundancia de código. Al hacer que ciertas propiedades y métodos sean comunes a todos los vehículos, se facilita la implementación de nuevos tipos de vehículos en el futuro.

La encapsulación es un principio clave de la programación orientada a objetos que se utiliza en esta clase. Todos los atributos de la clase `Vehiculo` son privados, lo que significa que sólo pueden ser accedidos a través de sus métodos. Esto ayuda a mantener la integridad de los datos y a controlar cómo se accede a los datos y cómo se pueden modificar.

La clase `Vehiculo.cs` es una pieza fundamental de la arquitectura del programa que permite una fácil expansión y mantenimiento del código.

### Clase Tesla (Tesla.cs)

La clase `Tesla` hereda de la clase abstracta `Vehiculo`. Esta clase representa un vehículo Tesla en la aplicación.

#### Propiedades

La clase `Tesla` tiene las siguientes propiedades:

- `Id`: Un identificador único para cada instancia de `Tesla`.
- `KmActual`: El kilometraje actual del vehículo.
- `ProximoService`: El kilometraje en el que se debe realizar el próximo servicio.
- `Asientos`: La cantidad de asientos en el vehículo.
- `controlCinturones`: Una constante que representa el intervalo de control de los cinturones de seguridad.
- `controlBaterias`: Una constante que representa el intervalo de control de las baterías.
- `controlSistemaNavegacion`: Una constante que representa el intervalo de control del sistema de navegación.
- `controlSistemaTraccion`: Una constante que representa el intervalo de control del sistema de tracción.
- `controlMotor`: Una constante que representa el intervalo de control del motor.

- `cantCinturones`: La cantidad de controles de cinturones de seguridad que se han realizado.
- `cantBaterias`: La cantidad de controles de baterías que se han realizado.
- `cantSistemaNavegacion`: La cantidad de controles del sistema de navegación que se han realizado.
- `cantSistemaTraccion`: La cantidad de controles del sistema de tracción que se han realizado.
- `cantMotor`: La cantidad de controles del motor que se han realizado.

Además, tiene varias constantes que representan los intervalos de servicio para diferentes partes del vehículo, como los cinturones de seguridad, las baterías, el sistema de navegación, el sistema de tracción y el motor.

#### Constructor

El constructor de la clase `Tesla` toma varios parámetros, incluyendo el modelo, el año, el kilometraje actual, el color, el dueño, la autonomía, los asientos y el servicio. Estos valores se utilizan para inicializar las propiedades de la instancia de `Tesla`.

#### Métodos

La clase `Tesla` tiene dos métodos principales:

- `ToString()`: Este método devuelve una representación en cadena de la instancia de `Tesla`.
- `Escaneo()`: Este método realiza un "escaneo" del vehículo, calculando cuántos servicios se han realizado en diferentes partes del vehículo en función de su kilometraje actual.

La clase `Tesla` es una implementación específica de la clase abstracta `Vehiculo` que añade algunas propiedades y comportamientos específicos de los vehículos Tesla.

### Clase SpaceX (SpaceX.cs)

La clase `SpaceX` hereda de la clase abstracta `Vehiculo`. Esta clase se utiliza para instanciar objetos que representan a los vehículos de la marca SpaceX. Los modelos disponibles para la creación de estos objetos son "Falcon 9" y "Starship". Al seleccionar el modelo en la interfaz de usuario, se asignan automáticamente ciertas propiedades, como la autonomía y el intervalo de servicio, que son específicas para cada modelo.

#### Propiedades

La clase `SpaceX` tiene las siguientes propiedades:

- `contadorId`: Un contador estático que se incrementa cada vez que se crea una nueva instancia de `SpaceX`. Se utiliza para asignar un ID único a cada objeto `SpaceX`.
- `id`: El ID único de la instancia de `SpaceX`.
- `HsVueloActual`: Las horas de vuelo actuales del vehículo.
- `horasService`: Las horas de servicio del vehículo.
- `sistemaPropulsion`: Una constante que representa el intervalo de control del sistema de propulsión.
- `sistemaNavegacion`: Una constante que representa el intervalo de control del sistema de navegación.
- `cantPropulsion`: La cantidad de controles del sistema de propulsión que se han realizado.
- `cantNavegacion`: La cantidad de controles del sistema de navegación que se han realizado.

#### Constructor

El constructor de la clase `SpaceX` toma varios parámetros, incluyendo el modelo, el año, las horas de vuelo actuales, el color, el dueño, la autonomía y el servicio. Estos parámetros se utilizan para inicializar las propiedades correspondientes de la instancia de `SpaceX`.

#### Métodos

La clase `SpaceX` también tiene un método `Escaneo()`, que devuelve un informe detallado sobre el estado del vehículo, incluyendo la cantidad de servicios realizados y los controles del sistema de propulsión y de navegación.

# 2. **Forms**

Carpeta de los formularios

## Form1.cs

Este archivo es el código principal de la aplicación y define la interfaz de usuario y la lógica del programa.

### Descripción general

El programa consta de dos vistas principales, una para la empresa Tesla y otra para la empresa SpaceX. Se implementan todas las funcionalidades requeridas en el proyecto, así como funciones adicionales para que la interfaz sea amigable con el usuario.

Se crearon botones para minimizar, maximizar y cerrar el programa al estilo de Windows, pero con una interfaz moderna que consta de un formulario principal y subformularios hijos que se mostrarán en un panel secundario llamado "panelContenedor". Este modelo se eligió por su facilidad para escalar.

El programa inicialmente tiene dos listas, una para cada empresa. Estas listas simulan los datos que estarían guardados en una base de datos y se envían como argumentos del constructor de cada formulario hijo. Cada formulario hijo trabajará y manipulará estas listas, agregando o eliminando elementos según sea necesario.

### Detalles del código

El código comienza con la definición de la clase `Form1`, que hereda de la clase `Form` de la biblioteca `System.Windows.Forms`.

#### Inicio del formulario principal

Se definen dos listas, `listaTesla` y `listaSpaceX`, que almacenan objetos de las clases `Tesla` y `SpaceX`, respectivamente. Estos objetos representan diferentes modelos de vehículos o naves espaciales.

En el constructor de `Form1`, se inicializan estas listas y se establece el tamaño del formulario.

#### Control de botones

Se definen varios métodos para controlar el comportamiento de los botones de la interfaz de usuario. Estos incluyen botones para cerrar, maximizar, restaurar y minimizar el formulario.

Además, se importan algunas funciones de la biblioteca `user32.DLL` para permitir el diseño responsivo y el desplazamiento de la ventana.

#### Control de botones principales y creación de formularios hijos

El método `AbrirFormHijo` se utiliza para abrir un formulario hijo dentro del `panelContenedor`. Si ya hay un control en el `panelContenedor`, se elimina antes de agregar el nuevo control.

Los métodos `btnTesla_Click` y `btnSpaceX_Click` se utilizan para crear y abrir formularios de las clases `FormTesla` y `FormSpaceX`, respectivamente. Estos formularios reciben una lista como parámetro y se muestran en el `panelContenedor`.

## FormTesla.cs

Este archivo define la lógica y la interfaz de usuario para gestionar los objetos Tesla en la aplicación.

### Descripción general

En este formulario, se pueden crear y eliminar objetos Tesla en la lista recibida del formulario principal. Esta lista es donde se almacenan los Teslas. El formulario contiene toda la funcionalidad y lógica necesaria para instanciar correctamente un nuevo objeto Tesla.

Se tiene en cuenta los datos ingresados/seleccionados por el usuario y, dependiendo de ellos, se realizan cálculos para implementar lo solicitado en el proyecto.

La vista de la lista actual de Teslas se muestra en un DataGridView y se pueden agregar o eliminar Teslas de esta lista.

### Detalles del código

El código comienza con la definición de la clase `FormTesla`, que hereda de la clase `Form` de la biblioteca `System.Windows.Forms`.

#### Cargar dar de alta un Tesla

Se definen varias listas estáticas que contienen los modelos, años y colores disponibles para los coches Tesla. Estas listas se utilizan para poblar los ComboBoxes en el formulario.

En el constructor de `FormTesla`, se inicializan estas listas y se establece el DataSource del DataGridView si la lista de Tesla tiene elementos.

#### Botón crear Tesla y función guardarTesla

El botón "Crear Tesla" se encarga de hacer todas las validaciones de los campos. Si todos los campos son válidos, se llama al método `guardarTesla()`, que permite la instanciación de la clase Tesla y agrega el objeto a la lista principal de Teslas.

La función `guardarTesla()` tiene una condición para evaluar qué modelo de Tesla se eligió para asignar la autonomía, asientos, servicio y así no se crean modelos con datos erróneos. También obtiene los datos de los TextBoxes y los ComboBoxes.

#### Botón Eliminar y funcionalidad

Se define una función para obtener información y poder eliminar elementos de la lista mostrada en el DataGridView. Para ello, se utiliza la función `CellClick` del DataGridView para obtener el índice del elemento que queremos eliminar, y se elimina por índice = id.

#### Botón Escanear

Este botón realiza el escaneo del Tesla que se selecciona del DataGridView, haciendo referencia al objeto que se encuentra guardado en la lista del programa principal. Para evitar errores de ejecución se valida que la lista no esté vacía, y en el DataGridView únicamente se permite la selección de filas. Si el DataGridView está vacío, se mostrará un error al costado derecho del botón.

#### Botón Mostrar Tesla con más kilometraje

Esta función comprueba que la lista no esté vacía, y si no lo está, muestra un MessageBox, que contiene los datos del Tesla con mayor kilometraje. Se obtiene el Tesla con mayor kilometraje buscando en la lista principal de Teslas y guardando este objeto en la variable Tesla. Este objeto se utiliza para mostrar todos los datos a través del método sobreescrito ToString() y en el título de la ventana se mostrará el Tesla y su ID correspondiente. Si la lista está vacía, se mostrará un error al costado derecho del botón "Mostrar el Tesla con más kilometraje".

## FormSpaceX.cs

Este archivo define la lógica y la interfaz de usuario para gestionar los objetos SpaceX en la aplicación.

### Descripción general

En este formulario, se pueden crear y eliminar objetos SpaceX en la lista recibida del formulario principal. Esta lista es donde se almacenan los cohetes. El formulario contiene toda la funcionalidad y lógica necesaria para instanciar correctamente un nuevo objeto SpaceX.

Se tiene en cuenta los datos ingresados/seleccionados por el usuario y, dependiendo de ellos, se realizan cálculos para implementar lo solicitado en el proyecto.

La vista de la lista actual de SpaceX se muestra en un DataGridView y se pueden agregar o eliminar elementos de esta lista.

### Detalles del código

El código comienza con la definición de la clase `FormSpaceX`, que hereda de la clase `Form` de la biblioteca `System.Windows.Forms`.

#### Cargar un SpaceX

Se definen varias listas estáticas que contienen los modelos, años y colores disponibles para los cohetes SpaceX. Estas listas se utilizan para poblar los ComboBoxes en el formulario.

En el constructor de `FormSpaceX`, se inicializan estas listas y se establece el DataSource del DataGridView si la lista de SpaceX tiene elementos.

#### Botón crear SpaceX y función guardarSpaceX

El botón "Crear SpaceX" se encarga de hacer todas las validaciones de los campos. Si todos los campos son válidos, se llama al método `guardarSpaceX()`, que permite la instanciación de la clase SpaceX y agrega el objeto a la lista principal de SpaceX's.

La función `guardarSpaceX()` tiene una condición para evaluar qué modelo de SpaceX se eligió para asignar las horas de autonomía y servicio, y así no se crean modelos con datos erróneos. También obtiene los datos de los TextBoxes y los ComboBoxes.

#### Botón eliminar y funcionalidad

Se define una función para obtener información y poder eliminar elementos de la lista mostrada en el DataGridView. Para ello, se utiliza la función `CellClick` del DataGridView para obtener el índice del elemento que queremos eliminar, y se elimina por índice = id.

#### Botón Escanear

Este botón realiza el escaneo del SpaceX que se selecciona del DataGridView, haciendo referencia al objeto que se encuentra guardado en la lista del programa principal. Para evitar errores de ejecución se valida que la lista no esté vacía, y en el DataGridView únicamente se permite la selección de filas. Si el DataGridView está vacío, se mostrará un error al costado derecho del botón.

## Lógica de la aplicación

La lógica de la aplicación se basa en la gestión de dos tipos de objetos: Tesla y SpaceX. Estos objetos se crean, se almacenan en una lista y se pueden eliminar. Cada objeto tiene propiedades específicas que se asignan en función de la entrada del usuario y de las reglas predefinidas en el código. Por ejemplo, cada modelo de Tesla tiene una autonomía, asientos y servicio específicos que se asignan automáticamente cuando se elige el modelo.

La aplicación también proporciona funcionalidades para visualizar los objetos en una lista, eliminar objetos específicos y realizar operaciones como el escaneo de un objeto o la búsqueda del Tesla con más kilómetros.

La decisión de utilizar listas para almacenar los objetos permite una gestión eficiente de los datos y facilita la implementación de las funcionalidades mencionadas.

## Interacción entre el código y la interfaz gráfica de usuario

La interfaz gráfica de usuario (GUI) juega un papel crucial en la interacción con el usuario. Los formularios proporcionan una manera intuitiva de crear nuevos objetos Tesla o SpaceX, con campos de entrada y botones que desencadenan las acciones correspondientes en el código.

Los ComboBoxes se utilizan para seleccionar entre opciones predefinidas (como el modelo, el año y el color), garantizando así que los datos de entrada sean válidos. Los DataGridViews proporcionan una vista tabular de los objetos en la lista, permitiendo al usuario una fácil visualización y selección de objetos para acciones como el escaneo o la eliminación.

La GUI y el código están estrechamente vinculados, con acciones en la GUI que desencadenan funciones en el código, y cambios en los datos del código que se reflejan en la GUI.

## Conclusión

Esta aplicación es un ejemplo de cómo se puede gestionar eficazmente una colección de objetos en una aplicación de Windows Forms. La lógica de la aplicación está bien estructurada y las decisiones de diseño tomadas facilitan la implementación de las funcionalidades requeridas.

La interacción entre el código y la GUI es fluida y permite una experiencia de usuario intuitiva. Aunque la aplicación es relativamente simple, demuestra conceptos importantes como la gestión de datos, la validación de entrada y la interacción entre la lógica de la aplicación y la interfaz de usuario.

## Autores

Este proyecto ha sido desarrollado por los siguientes colaboradores:

- **Juan Manuel Roccia**
- **Ivan Gonzalo Tapia**
- **Andres Fernandes**
