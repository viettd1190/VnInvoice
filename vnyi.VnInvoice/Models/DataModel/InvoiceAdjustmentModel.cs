using System;
using System.Collections.Generic;
using vnyi.VnInvoice.Enums;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class InvoiceAdjustmentModel
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
        ///     Tên nhóm khách hàng
        /// </summary>
        public string BuyerGroupName { get; set; }

        /// <summary>
        ///     Mã nhóm khách hàng
        /// </summary>
        public string BuyerGroupCode { get; set; }

        /// <summary>
        ///     Số biên bản điều chỉnh
        /// </summary>
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày biên bản điều chỉnh
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        ///     Lý do điều chỉnh
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        ///     Tên file biên bản
        /// </summary>
        public string FileNameOfRecord { get; set; }

        /// <summary>
        ///     Dữ liệu file biên bản base64
        /// </summary>
        public string FileOfRecord { get; set; }

        /// <summary>
        ///     Tổng thành tiền điều chỉnh
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thuế điều chỉnh
        /// </summary>
        public double TotalVatAmount { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu trước thuế điều chỉnh
        /// </summary>
        public double? TotalDiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     % chiết khấu sau điều chỉnh
        /// </summary>
        public double? TotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tiền chiết khấu sau điều chỉnh
        /// </summary>
        public double? TotalDiscountAmountAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán điều chỉnh
        /// </summary>
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Tổng thành tiền hóa đơn gốc
        /// </summary>
        public double OriginTotalAmount { get; set; }

        /// <summary>
        ///     Tổng thành tiền sau điều chỉnh
        /// </summary>
        public double TotalAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Tổng tiền thuế hóa đơn gốc
        /// </summary>
        public double OriginTotalVatAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thuế sau điều chỉnh
        /// </summary>
        public double TotalVatAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu trước thuế trên hóa đơn gốc
        /// </summary>
        public double? OriginTotalDiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     % chiết khấu sau thuế trên hóa đơn gốc
        /// </summary>
        public double? OriginTotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu sau thuế trên hóa đơn gốc
        /// </summary>
        public double? OriginTotalDiscountAmountAfterTax { get; set; }

        //public double? TotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu trước thuế sau điều chỉnh
        /// </summary>
        public double? TotalDiscountAmountBeforeTaxAfterAdj { get; set; }

        /// <summary>
        ///     % chiết khấu sau thuế sau khi điều chỉnh
        /// </summary>
        public double? TotalDiscountPercentAfterTaxAfterAdj { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu sau thuế sau điều chỉnh
        /// </summary>
        public double? TotalDiscountAmountAfterTaxAfterAdj { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán trên hóa đơn gốc
        /// </summary>
        public double OriginTotalPaymentAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán sau điều chỉnh
        /// </summary>
        public double TotalPaymentAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Chi tiết hàng hóa
        /// </summary>
        public List<InvoiceAdjustmentDetailModel> Details { get; set; }

        /// <summary>
        ///     Tổng các loại thuế suất trên hóa đơn
        /// </summary>
        public List<InvoiceAdjustmentTaxBreakdownModel> TaxBreakdowns { get; set; }
    }

    public class InvoiceAdjustmentDetailModel
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
        ///     Số tiền chiết khấu trước thuế
        /// </summary>
        public double? DiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu trước thuế
        /// </summary>
        public double? DiscountPercentBeforeTax { get; set; }

        /// <summary>
        ///     Tổng chiết khấu trước thuế trên hóa đơn gốc
        /// </summary>
        public double? OriginDiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu trước thuế trên hóa đơn gốc
        /// </summary>
        public double? OriginDiscountPercentBeforeTax { get; set; }

        /// <summary>
        ///     Tiền chiết khấu trước thuế sau khi điều chỉnh
        /// </summary>
        public double? DiscountAmountBeforeTaxAfterAdj { get; set; }

        /// <summary>
        ///     % chiết khấu trước thuế sau khi điều chỉnh
        /// </summary>
        public double? DiscountPercentBeforeTaxAfterAdj { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế
        /// </summary>
        public double PaymentAmount { get; set; }

        /// <summary>
        ///     Số lượng trên hóa đơn gốc
        /// </summary>
        public double OriginQuantity { get; set; }

        /// <summary>
        ///     Số lượng sau điều chỉnh
        /// </summary>
        public double QuantityAfterAdjustment { get; set; }

        /// <summary>
        ///     Đơn giá trên hóa đơn gốc
        /// </summary>
        public double OriginUnitPrice { get; set; }

        /// <summary>
        ///     Đơn giá sau điều chỉnh3
        /// </summary>
        public double UnitPriceAfterAdjustment { get; set; }

        /// <summary>
        ///     Thành tiền trước thuế trên hóa đơn gốc
        /// </summary>
        public double OriginAmount { get; set; }

        /// <summary>
        ///     Thành tiền trước thuế sau điều chỉnh
        /// </summary>
        public double AmountAfterAdjustment { get; set; }

        /// <summary>
        ///     % thuế trên hóa đơn gốc
        /// </summary>
        public double OriginVatPercent { get; set; }

        /// <summary>
        ///     Tiền thuế trên hóa đơn gốc
        /// </summary>
        public double OriginVatAmount { get; set; }

        /// <summary>
        ///     Tiền thuế sau điều chình
        /// </summary>
        public double VatAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế trên hóa đơn gốc
        /// </summary>
        public double OriginPaymentAmount { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế sau khi điều chỉnh
        /// </summary>
        public double PaymentAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        public string Note { get; set; }
    }

    public class InvoiceAdjustmentTaxBreakdownModel
    {
        /// <summary>
        ///     % thuế
        /// </summary>
        public VatPercentType VatPercent { get; set; }

        /// <summary>
        ///     Tổng tiền 1 loại thuế
        /// </summary>
        public double VatAmount { get; set; }

        /// <summary>
        ///     % thuế trên hóa đơn gốc
        /// </summary>
        public VatPercentType OriginVatAmount { get; set; }

        /// <summary>
        ///     Tiền thuế sau điều chỉnh
        /// </summary>
        public double OriginVatAmountAfterAdj { get; set; }
    }
}
