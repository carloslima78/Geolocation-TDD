using System;
using System.Collections.Generic;

namespace DTO
{
    /// <summary>
    /// Representa a instância de uma localizaçao
    /// </summary>
    public class Localization
    {
        /// <summary>
        /// Código da localização
        /// </summary>
        public int IdLocalization { get; set; }

        /// <summary>
        /// Estado pertinente a localização
        /// </summary>
        public string Estate { get; set; }

        /// <summary>
        /// Latitude pertinente a localização
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude pertinente a localização
        /// </summary>
        public double Longitude { get; set; }
    }
}
