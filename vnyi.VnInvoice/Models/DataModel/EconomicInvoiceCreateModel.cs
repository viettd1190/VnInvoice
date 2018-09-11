using System;
using System.Collections.Generic;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class EconomicInvoiceCreateModel
    {
        /// <summary>
        ///     Id phiếu xuất
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Ngày hợp đồng giao hàng
        /// </summary>
        public DateTime EconomicContractDate { get; set; }

        /// <summary>
        ///     Hợp đồng giao hàng số
        /// </summary>
        public string EconocmicContractNumber { get; set; }

        /// <summary>
        ///     Họ tên người vận chuyển
        /// </summary>
        public string DeliveryBy { get; set; }

        /// <summary>
        ///     Số hợp đồng vận chuyển
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        ///     Kho xuất
        /// </summary>
        public string FromWarehouseName { get; set; }

        /// <summary>
        ///     Kho nhập
        /// </summary>
        public string ToWarehouseName { get; set; }

        /// <summary>
        ///     Phương tiện vận chuyển
        /// </summary>
        public string TransactionMethod { get; set; }

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
        ///     Tiền tệ
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        ///     Tỷ giá
        /// </summary>
        public double ExchangeRate { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán
        /// </summary>
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Địa chỉ nhận hàng
        /// </summary>
        public string BuyerAddressLine { get; set; }

        /// <summary>
        ///     Tên khách hàng
        /// </summary>
        public string BuyerFullName { get; set; }

        /// <summary>
        ///     Tên đơn vị mua hàng
        /// </summary>
        public string BuyerLegalName { get; set; }

        /// <summary>
        ///     Mã số thuế người mua
        /// </summary>
        public string BuyerTaxCode { get; set; }

        /// <summary>
        ///     Chi tiết đơn hàng
        /// </summary>
        public List<EconomicInvoiceDetailModel> Details { get; set; }
    }

    public class EconomicInvoiceDetailModel
    {
        /// <summary>
        ///     Id sản phẩm
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Mã sản phẩm
        /// </summary>
        public string ProductNo { get; set; }

        /// <summary>
        ///     Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///     Mã đơn vị tính
        /// </summary>
        public string UnitId { get; set; }

        /// <summary>
        ///     Tên đơn vị tính
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        ///     Đơn giá
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        ///     Số lượng
        /// </summary>
        public double Quantity { get; set; }

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
