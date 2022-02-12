namespace bivva_ser
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("courses")]
    public partial class courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public courses()
        {
            users1 = new HashSet<users>();
        }

        [Key]
        public int course_id { get; set; }

        [Required]
        [StringLength(255)]
        public string course_name { get; set; }

        public int tutor_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime course_date { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string course_description { get; set; }
        
        [JsonIgnore]
        public virtual users users { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users> users1 { get; set; }
    }
}
