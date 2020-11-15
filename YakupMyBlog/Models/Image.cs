namespace YakupMyBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int ImageId { get; set; }

        [StringLength(250)]
        public string SmallSize { get; set; }

        [StringLength(250)]
        public string MediumSize { get; set; }

        [StringLength(250)]
        public string BigSize { get; set; }

        [StringLength(250)]
        public string MixImage { get; set; }

        [StringLength(250)]
        public string Video { get; set; }

        public int? BlogID { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
