using System;
using System.Collections.Generic;
using Infra;

namespace DTO
{
    /// <summary>
    /// Representa a instância de um determinado amigo.
    /// </summary>
    public class Friend
    {
        /// <summary>
        /// Código do amigo
        /// </summary>
        public int IdFriend { get; set; }

        /// <summary>
        /// Nome do amigo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Código da localização
        /// </summary>
        public int IdLocalization { get; set; }

        /// <summary>
        /// Distância relativa a um determinado amigo
        /// </summary>
        [CustomAttributes(NoMapp = true)]
        public double RelativeDistance { get; set; }

        /// <summary>
        /// InstÂncia da localização onde reside o amigo
        /// </summary>
        public Localization Localization { get; set; }

        /// <summary>
        /// Lista contendo os amigos próximos
        /// </summary>
        public List<Friend> CloseFriends { get; set; }   
    }
}
