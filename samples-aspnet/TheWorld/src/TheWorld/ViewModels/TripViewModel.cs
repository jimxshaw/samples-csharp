using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.ViewModels
{
    public class TripViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }

        // New C# 6 syntax to initialize an auto-property.
        // Same as creating a constructor and specifying it.
        public DateTime Created { get; set; } = DateTime.UtcNow;


    }
}
