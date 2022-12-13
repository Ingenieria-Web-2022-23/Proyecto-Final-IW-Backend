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
    public partial class Pagos : IEquatable<Pagos>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Id de la devolución, si hubiera (en caso contrario -&gt; null)
        /// </summary>
        /// <value>Id de la devolución, si hubiera (en caso contrario -&gt; null)</value>

        [DataMember(Name="devolucionId")]
        public List<int?> DevolucionId { get; set; }

        /// <summary>
        /// Total de la compra
        /// </summary>
        /// <value>Total de la compra</value>
        [Required]

        [DataMember(Name="total")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Se podrá añadir opcionalmente a la hora de realizar el pago un concepto sobre la compra realizada
        /// </summary>
        /// <value>Se podrá añadir opcionalmente a la hora de realizar el pago un concepto sobre la compra realizada</value>

        [DataMember(Name="concepto")]
        public string Concepto { get; set; }

        /// <summary>
        /// Es la referencia que vincula el pago con el recibo creado por el usuario que realiza la compra
        /// </summary>
        /// <value>Es la referencia que vincula el pago con el recibo creado por el usuario que realiza la compra</value>
        [Required]

        [DataMember(Name="referencia")]
        public string Referencia { get; set; }

        /// <summary>
        /// Fecha del momento en el que se realiza la compra
        /// </summary>
        /// <value>Fecha del momento en el que se realiza la compra</value>

        [DataMember(Name="fecha")]
        public string Fecha { get; set; }

        /// <summary>
        /// Estado de como se encuentra el pago
        /// </summary>
        /// <value>Estado de como se encuentra el pago</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum EstadoEnum
        {
            /// <summary>
            /// Enum ENESPERAEnum for EN_ESPERA
            /// </summary>
            [EnumMember(Value = "EN_ESPERA")]
            ENESPERAEnum = 0,
            /// <summary>
            /// Enum ACEPTADOEnum for ACEPTADO
            /// </summary>
            [EnumMember(Value = "ACEPTADO")]
            ACEPTADOEnum = 1,
            /// <summary>
            /// Enum DENEGADODEVOLUCINEnum for DENEGADO, DEVOLUCIÓN
            /// </summary>
            [EnumMember(Value = "DENEGADO, DEVOLUCIÓN")]
            DENEGADODEVOLUCINEnum = 2        }

        /// <summary>
        /// Estado de como se encuentra el pago
        /// </summary>
        /// <value>Estado de como se encuentra el pago</value>

        [DataMember(Name="estado")]
        public EstadoEnum? Estado { get; set; }

        /// <summary>
        /// Motivo del error del pago
        /// </summary>
        /// <value>Motivo del error del pago</value>

        [DataMember(Name="detallesEstado")]
        public string DetallesEstado { get; set; }

        /// <summary>
        /// Gets or Sets Tarjeta
        /// </summary>
        [Required]

        [DataMember(Name="tarjeta")]
        public Tarjeta Tarjeta { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Pagos {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DevolucionId: ").Append(DevolucionId).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  Concepto: ").Append(Concepto).Append("\n");
            sb.Append("  Referencia: ").Append(Referencia).Append("\n");
            sb.Append("  Fecha: ").Append(Fecha).Append("\n");
            sb.Append("  Estado: ").Append(Estado).Append("\n");
            sb.Append("  DetallesEstado: ").Append(DetallesEstado).Append("\n");
            sb.Append("  Tarjeta: ").Append(Tarjeta).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Pagos)obj);
        }

        /// <summary>
        /// Returns true if Pagos instances are equal
        /// </summary>
        /// <param name="other">Instance of Pagos to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Pagos other)
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
                    DevolucionId == other.DevolucionId ||
                    DevolucionId != null &&
                    DevolucionId.SequenceEqual(other.DevolucionId)
                ) && 
                (
                    Total == other.Total ||
                    Total != null &&
                    Total.Equals(other.Total)
                ) && 
                (
                    Concepto == other.Concepto ||
                    Concepto != null &&
                    Concepto.Equals(other.Concepto)
                ) && 
                (
                    Referencia == other.Referencia ||
                    Referencia != null &&
                    Referencia.Equals(other.Referencia)
                ) && 
                (
                    Fecha == other.Fecha ||
                    Fecha != null &&
                    Fecha.Equals(other.Fecha)
                ) && 
                (
                    Estado == other.Estado ||
                    Estado != null &&
                    Estado.Equals(other.Estado)
                ) && 
                (
                    DetallesEstado == other.DetallesEstado ||
                    DetallesEstado != null &&
                    DetallesEstado.Equals(other.DetallesEstado)
                ) && 
                (
                    Tarjeta == other.Tarjeta ||
                    Tarjeta != null &&
                    Tarjeta.Equals(other.Tarjeta)
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
                    if (DevolucionId != null)
                    hashCode = hashCode * 59 + DevolucionId.GetHashCode();
                    if (Total != null)
                    hashCode = hashCode * 59 + Total.GetHashCode();
                    if (Concepto != null)
                    hashCode = hashCode * 59 + Concepto.GetHashCode();
                    if (Referencia != null)
                    hashCode = hashCode * 59 + Referencia.GetHashCode();
                    if (Fecha != null)
                    hashCode = hashCode * 59 + Fecha.GetHashCode();
                    if (Estado != null)
                    hashCode = hashCode * 59 + Estado.GetHashCode();
                    if (DetallesEstado != null)
                    hashCode = hashCode * 59 + DetallesEstado.GetHashCode();
                    if (Tarjeta != null)
                    hashCode = hashCode * 59 + Tarjeta.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Pagos left, Pagos right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pagos left, Pagos right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
