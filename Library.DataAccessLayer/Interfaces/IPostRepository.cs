using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccessLayer
{
    public partial interface IPostRepository
    {
        List<Post> Search(int pageIndex, int pageSize, out long total);
    }
}
