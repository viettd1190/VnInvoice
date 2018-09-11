using System;
using System.Collections.Generic;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class InternalDeliveryCreateModel
    {
        /// <summary>
        ///     Cá nhân/đơn vị điều động
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Id phiếu xuất kho
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Ngày tạo phiếu xuất kho
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        ///     Mẫu số
        /// </summary>
        public string TemplateNo { get; set; }

        /// <summary>
        ///     Ký hiệu
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        ///     Loại hóa đơn
        /// </summary>
        public string InvoiceTypeCode { get; set; }

        /// <summary>
        ///     Tổng thành tiền
        /// </summary>
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Lệnh điều động số
        /// </summary>
        public string DeliveryOrderNumber { get; set; }

        /// <summary>
        ///     Ngày điều động
        /// </summary>
        public DateTime DeliveryOrderDate { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        ///     Tên người vận chuyển
        /// </summary>
        public string DeliveryBy { get; set; }

        /// <summary>
        ///     Hợp đồng vận chuyển số
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        ///     Ngày hợp đồng
        /// </summary>
        public DateTime? ContractDate { get; set; }

        /// <summary>
        ///     Phương tiện vận chuyển
        /// </summary>
        public string TransportationMethod { get; set; }

        /// <summary>
        ///     Địa điểm nhận hàng
        /// </summary>
        public string PlaceOfReceipt { get; set; }

        /// <summary>
        ///     Kho xuất
        /// </summary>
        public string FromWarehouseName { get; set; }

        /// <summary>
        ///     Kho nhập
        /// </summary>
        public string ToWarehouseName { get; set; }

        /// <summary>
        ///     Số container
        /// </summary>
        public string CointanerNumber { get; set; }

        /// <summary>
        ///     Chi tiết
        /// </summary>
        public List<InternalDeliveryDetailModel> Details { get; set; }
    }

    public class InternalDeliveryDetailModel
    {
        /// <summary>
        ///     Id bản ghi sản phẩm
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Id đơn vị tính
        /// </summary>
        public string UnitId { get; set; }

        /// <summary>
        ///     Mã sản phẩm
        /// </summary>
        public string ProductNo { get; set; }

        /// <summary>
        ///     Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///     Tên đơn vị tính
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        ///     Đơn giá
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        ///     Số lượng thực xuất
        /// </summary>
        public double QuantityActualExport { get; set; }

        /// <summary>
        ///     Số lượng thực nhập
        /// </summary>
        public double? QuantityActualImported { get; set; }

        /// <summary>
        ///     Thành tiền
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        public string Note { get; set; }
    }
}
