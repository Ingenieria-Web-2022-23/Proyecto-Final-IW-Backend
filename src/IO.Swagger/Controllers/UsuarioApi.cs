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
            string stringConexion = "server=localhost;port=3306;user id=luis;password=root;database=iw;SslMode=none";
            conn = new MySqlConnection(stringConexion);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            InlineResponse200 resp = new InlineResponse200();

            if (comprobarToken(token))
            {
                try
                {
                    conn = new MySqlConnection(stringConexion);
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT * FROM iw.usuarios where id = " + idUsuario.ToString();
                    cmd2.ExecuteNonQuery();
                    cmd2.Dispose();
                    MySqlDataReader readerUsuario = cmd2.ExecuteReader();
                    bool comprobarUsuario = false;

                    while (readerUsuario.Read())
                    {

                        if (idUsuario == Convert.ToInt32(readerUsuario.GetString(0)))
                        {
                            comprobarUsuario = true;
                            break;
                        }
                    }

                    if (comprobarUsuario)
                    {
                        try
                        {
                            conn = new MySqlConnection(stringConexion);
                            conn.Open();
                            MySqlCommand cmd3 = new MySqlCommand();
                            cmd3.Connection = conn;
                            cmd3.CommandText = "DELETE FROM iw.usuarios where id = " + idUsuario.ToString();
                            cmd3.ExecuteNonQuery();
                            cmd3.Dispose();

                            conn.Close();
                            return StatusCode(200);
                            
                        }
                        catch (MySqlException e)
                        {
                            InlineResponse404 resp2 = new InlineResponse404();
                            resp2.ErrorMessage = "ERROR_RECURSO_NO_ENCONTRADO";
                            conn.Close();
                            return StatusCode(404, resp2);
                        }
                    }
                    else
                    {
                        InlineResponse404 resp2 = new InlineResponse404();
                        resp2.ErrorMessage = "ERROR_RECURSO_NO_ENCONTRADO";
                        conn.Close();
                        return StatusCode(404, resp2);
                    }
                }
                catch (MySqlException e)
                {
                    InlineResponse404 resp2 = new InlineResponse404();
                    resp2.ErrorMessage = "ERROR_RECURSO_NO_ENCONTRADO";
                    conn.Close();
                    return StatusCode(404, resp2);
                }
            }
            else
            {
                InlineResponse401 resp2 = new InlineResponse401();
                resp2.ErrorMessage = "ERROR_TOKEN";
                conn.Close();
                return StatusCode(401, resp2);

            }
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
                    conn.Close();

                    conn = new MySqlConnection(stringConexion);
                    conn.Open();
                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandText = "INSERT INTO iw.almacentokens (token, fk_usuario_token) VALUES ('" + tokenGenerado + "', '" + body.Email.ToString() + "')";
                    cmd3.ExecuteNonQuery();

                    resp.Token = tokenGenerado;
                    conn.Close();

                }
                catch (MySqlException e)
                {
                    InlineResponse400 resp2 = new InlineResponse400();
                    resp2.TypeError = "ERROR_PARAMETERS";
                    resp2.MessageError = "Los parámetros introducidos son erroneos.";
                    conn.Close();
                    Console.WriteLine(e.ToString());
                    return StatusCode(400, resp2);
                }
            }
            else
            {
                InlineResponse400 resp2 = new InlineResponse400();
                resp2.TypeError = "ERROR_PARAMETERS";
                resp2.MessageError = "Los parámetros introducidos son erroneos.";
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
        public virtual IActionResult GetDetallesUsuario([FromQuery][Required()] string token, [FromQuery][Required()] decimal? idUsuario)
        {
            string stringConexion = "server=localhost;port=3306;user id=luis;password=root;database=iw;SslMode=none";
            conn = new MySqlConnection(stringConexion);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            InlineResponse200 resp = new InlineResponse200();

            if (comprobarToken(token))
            {
                conn = new MySqlConnection(stringConexion);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT * FROM iw.usuarios where id = " + idUsuario.ToString() + "";
                cmd2.ExecuteNonQuery();

                Usuario usuarioItem = new Usuario();
                MySqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    usuarioItem.Id = Convert.ToInt32(reader.GetString(0));
                    usuarioItem.Nombre = reader.GetString(1);
                    usuarioItem.Email = reader.GetString(2);
                    usuarioItem.Password = reader.GetString(3);
                    usuarioItem.Token = reader.GetString(4);
                    usuarioItem.NombreEmpresa = reader.GetString(5);
                    usuarioItem.TipoUsuario = reader.GetString(6);

                    conn.Close();
                    return StatusCode(200, usuarioItem);
                }

                InlineResponse404 resp3 = new InlineResponse404();
                resp3.ErrorMessage = "ERROR_RECURSO_NO_ENCONTRADO";
                conn.Close();
                return StatusCode(404, resp3);
            }
            else
            {
                InlineResponse401 resp2 = new InlineResponse401();
                resp2.ErrorMessage = "ERROR_TOKEN";
                conn.Close();
                return StatusCode(401, resp2);
            }

            return StatusCode(200, resp);
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
            string stringConexion = "server=localhost;port=3306;user id=luis;password=root;database=iw;SslMode=none";
            conn = new MySqlConnection(stringConexion);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            InlineResponse200 resp = new InlineResponse200();

            if (comprobarToken(token))
            {
                conn = new MySqlConnection(stringConexion);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT * FROM iw.usuarios";
                cmd2.ExecuteNonQuery();

                Usuario usuarioItem = new Usuario();
                MySqlDataReader reader = cmd2.ExecuteReader();
                List<Usuario> listaUsuarios = new List<Usuario>();

                while (reader.Read())
                {
                    usuarioItem = new Usuario();
                    usuarioItem.Id = Convert.ToInt32(reader.GetString(0));
                    usuarioItem.Nombre = reader.GetString(1);
                    usuarioItem.Email = reader.GetString(2);
                    usuarioItem.Password = reader.GetString(3);
                    usuarioItem.Token = reader.GetString(4);
                    usuarioItem.NombreEmpresa = reader.GetString(5);
                    usuarioItem.TipoUsuario = reader.GetString(6);

                    listaUsuarios.Add(usuarioItem);
                }

                if (listaUsuarios.Count > 0)
                {
                    conn.Close();
                    return StatusCode(200, listaUsuarios);
                }

                InlineResponse404 resp3 = new InlineResponse404();
                resp3.ErrorMessage = "ERROR_RECURSO_NO_ENCONTRADO";
                conn.Close();
                return StatusCode(404, resp3);
            }
            else
            {
                InlineResponse401 resp2 = new InlineResponse401();
                resp2.ErrorMessage = "ERROR_TOKEN";
                conn.Close();
                return StatusCode(401, resp2);
            }
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
            string stringConexion = "server=localhost;port=3306;user id=luis;password=root;database=iw;SslMode=none";
            conn = new MySqlConnection(stringConexion);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            InlineResponse200 resp = new InlineResponse200();

            if (comprobarToken(token))
            {
                try
                {
                    conn = new MySqlConnection(stringConexion);
                    conn.Open();
                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandText = "UPDATE iw.usuarios SET nombre='" + body.Nombre.ToString() + "', email='" + body.Email.ToString() + "', password='" + body.Password.ToString()
                       + "', nombreEmpresa='" + body.NombreEmpresa.ToString() + "' where id = " + idUsuario.ToString() + "";
                    cmd3.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT * FROM iw.usuarios where id = " + idUsuario.ToString() + "";
                    cmd2.ExecuteNonQuery();

                    Usuario usuarioItem = new Usuario();
                    MySqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarioItem.Id = Convert.ToInt32(reader.GetString(0));
                        usuarioItem.Nombre = reader.GetString(1);
                        usuarioItem.Email = reader.GetString(2);
                        usuarioItem.Password = reader.GetString(3);
                        usuarioItem.Token = reader.GetString(4);
                        usuarioItem.NombreEmpresa = reader.GetString(5);
                        usuarioItem.TipoUsuario = reader.GetString(6);

                        conn.Close();
                        return StatusCode(200, usuarioItem);
                    }
                    
                    InlineResponse404 resp3 = new InlineResponse404();
                    resp3.ErrorMessage = "ERROR_RECURSO_NO_ENCONTRADO";
                    conn.Close();
                    return StatusCode(404, resp3);
                }
                catch (MySqlException e)
                {
                    InlineResponse404 resp3 = new InlineResponse404();
                    resp3.ErrorMessage = "ERROR_RECURSO_NO_ENCONTRADO";
                    conn.Close();
                    return StatusCode(404, resp3);
                }
            }
            else
            {
                InlineResponse401 resp2 = new InlineResponse401();
                resp2.ErrorMessage = "ERROR_TOKEN";
                conn.Close();
                return StatusCode(401, resp2);
            }
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
                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Connection = conn;
                    string tokenGenerado = generarToken();
                    cmd3.CommandText = "UPDATE iw.usuarios SET token='" + tokenGenerado + "' where token = '" + token + "'";
                    cmd3.ExecuteNonQuery();
                    conn.Close();

                    conn = new MySqlConnection(stringConexion);
                    conn.Open();
                    MySqlCommand cmd4 = new MySqlCommand();
                    cmd4.Connection = conn;
                    cmd4.CommandText = "UPDATE iw.almacentokens SET token='" + tokenGenerado + "' where token = '" + token + "'";
                    cmd4.ExecuteNonQuery();
                    conn.Close();

                    resp.Token = tokenGenerado;
                    return StatusCode(201, resp);
                }
                catch (MySqlException e)
                {
                    InlineResponse401 resp3 = new InlineResponse401();
                    resp3.ErrorMessage = "ERROR_TOKEN";
                    conn.Close();
                    return StatusCode(401, resp3);
                }
            }
            else
            {
                InlineResponse401 resp2 = new InlineResponse401();
                resp2.ErrorMessage = "ERROR_TOKEN";
                conn.Close();
                return StatusCode(401, resp2);
            }
        }
    }
}
