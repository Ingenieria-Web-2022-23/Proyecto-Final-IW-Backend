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
    public partial class Usuario : IEquatable<Usuario>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Nombre
        /// </summary>

        [DataMember(Name="nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>

        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>

        [DataMember(Name="password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets Token
        /// </summary>

        [DataMember(Name="token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or Sets NombreEmpresa
        /// </summary>

        [DataMember(Name="nombreEmpresa")]
        public string NombreEmpresa { get; set; }

        /// <summary>
        /// Gets or Sets TipoUsuario
        /// </summary>

        [DataMember(Name="tipoUsuario")]
        public string TipoUsuario { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Usuario {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  NombreEmpresa: ").Append(NombreEmpresa).Append("\n");
            sb.Append("  TipoUsuario: ").Append(TipoUsuario).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Usuario)obj);
        }

        /// <summary>
        /// Returns true if Usuario instances are equal
        /// </summary>
        /// <param name="other">Instance of Usuario to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Usuario other)
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
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Password == other.Password ||
                    Password != null &&
                    Password.Equals(other.Password)
                ) && 
                (
                    Token == other.Token ||
                    Token != null &&
                    Token.Equals(other.Token)
                ) && 
                (
                    NombreEmpresa == other.NombreEmpresa ||
                    NombreEmpresa != null &&
                    NombreEmpresa.Equals(other.NombreEmpresa)
                ) && 
                (
                    TipoUsuario == other.TipoUsuario ||
                    TipoUsuario != null &&
                    TipoUsuario.Equals(other.TipoUsuario)
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
                    if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Password != null)
                    hashCode = hashCode * 59 + Password.GetHashCode();
                    if (Token != null)
                    hashCode = hashCode * 59 + Token.GetHashCode();
                    if (NombreEmpresa != null)
                    hashCode = hashCode * 59 + NombreEmpresa.GetHashCode();
                    if (TipoUsuario != null)
                    hashCode = hashCode * 59 + TipoUsuario.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Usuario left, Usuario right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Usuario left, Usuario right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
