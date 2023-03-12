using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccessLayer
{
    public partial interface IIncomeRepository
    {
        bool Create(Income model);
        //bool Update(Income model);
        List<Income> GetByID(int id); //Lấy danh sách nộp tiền của mỗi sinh viên có mã = id
        List<IncomeCustom> Search(int pageIndex, int pageSize, out long total, int student_id, string payment_type,
            DateTime date_payment, string payment_method); //Lấy danh sách thu chi sắp xếp theo ngày thanh toán mới nhất
    }
}
