using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class PostBusiness : IPostBusiness
    {
        private IPostRepository _res;

        public PostBusiness(IPostRepository res)
        {
            _res = res;
        }
  
        public List<Post> Search(int pageIndex, int pageSize, out long total)
        {
            return _res.Search(pageIndex, pageSize, out total);
        }
    }
}
