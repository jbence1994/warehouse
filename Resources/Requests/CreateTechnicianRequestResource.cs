﻿using System.ComponentModel.DataAnnotations;

namespace Warehouse.Resources.Requests
{
    public class CreateTechnicianRequestResource
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string Phone { get; set; }
    }
}