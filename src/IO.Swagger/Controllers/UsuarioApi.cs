/*
 * TPVV
 *
 * TPVV Ingeniería Web
 *
 * OpenAPI spec version: 1.0.0
 * Contact: lac56@alu.ua.es
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;
using MySql.Data.MySqlClient;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
        private MySqlConnection conn;
        private bool comprobarToken(string token)
        {
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "SELECT * FROM iw.almacentokens where token = '" + token + "'";
            cmd2.ExecuteNonQuery();
            MySqlDataReader readerKey = cmd2.ExecuteReader();
            bool comprobarKey = false;

            while (readerKey.Read())
            {
                if (token == readerKey.GetString(1))
                {
                    comprobarKey = true;
                    break;
                }
            }

            return comprobarKey;
        }

        private string generarToken()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[25];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            Console.WriteLine(resultString);

            return new String(Charsarr);
        }

        /// <summary>
        /// Podremos borrar un usuario en especifico
        /// </summary>
        /// <remarks>Podremos borrar un usuario de nuestro sistema para siempre</remarks>
        /// <param name="token"></param>
        /// <param name="idUsuario"></param>
        /// <response code="200">Usuario borrado con exito</response>
        /// <response code="401">Sin autorización para realizar esta operación</response>
        /// <response code="404">No se encontró el recurso que se pidió</response>
        [HttpDelete]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/borrarUsuario")]
        [ValidateModelState]
        [SwaggerOperation("BorrarUsuario")]
        [SwaggerResponse(statusCode: 401, type: typeof(InlineResponse401), description: "Sin autorización para realizar esta operación")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse404), description: "No se encontró el recurso que se pidió")]
        public virtual IActionResult BorrarUsuario([FromQuery][Required()]string token, [FromQuery][Required()]decimal? idUsuario)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(InlineResponse401));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(InlineResponse404));

            throw new NotImplementedException();
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <remarks>Podremos crear nuevos usuarios para nuestro sistema, será la única forma de introducir un nuevo cliente dentro del mismo.</remarks>
        /// <param name="body"></param>
        /// <param name="token"></param>
        /// <response code="201">Usuario creado correctamente</response>
        /// <response code="400">Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.</response>
        [HttpPost]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/crearUsuario")]
        [ValidateModelState]
        [SwaggerOperation("CrearUsuario")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.")]
        public virtual IActionResult CrearUsuario([FromBody]Usuario body, [FromQuery][Required()]string token)
        {
            string stringConexion = "server=localhost;port=3306;user id=luis;password=root;database=iw;SslMode=none";
            conn = new MySqlConnection(stringConexion);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            InlineResponse201 resp = new InlineResponse201();

            if (comprobarToken(token))
            {
                try
                {
                    conn = new MySqlConnection(stringConexion);
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    string tokenGenerado = generarToken();
                    cmd2.CommandText = "INSERT INTO iw.usuarios (nombre, email, password, token, nombreEmpresa, tipoUsuario) VALUES ('" +
                        body.Nombre.ToString() + "', '" + body.Email.ToString() + "', '" + body.Password.ToString()
                        + "', '" + tokenGenerado + "', '" + body.NombreEmpresa.ToString() + "', 'user')";
                    cmd2.ExecuteNonQuery();

                    resp.Token = tokenGenerado;
                    conn.Close();
                }
                catch (MySqlException e)
                {
                    InlineResponse400 resp2 = new InlineResponse400();
                    resp2.TypeError = "Error: Fallo a la hora de insertar los valores en la DB";
                    conn.Close();
                    Console.WriteLine(e.ToString()); ;
                    return StatusCode(400, resp2);
                }
            }
            else
            {
                InlineResponse400 resp2 = new InlineResponse400();
                resp2.TypeError = "Error: TOKEN INCORRECTO";
                conn.Close();
                return StatusCode(400, resp2);
            }

            return StatusCode(201, resp);
        }

        /// <summary>
        /// Obtener los detalles de un usuario en especifico
        /// </summary>
        /// <remarks>Podremos consultar todos los detalles de un usuario, es decir visualizar cada uno de los campos que ha introducido este para registrarse en nuestro sistema.</remarks>
        /// <param name="token"></param>
        /// <param name="idUsuario"></param>
        /// <response code="200">Detalles del usuario</response>
        /// <response code="401">Sin autorización para realizar esta operación</response>
        /// <response code="404">No se encontró el recurso que se pidió</response>
        [HttpGet]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/detallesUsuario")]
        [ValidateModelState]
        [SwaggerOperation("GetDetallesUsuario")]
        [SwaggerResponse(statusCode: 200, type: typeof(Usuario), description: "Detalles del usuario")]
        [SwaggerResponse(statusCode: 401, type: typeof(InlineResponse401), description: "Sin autorización para realizar esta operación")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse404), description: "No se encontró el recurso que se pidió")]
        public virtual IActionResult GetDetallesUsuario([FromQuery][Required()]string token, [FromQuery][Required()]decimal? idUsuario)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Usuario));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(InlineResponse401));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(InlineResponse404));
            string exampleJson = null;
            exampleJson = "{\n  \"password\" : \"aijsfbhausfbas\",\n  \"tipoUsuario\" : \"normal\",\n  \"id\" : 1,\n  \"nombre\" : \"Luis Alfonso\",\n  \"email\" : \"luis@gmail.com\",\n  \"nombreEmpresa\" : \"A reason\",\n  \"token\" : \"i989nasiudfbas54asd5as4da5s1d\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Usuario>(exampleJson)
                        : default(Usuario);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Devuelve una lista con todos los usuarios
        /// </summary>
        /// <remarks>Devuelve una lista con todos los usuarios que tenemos registrados dentro de nuestro sistema</remarks>
        /// <param name="token"></param>
        /// <response code="200">Lista con todos los usuarios</response>
        /// <response code="400">Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.</response>
        /// <response code="401">Sin autorización para realizar esta operación</response>
        [HttpGet]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/listaUsuarios")]
        [ValidateModelState]
        [SwaggerOperation("GetListaUsuarios")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse2004), description: "Lista con todos los usuarios")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.")]
        [SwaggerResponse(statusCode: 401, type: typeof(InlineResponse401), description: "Sin autorización para realizar esta operación")]
        public virtual IActionResult GetListaUsuarios([FromQuery][Required()]string token)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse2004));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(InlineResponse400));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(InlineResponse401));
            string exampleJson = null;
            exampleJson = "{\n  \"data\" : [ {\n    \"password\" : \"aijsfbhausfbas\",\n    \"tipoUsuario\" : \"normal\",\n    \"id\" : 1,\n    \"nombre\" : \"Luis Alfonso\",\n    \"email\" : \"luis@gmail.com\",\n    \"nombreEmpresa\" : \"A reason\",\n    \"token\" : \"i989nasiudfbas54asd5as4da5s1d\"\n  }, {\n    \"password\" : \"aijsfbhausfbas\",\n    \"tipoUsuario\" : \"normal\",\n    \"id\" : 1,\n    \"nombre\" : \"Luis Alfonso\",\n    \"email\" : \"luis@gmail.com\",\n    \"nombreEmpresa\" : \"A reason\",\n    \"token\" : \"i989nasiudfbas54asd5as4da5s1d\"\n  } ]\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse2004>(exampleJson)
                        : default(InlineResponse2004);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Podremos modificar un usuario
        /// </summary>
        /// <remarks>Podremos modificar todos los campos de un usuario, es decir cambiar cada uno de los campos que ha introducido este para registrarse en nuestro sistema.</remarks>
        /// <param name="body"></param>
        /// <param name="token"></param>
        /// <param name="idUsuario"></param>
        /// <response code="200">Detalles del usuario</response>
        /// <response code="401">Sin autorización para realizar esta operación</response>
        /// <response code="404">No se encontró el recurso que se pidió</response>
        [HttpPut]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/modificarUsuario")]
        [ValidateModelState]
        [SwaggerOperation("ModificarUsuario")]
        [SwaggerResponse(statusCode: 200, type: typeof(Usuario), description: "Detalles del usuario")]
        [SwaggerResponse(statusCode: 401, type: typeof(InlineResponse401), description: "Sin autorización para realizar esta operación")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse404), description: "No se encontró el recurso que se pidió")]
        public virtual IActionResult ModificarUsuario([FromBody]UsuarioModificar body, [FromQuery][Required()]string token, [FromQuery][Required()]decimal? idUsuario)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Usuario));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(InlineResponse401));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(InlineResponse404));
            string exampleJson = null;
            exampleJson = "{\n  \"password\" : \"aijsfbhausfbas\",\n  \"tipoUsuario\" : \"normal\",\n  \"id\" : 1,\n  \"nombre\" : \"Luis Alfonso\",\n  \"email\" : \"luis@gmail.com\",\n  \"nombreEmpresa\" : \"A reason\",\n  \"token\" : \"i989nasiudfbas54asd5as4da5s1d\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Usuario>(exampleJson)
                        : default(Usuario);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Regenerar el token del usuario
        /// </summary>
        /// <remarks>Podremos volver a generar el token que va asociado al usuario, si por algún motivo este quiere realiar esta operación ya sea por seguridad o porque lo haya perdido.</remarks>
        /// <param name="token"></param>
        /// <response code="201">Nos devolverá el Token de ese usuario.</response>
        /// <response code="401">Sin autorización para realizar esta operación</response>
        [HttpPost]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/regenerarTokenUsuario")]
        [ValidateModelState]
        [SwaggerOperation("RegenerarToken")]
        [SwaggerResponse(statusCode: 201, type: typeof(InlineResponse201), description: "Nos devolverá el Token de ese usuario.")]
        [SwaggerResponse(statusCode: 401, type: typeof(InlineResponse401), description: "Sin autorización para realizar esta operación")]
        public virtual IActionResult RegenerarToken([FromQuery][Required()]string token)
        { 
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(InlineResponse201));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(InlineResponse401));
            string exampleJson = null;
            exampleJson = "{\n  \"Token\" : \"jbHBSFBUIAKONaiaoizfcja0f09kasndjan\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse201>(exampleJson)
                        : default(InlineResponse201);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
