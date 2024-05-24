using CLIENTS_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace CLIENTS_API.Controllers
{
    public class ClientController : ApiController
    {

        private readonly string _connectionString;

        public ClientController()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string dataDirectoryPath = System.IO.Path.Combine(basePath, "users_db");
                _connectionString = $"Data Source={dataDirectoryPath + "\\test.db"}";

                string databasePath = new SQLiteConnectionStringBuilder(_connectionString).DataSource;
                if (!System.IO.File.Exists(databasePath))
                {
                    throw new System.IO.FileNotFoundException("No se encontró el archivo que contiene la base de datos en la ruta: ", databasePath);
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error al obtener la cadena de conexion en: ", ex);
            }

        }

        //GET: api/clients
        [HttpGet]
        [Route("api/clients")]
        public IHttpActionResult GetClients()
        {
            try
            {
                using (IDbConnection db = new SQLiteConnection(_connectionString))
                {
                    List<Client> clientes = db.Query<Client>("SELECT * FROM CLIENTS").ToList();
                    return Ok(clientes);
                }
            }
            catch (Exception ex) { return InternalServerError(ex); }
        }

        //GET: api/clients/{id}
        [HttpGet]
        [Route("api/clients/{id}")]
        public IHttpActionResult GetClientById(int id)
        {
            try
            {
                using (IDbConnection db = new SQLiteConnection(_connectionString))
                {
                    Client cliente = db.QuerySingleOrDefault<Client>("SELECT * FROM CLIENTS WHERE id = @id_", new { id_ = id });
                    if (cliente == null) return NotFound();

                    return Ok(cliente);
                }
            }
            catch (Exception ex) { return InternalServerError(ex); }
        }

        // POST: api/clientes
        [HttpPost]
        public IHttpActionResult PostCliente([FromBody] Client cliente)
        {
            if (cliente == null)
                return BadRequest("Cliente no puede ser null.");

            try
            {
                using (IDbConnection db = new SQLiteConnection(_connectionString))
                {
                    var sqlQuery = "INSERT INTO CLIENTS (rut, nombre, mail) VALUES (@rut, @nombre, @mail)";
                    var result = db.Execute(sqlQuery, cliente);

                    if (result > 0)
                        return Ok();

                    return BadRequest("No se pudo insertar el cliente.");
                }
            }
            catch (Exception ex) { return InternalServerError(ex); }

        }

        //PUT: api/clientes/{id}
        [HttpPut]
        [Route("api/clients/{id}")]
        public IHttpActionResult PutCliente(int id, [FromBody] Client cliente)
        {
            if (cliente == null)
                return BadRequest("Cliente no puede ser null.");

            try
            {
                using (IDbConnection db = new SQLiteConnection(_connectionString))
                {
                    var sqlQuery = "UPDATE CLIENTS SET rut = @rut, nombre = @nombre, mail = @mail WHERE id = @id";
                    var result = db.Execute(sqlQuery, new { cliente.rut, cliente.nombre, cliente.mail, id = id });

                    if (result > 0)
                        return Ok();

                    return BadRequest("No se pudo actualizar el cliente.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
