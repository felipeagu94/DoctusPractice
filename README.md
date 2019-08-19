# DoctusPractice
Manual para ejecución del proyecto de práctica.

La ejecución se realizará en modo debug, se adjuntará todo el proyecto para realizar esta prueba.
En la raíz del proyecto hay dos carpetas.
-	Back: Esta el código C# para backend.
-	Front: Esta el código React para el front.
-	DoctusPractice.bak es el archivo de backup de la base de datos o descargala de  https://www.dropbox.com/s/ap5lfh2co14hzj5/DoctusPractice.bak?dl=0 
-	La base de datos está en SQLSERVER 2017.

Configuración API

Dentro de la carpeta Back se encuentra el directorio “Infraestructura”, allí está la solución que debemos ejecutar.
1.	En el proyecto “ServicioAPI” en el archivo “appsettings.json” se debe configurar la cadena conexión donde se encuentra la base de datos.
En la sección “ConnectionString” se encuentra el elemento “Conexión”, allí se debe colocar la cadena conexion 
2.	Una vez configurada correctamente la cadena conexión ya se puede ejecutar el servicio.
Nota: Se debe ejecutar el proyecto “ServicioAPI” ya sea como debugger o modo view (Ctrl+Shift+w)
3.	Es importante tener en cuenta la url del localhost donde se expone el API para configurarlo en el proyecto del Front. El API tiene un método que responde si está funcionando. URL “urllocalhost/api/values”

Configuración Web

Dentro de la carpeta Front se encuentra el directorio “registrotiempos”, allí está el proyecto React que se debe exponer.
1.	En la raíz se encuentra el directorio “src”, debemos abrirlo.
2.	Dentro de este directorio está el archivo “config.js”, allí se debe configurar la url donde está el API expuesto.
Solo se debe configurar la url base, es decir hasta la palabra “api”
ejemplo: https://localhost:44340/api 
3.	Una vez configurado correctamente la url del API, debemos ejecutar el proyecto con Nodejs command o el mismo cmd.
4.	Una vez abierto uno de los dos programas, debemos ubicarnos en la raíz del proyecto, es decir en “registrotiempos”. Usaremos el comando cd. “ubicación/Front/registrotiempos”
5.	Después de ubicarnos en la raíz, ejecutamos el comando “npm install” y luego “npm start”
Nota: El equipo donde se ejecute, debe tener Nodejs instalado.
Página Nodejs: https://nodejs.org/es/
6.	Se abrirá en el explorador el sitio. En caso de no hacerlo, debemos ir a “http://localhost:3000/” que es la url por defecto de React.
