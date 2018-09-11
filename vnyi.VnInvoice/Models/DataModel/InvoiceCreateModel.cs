using System;
using System.Collections.Generic;
using vnyi.VnInvoice.Enums;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class InvoiceCreateModel
    {
        /// <summary>
        ///     Id hóa đơn
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Username tạo bản ghi hóa đơn
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Id khách hàng
        /// </summary>
        public string BuyerId { get; set; }

        /// <summary>
        ///     Mã khách hàng
        /// </summary>
        public string BuyerCode { get; set; }

        /// <summary>
        ///     Id nhóm khách hàng
        /// </summary>
        public string BuyerGroupId { get; set; }

        /// <summary>
        ///     Tên nhóm khách hàng
        /// </summary>
        public string BuyerGroupName { get; set; }

        /// <summary>
        ///     Mã tiền tệ
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        ///     Ngày lập hóa đơn
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        ///     Ghi chú trên toàn hóa đơn
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        ///     Mẫu hóa đơn. VD: 01GTKT0/001; 02GTTT0/001;...
        /// </summary>
        public string TemplateNo { get; set; }

        /// <summary>
        ///     Ký hiệu hóa đơn. VD: AA/18E; AB/18E;...
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        ///     Loại hóa đơn. VD: 01GTKT; 02GTTT;...
        /// </summary>
        public string InvoiceTypeCode { get; set; }

        /// <summary>
        ///     Tỷ giá, với VND mặc định là 1
        /// </summary>
        public double? ExchangeRate { get; set; }

        /// <summary>
        ///     Hình thức thanh toán: TM, CK, TM/CK
        /// </summary>
        public PaymentMethodType PaymentMethod { get; set; }

        /// <summary>
        ///     Ngày thanh toán, định dạng: yyyy-mm-dd
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu toàn hóa đơn
        /// </summary>
        public double TotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu toàn hóa đơn
        /// </summary>
        public double TotalDiscountAmountAfterTax { get; set; }

        /// <summary>
        ///     Mã nhóm khách hàng
        /// </summary>
        public string BuyerGroupCode { get; set; }

        /// <summary>
        ///     Email khách hàng
        /// </summary>
        public string BuyerEmail { get; set; }

        /// <summary>
        ///     Tên người/tổ chức mua hàng
        /// </summary>
        public string BuyerFullName { get; set; }

        /// <summary>
        ///     Tên người đại diện
        /// </summary>
        public string BuyerLegalName { get; set; }

        /// <summary>
        ///     Mã số thuế đơn vị mua hàng
        /// </summary>
        public string BuyerTaxCode { get; set; }

        /// <summary>
        ///     Địa chỉ đơn vị mua hàng
        /// </summary>
        public string BuyerAddressLine { get; set; }

        /// <summary>
        ///     Mã bưu chính đơn vị mua hàng
        /// </summary>
        public string BuyerPostalCode { get; set; }

        /// <summary>
        ///     Quận huyện
        /// </summary>
        public string BuyerDistrictName { get; set; }

        /// <summary>
        ///     Tỉnh thành
        /// </summary>
        public string BuyerCityName { get; set; }

        /// <summary>
        ///     Mã quốc gia
        /// </summary>
        public string BuyerCountryCode { get; set; }

        /// <summary>
        ///     SĐT
        /// </summary>
        public string BuyerPhoneNumber { get; set; }

        /// <summary>
        ///     Số fax
        /// </summary>
        public string BuyerFaxNumber { get; set; }

        /// <summary>
        ///     Tên ngân hàng
        /// </summary>
        public string BuyerBankName { get; set; }

        /// <summary>
        ///     Số tài khoản
        /// </summary>
        public string BuyerBankAccount { get; set; }

        /// <summary>
        ///     Thông tin chi tiết hàng hóa
        /// </summary>
        public List<InvoiceDetailModel> Details { get; set; }

        /// <summary>
        ///     Tổng các loại thuế suất trên hóa đơn
        /// </summary>
        public List<InvoiceTaxBreakdownModel> InvoiceTaxBreakdowns { get; set; }
    }

    public class InvoiceDetailModel
    {
        /// <summary>
        ///     Id sản phẩm
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Id đơn vị tính
        /// </summary>
        public string UnitId { get; set; }

        /// <summary>
        ///     Số tiền chiết khấu trước thuế
        /// </summary>
        public double? DiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu trước thuế
        /// </summary>
        public double? DiscountPercentBeforeTax { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế
        /// </summary>
        public double PaymentAmount { get; set; }

        /// <summary>
        ///     Mã sản phẩm
        /// </summary>
        public string ProductNo { get; set; }

        /// <summary>
        ///     Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///     Đơn vị tính
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
        ///     Thành tiền trước thuế
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        ///     Phần trăm thuế
        ///     -2: không kê khai
        ///     -1: không chịu thuế
        ///     0: 0%
        ///     5: 5%
        ///     10: 10%
        /// </summary>
        public VatPercentType VatPercent { get; set; }

        /// <summary>
        ///     Tiền thuế
        /// </summary>
        public double VatAmount { get; set; }

        /// <summary>
        ///     Ghi chú cho mặt hàng
        /// </summary>
        public string Note { get; set; }
    }

    public class InvoiceTaxBreakdownModel
    {
        /// <summary>
        ///     Tổng số tiền chịu thuế của 1 loại thuế
        /// </summary>
        public double VatAmount { get; set; }

        /// <summary>
        ///     Phần trăm thuế
        /// </summary>
        public VatPercentType VatPercent { get; set; }
    }
}
