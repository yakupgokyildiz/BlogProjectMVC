namespace YakupMyBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlogTag")]
    public partial class BlogTag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogTagId { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlogID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagID { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
