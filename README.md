# Release Note - API Clientes  

*Christian Rojas, 23 de Mayo de 2024*

Este repositorio contiene los endpoints solicitados para el test. A continueación se detalla las especificaciones de las solicitudes a la api mediante postman:

#### GET para todos los clientes:
> Ruta: GET */api/clients*
> 
> Esta ruta sirve para traer todos los clientes dentro de la tabla en la base de datos

#### GET para un cliente especificado por *{id}*
> Ruta: GET */api/clients/{id}*
> 
> Esta ruta sirve para traer un cliente especifico dando como parametro en la ruta el id del mismo

#### POST para un nuevo cliente
> Ruta: POST */api/clients/*
> 
> Se le puede pasar en Postman tanto en formato *json* en raw como en from-data para pasar los parametros a modo de objeto  
>  *EJ*:
> > {  
> >   &emsp;"rut" : "12.345.678-9",  
> >   &emsp;"nombre" : "Pedro Perez Pereira",  
> >   &emsp;"mail" : "triple_p@gmail.com"  
> > }

#### PUT para actualizar un cliente ya existente
> Ruta: POST */api/clients/{id}*
> 
> Se le tiene que pasar a postman en formato *json* en la pestaña de raw además de especificar el id del cliente en la ruta 
>  *EJ*:
> */api/clients/2*
> > {  
> >   &emsp;"rut" : "98.765.432-1",  
> >   &emsp;"nombre" : "Pedro Perez Pereiras",  
> >   &emsp;"mail" : "triple_p@hotmail.com"  
> > }

# Instrucciones  
- Al descomprimir la carpeta *CLIENTS_API* ya traerá todo lo necesario para su ejecución abriendo el proyecto en Visual Studio
- La base de datos *test.db* se encuentra dentro de la carpeta anteriormente mencionada en una subcarpeta llamada *users_db*
- El archivo test.db debe mantenerse en esa ruta para que la aplicación funcione correctamente (se explica en la sección de detalles)
- Al ejecutar el proyecto se abrirá en el navegador con la ruta de localhost asignada y se podrá ver una pestaña con el menu de *API* en la parte superior izquierda, donde se podrá ver un resumen de los metodos de la misma.

### Detalles:
> Por un motivo que no alcancé a resolver no pude configurar el string de conexión de la base de datos en el archivo WebConfig, razón por la que no se puede mover el archivo de la base de datos de su posición original    
>  
> Por el mismo motivo de tiempo, no pude configurar el proyecto base para que no mostrara la ventana por defecto que trae la plantilla del proyecto, pero la api sigue funcionando correctamente con los metodos especificados en la primera sección.
