/*
 * TPVV
 *
 * TPVV Ingeniería Web
 *
 * OpenAPI spec version: 1.0.0
 * Contact: lac56@alu.ua.es
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using IO.Swagger.Attributes;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class SeguridadApiController : ControllerBase
    {
        private MySqlConnection conn;
        string stringConexion = "server=localhost;port=3306;user id=luis;password=root;database=iw;SslMode=none";
        /// <summary>
        /// Se obtiene el token único del usuario
        /// </summary>
        /// <remarks>Para realizar la aplicación tendremos dos tipos de autorización, una apiKey que nos dará la autorización para hacer las peticiones de la API y un AuthToken único para cada uno de los usuarios de nuestro TPVV.</remarks>
        /// <response code="201">Nos devolverá el Token de ese usuario.</response>
        /// <response code="400">Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.</response>
        /// <response code="403">El cliente no posee los permisos necesarios para cierto contenido, por lo que el servidor está rechazando otorgar una respuesta apropiada.</response>
        [HttpGet]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/token")]
        [ValidateModelState]
        [SwaggerOperation("GetToken")]
        [SwaggerResponse(statusCode: 201, type: typeof(InlineResponse201), description: "Nos devolverá el Token de ese usuario.")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.")]
        [SwaggerResponse(statusCode: 403, type: typeof(InlineResponse403), description: "El cliente no posee los permisos necesarios para cierto contenido, por lo que el servidor está rechazando otorgar una respuesta apropiada.")]
        public virtual IActionResult GetToken([FromQuery] decimal? idUsuario)
        {
            conn = new MySqlConnection(stringConexion);
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = conn;
            try
            {
                cmd2.CommandText = "SELECT token FROM iw.almacentokens where id = " + idUsuario.ToString() + "";
                cmd2.ExecuteNonQuery();

                Usuario usuarioItem = new Usuario();
                MySqlDataReader reader = cmd2.ExecuteReader();
                string tokenUsuario = "";

                while (reader.Read())
                {
                    tokenUsuario = reader.GetString(0);

                    conn.Close();
                    return StatusCode(201, tokenUsuario);
                }

                InlineResponse403 resp3 = new InlineResponse403();
                resp3.TypeError = "ERROR_CREDENTIALS";
                resp3.MessageError = "Ha habido algún error en las credenciales introducidas";
                conn.Close();
                return StatusCode(404, resp3);
            }
            catch (MySqlException e)
            {
                InlineResponse404 resp3 = new InlineResponse404();
                resp3.ErrorMessage = "ERROR_PARAMETERS";
                conn.Close();
                return StatusCode(404, resp3);
            }  
        }

        /// <summary>
        /// Si el login se completa de forma correcta, se le devolverá al usuario su token.
        /// </summary>
        /// <remarks>Para el inicio de sesión solo necesitaremos nuestro usuario y contraseña. Pero para la realización del resto de trasacciones lo que necesitaremos será un token que va asociado a cada cuenta de usuario y que será único.</remarks>
        /// <param name="body">Credenciales para el inicio de sesión</param>
        /// <response code="201">Nos devolverá el Token de ese usuario.</response>
        /// <response code="400">Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.</response>
        /// <response code="403">El cliente no posee los permisos necesarios para cierto contenido, por lo que el servidor está rechazando otorgar una respuesta apropiada.</response>
        [HttpPost]
        [Route("/lac56-alu/TPVV/1.0.0/tpvv/login")]
        [ValidateModelState]
        [SwaggerOperation("Login")]
        [SwaggerResponse(statusCode: 201, type: typeof(InlineResponse201), description: "Nos devolverá el Token de ese usuario.")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.")]
        [SwaggerResponse(statusCode: 403, type: typeof(InlineResponse403), description: "El cliente no posee los permisos necesarios para cierto contenido, por lo que el servidor está rechazando otorgar una respuesta apropiada.")]
        public virtual IActionResult Login([FromBody] Usuario body)
        {
            string stringConexion = "server=localhost;port=3306;user id=luis;password=root;database=iw;SslMode=none";
            conn = new MySqlConnection(stringConexion);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            InlineResponse201 resp = new InlineResponse201();
            cmd.CommandText = "SELECT * FROM iw.usuarios where email = '" + body.Email + "' and password='" + body.Password + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == false)
            {
                InlineResponse403 resp3 = new InlineResponse403();
                resp3.MessageError = "Credenciales invalidas";
                conn.Close();
                return StatusCode(403, resp3);
            }
            else
            {
                conn.Close();
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT * FROM iw.almacentokens where fk_usuario_token = '" + body.Email + "'";
                MySqlDataReader reader1 = cmd2.ExecuteReader();
                if (reader1.Read() == false)
                {
                    InlineResponse400 resp2 = new InlineResponse400();
                    resp2.MessageError = "ERROR el usuario no tiene token. Por favor contacte con administrador";
                    conn.Close();
                    return StatusCode(400, resp2);
                }
                else
                {
                    resp.Token = reader1.GetString(1);
                    conn.Close();
                }
            }
            return StatusCode(201, resp);
        }
    }
}
