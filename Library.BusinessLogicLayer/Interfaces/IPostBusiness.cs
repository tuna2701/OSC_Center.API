using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IPostBusiness
    {
        List<Post> Search(int pageIndex, int pageSize, out long total);
    }
}
