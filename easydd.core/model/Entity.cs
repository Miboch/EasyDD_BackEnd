using System;
using System.ComponentModel.DataAnnotations;

namespace easydd.core.model
{
    public class Entity
    {
        [Key] public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
