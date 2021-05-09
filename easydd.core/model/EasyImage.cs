using System.Collections.Generic;

namespace easydd.core.model
{
#nullable enable
    public class EasyImage : Entity
    {
        public string ImgPath { get; set; } = "";
        public string ImageName { get; set; } = "";
        public IEnumerable<EasyImageTag> ImageTags { get; set; } = new List<EasyImageTag>();
        public byte[]? ImageData { get; set; }
    }
}
