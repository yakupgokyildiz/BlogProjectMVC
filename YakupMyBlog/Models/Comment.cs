namespace YakupMyBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentId { get; set; }

        public string Thought { get; set; }

        public DateTime? UploadDate { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? Like { get; set; }

        public int? BlogID { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
