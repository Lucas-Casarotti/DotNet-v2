using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Usuario
    {
        [JsonPropertyName("idUsuario")]
        public int ID_Usuario { get; set; }

        [JsonPropertyName("nmUsuario")]
        public string NM_Usuario { get; set; }

        [JsonPropertyName("emailUsuario")]
        public string Email_Usuario { get; set; }

        [JsonPropertyName("cdInscricaoNacional")]
        public string CD_Inscricao_Nacional { get; set; }
    }
}
