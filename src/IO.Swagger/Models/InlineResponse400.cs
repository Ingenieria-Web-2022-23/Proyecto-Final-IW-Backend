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
    public partial class InlineResponse400 : IEquatable<InlineResponse400>
    { 
        /// <summary>
        /// Gets or Sets TypeError
        /// </summary>

        [DataMember(Name="typeError")]
        public string TypeError { get; set; }

        /// <summary>
        /// Gets or Sets MessageError
        /// </summary>

        [DataMember(Name="messageError")]
        public string MessageError { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse400 {\n");
            sb.Append("  TypeError: ").Append(TypeError).Append("\n");
            sb.Append("  MessageError: ").Append(MessageError).Append("\n");
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
            return obj.GetType() == GetType() && Equals((InlineResponse400)obj);
        }

        /// <summary>
        /// Returns true if InlineResponse400 instances are equal
        /// </summary>
        /// <param name="other">Instance of InlineResponse400 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse400 other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TypeError == other.TypeError ||
                    TypeError != null &&
                    TypeError.Equals(other.TypeError)
                ) && 
                (
                    MessageError == other.MessageError ||
                    MessageError != null &&
                    MessageError.Equals(other.MessageError)
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
                    if (TypeError != null)
                    hashCode = hashCode * 59 + TypeError.GetHashCode();
                    if (MessageError != null)
                    hashCode = hashCode * 59 + MessageError.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(InlineResponse400 left, InlineResponse400 right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InlineResponse400 left, InlineResponse400 right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
