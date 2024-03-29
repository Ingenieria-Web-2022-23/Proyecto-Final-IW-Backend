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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Mensaje : IEquatable<Mensaje>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Usuario que envió el mensaje
        /// </summary>
        /// <value>Usuario que envió el mensaje</value>
        [Required]

        [DataMember(Name="emailUsuario")]
        public string emailUsuario { get; set; }

        /// <summary>
        /// Fecha creación
        /// </summary>
        /// <value>Fecha creación</value>

        [DataMember(Name="fecha")]
        public string Fecha { get; set; }

        /// <summary>
        /// Contenido del mensaje
        /// </summary>
        /// <value>Contenido del mensaje</value>
        [Required]

        [DataMember(Name="contenido")]
        public string Contenido { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Mensaje {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IdUsuario: ").Append(emailUsuario).Append("\n");
            sb.Append("  Fecha: ").Append(Fecha).Append("\n");
            sb.Append("  Contenido: ").Append(Contenido).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Mensaje)obj);
        }

        /// <summary>
        /// Returns true if Mensaje instances are equal
        /// </summary>
        /// <param name="other">Instance of Mensaje to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Mensaje other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    emailUsuario == other.emailUsuario ||
                    emailUsuario != null &&
                    emailUsuario.Equals(other.emailUsuario)
                ) && 
                (
                    Fecha == other.Fecha ||
                    Fecha != null &&
                    Fecha.Equals(other.Fecha)
                ) && 
                (
                    Contenido == other.Contenido ||
                    Contenido != null &&
                    Contenido.Equals(other.Contenido)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (emailUsuario != null)
                    hashCode = hashCode * 59 + emailUsuario.GetHashCode();
                    if (Fecha != null)
                    hashCode = hashCode * 59 + Fecha.GetHashCode();
                    if (Contenido != null)
                    hashCode = hashCode * 59 + Contenido.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Mensaje left, Mensaje right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Mensaje left, Mensaje right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
