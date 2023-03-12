using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
