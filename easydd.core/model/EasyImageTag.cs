using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace easydd.core.model
{
    public class EasyImageTag : Entity
    {
        [ForeignKey("EasyImage")] public int EasyImageId { get; set; }
        [JsonIgnore] public EasyImage EasyImage { get; set; }
        [ForeignKey("Tag")] public int TagId { get; set; }
        [JsonIgnore] public Tag Tag { get; set; }
    }
}
