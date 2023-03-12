using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class PostRepository : IPostRepository
    {
        private osc_centerContext _context;

        public PostRepository(osc_centerContext context)
        {
            _context = context;
        }

        public List<Post> Search(int pageIndex, int pageSize, out long total)
        {
            total = 0;
            try
            {
                var result = _context.Posts.
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    ToList();
                foreach(var post in result)
                {
                    if(post.Title.Length > 70)
                    {
                        post.Title = post.Title.Substring(0, 70) + "...";
                    }
                    if(post.Content.Length > 170)
                    {
                        post.Content = post.Content.Substring(0, 170) + "...";
                    }
                };
                total = _context.Posts.Count();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
