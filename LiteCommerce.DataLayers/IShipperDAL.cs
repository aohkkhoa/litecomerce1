﻿using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến nhà vận chuyển
    /// </summary>
    public interface IShipperDAL
    {
        /// <summary>
        /// Bổ sung một nhà vận chuyển. Hàm trả về mã của nhà vận chuyển nếu bổ sung thành công.
        /// </summary>
        /// <param name="data">Đối tượng lưu thông tin của nhà vận chuyển cần bổ sung</param>
        /// <returns></returns>
        int Add(Shipper data);
        /// <summary>
        /// Lấy danh sách nhà vận chuyển (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page">Trang cần lấy dữ liệu</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang</param>
        /// <param name="searchValue">Giá trị cần tìm kiếm theo ShipperName, Phone (chuỗi rỗng nếu không có yêu cầu tìm kiếm)</param>
        /// <returns></returns>
        List<Shipper> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// Đếm số lượng nhà vận chuyển thỏa điều kiện tìm kiếm
        /// </summary>
        /// <param name="searchValue">Giá trị cần tìm kiếm theo ShipperName, Phone (chuỗi rỗng nếu không có yêu cầu tìm kiếm)</param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy thông tin của một nhà vận chuyển theo mã. Trong trường hợp nhà vận chuyển không tồn tại, hàm trả về giá trị null.
        /// </summary>
        /// <param name="shipperID">Mã của nhà vận chuyển cần lấy thông tin</param>
        /// <returns></returns>
        Shipper Get(int shipperID);
        /// <summary>
        /// Cập nhật thông tin của nhà vận chuyển. Hàm trả về boolean cho biết việc cập nhật có thành công hay không
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Shipper data);
        /// <summary>
        /// Xóa một nhà vận chuyển dựa vào mã. Hàm trả về giá trị bool cho biết việc xóa có thực hiện được hay không 
        /// (Lưu ý: không được xóa nhà vận chuyển nếu đang có đơn hàng tham chiếu đến nhà vận chuyển)
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        bool Delete(int shipperID);
    }
}
