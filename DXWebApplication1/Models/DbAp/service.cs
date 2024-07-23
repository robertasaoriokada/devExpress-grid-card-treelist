namespace DXWebApplication1.Models.DbAp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            services1 = new HashSet<service>();
        }

        [Key]
        public int IdService { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int? ParentKey { get; set; }

        //[Required]
        [StringLength(50)]
        public string NumberItem { get; set; } 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service> services1 { get; set; }

        public virtual service service1 { get; set; }
    }
}
