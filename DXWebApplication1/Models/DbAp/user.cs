namespace DXWebApplication1.Models.DbAp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string role { get; set; }

        public int age { get; set; }

        [StringLength(100)]
        public string bio { get; set; }

        [Column(TypeName = "date")]
        public DateTime createdAt { get; set; }
    }
}
