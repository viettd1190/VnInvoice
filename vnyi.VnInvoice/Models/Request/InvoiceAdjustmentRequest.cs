using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class InvoiceAdjustmentRequest
    {
        public InvoiceAdjustmentRequest()
        {
            Id = Guid.NewGuid()
                     .ToString();
        }

        public InvoiceAdjustmentRequest(InvoiceAdjustmentModel model) : this()
        {
            if(!string.IsNullOrEmpty(model.Id))
            {
                Id = model.Id;
            }

            Username = model.Username;
            BuyerId = model.BuyerId;
            BuyerGroupCode = model.BuyerGroupCode;
            BuyerGroupName = model.BuyerGroupName;
            RecordNo = model.RecordNo;
            RecordDate = model.RecordDate.ConvertToString();
            Reason = model.Reason;
            FileNameOfRecord = model.FileNameOfRecord;
            FileOfRecord = model.FileOfRecord;
            TotalAmount = model.TotalAmount;
            TotalVatAmount = model.TotalVatAmount;
            TotalDiscountAmountBeforeTax = model.TotalDiscountAmountBeforeTax;
            TotalDiscountPercentAfterTax = model.TotalDiscountPercentAfterTax;
            TotalDiscountAmountAfterTax = model.TotalDiscountAmountAfterTax;
            TotalPaymentAmount = model.TotalPaymentAmount;
            OriginTotalAmount = model.OriginTotalAmount;
            TotalAmountAfterAdjustment = model.TotalAmountAfterAdjustment;
            OriginTotalVatAmount = model.OriginTotalVatAmount;
            TotalVatAmountAfterAdjustment = model.TotalVatAmountAfterAdjustment;
            OriginTotalDiscountAmountBeforeTax = model.OriginTotalDiscountAmountBeforeTax;
            OriginTotalDiscountPercentAfterTax = model.OriginTotalDiscountPercentAfterTax;
            OriginTotalDiscountAmountAfterTax = model.OriginTotalDiscountAmountAfterTax;
            TotalDiscountAmountBeforeTaxAfterAdj = model.TotalDiscountAmountBeforeTaxAfterAdj;
            TotalDiscountPercentAfterTaxAfterAdj = model.TotalDiscountPercentAfterTaxAfterAdj;
            TotalDiscountAmountAfterTaxAfterAdj = model.TotalDiscountAmountAfterTaxAfterAdj;
            OriginTotalPaymentAmount = model.OriginTotalPaymentAmount;
            TotalPaymentAmountAfterAdjustment = model.TotalPaymentAmountAfterAdjustment;
            Details = new List<InvoiceAdjustmentDetail>();
            TaxBreakdowns = new List<InvoiceAdjustmentTaxBreakdown>();
        }

        /// <summary>
        ///     Id hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Username tạo bản ghi hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "userNameCreator")]
        public string Username { get; set; }

        /// <summary>
        ///     Id khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "idBuyer")]
        public string BuyerId { get; set; }

        /// <summary>
        ///     Tên nhóm khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerGroupName")]
        public string BuyerGroupName { get; set; }

        /// <summary>
        ///     Mã nhóm khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerGroupCode")]
        public string BuyerGroupCode { get; set; }

        /// <summary>
        ///     Số biên bản điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "recordNo")]
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày biên bản điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "recordDate")]
        public string RecordDate { get; set; }

        /// <summary>
        ///     Lý do điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Tên file biên bản
        /// </summary>
        [JsonProperty(PropertyName = "fileNameOfRecord")]
        public string FileNameOfRecord { get; set; }

        /// <summary>
        ///     Dữ liệu file biên bản base64
        /// </summary>
        [JsonProperty(PropertyName = "fileOfRecord")]
        public string FileOfRecord { get; set; }

        /// <summary>
        ///     Tổng thành tiền điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalAmount")]
        public double TotalAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thuế điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalVatAmount")]
        public double TotalVatAmount { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu trước thuế điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountAmountBeforeTax")]
        public double? TotalDiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     % chiết khấu sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountPercentAfterTax")]
        public double? TotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tiền chiết khấu sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountAmountAfterTax")]
        public double? TotalDiscountAmountAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalPaymentAmount")]
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Tổng thành tiền hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originTotalAmount")]
        public double OriginTotalAmount { get; set; }

        /// <summary>
        ///     Tổng thành tiền sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalAmountAfterAdjustment")]
        public double TotalAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Tổng tiền thuế hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originTotalVatAmount")]
        public double OriginTotalVatAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thuế sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalVatAmountAfterAdjustment")]
        public double TotalVatAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu trước thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originTotalDiscountAmountBeforeTax")]
        public double? OriginTotalDiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     % chiết khấu sau thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originTotalDiscountPercentAfterTax")]
        public double? OriginTotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu sau thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originTotalDiscountAmountAfterTax")]
        public double? OriginTotalDiscountAmountAfterTax { get; set; }

        //[JsonProperty(PropertyName = "id")] public double? TotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu trước thuế sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountAmountBeforeTaxAfterAdj")]
        public double? TotalDiscountAmountBeforeTaxAfterAdj { get; set; }

        /// <summary>
        ///     % chiết khấu sau thuế sau khi điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountPercentAfterTaxAfterAdj")]
        public double? TotalDiscountPercentAfterTaxAfterAdj { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu sau thuế sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountAmountAfterTaxAfterAdj")]
        public double? TotalDiscountAmountAfterTaxAfterAdj { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originTotalPaymentAmount")]
        public double OriginTotalPaymentAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "totalPaymentAmountAfterAdjustment")]
        public double TotalPaymentAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Chi tiết hàng hóa hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "invoiceDetails")]
        public List<InvoiceAdjustmentDetail> Details { get; set; }

        /// <summary>
        ///     Mảng chứa tổng các loại thuế suất trên hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "invoiceTaxBreakdowns")]
        public List<InvoiceAdjustmentTaxBreakdown> TaxBreakdowns { get; set; }
    }

    public class InvoiceAdjustmentDetail
    {
        public InvoiceAdjustmentDetail()
        {
            Id = Guid.NewGuid()
                     .ToString();
        }

        public InvoiceAdjustmentDetail(InvoiceAdjustmentDetailModel model) : this()
        {
            ProductId = model.ProductId;
            UnitId = model.UnitId;
            ProductNo = model.ProductNo;
            ProductName = model.ProductName;
            UnitName = model.UnitName;
            UnitPrice = model.UnitPrice;
            Quantity = model.Quantity;
            Amount = model.Amount;
            VatPercent = (int) model.VatPercent;
            VatPercentDisplay = model.VatPercent.ConvertToString();
            VatAmount = model.VatAmount;
            DiscountAmountBeforeTax = model.DiscountAmountBeforeTax;
            DiscountPercentBeforeTax = model.DiscountPercentBeforeTax;
            OriginDiscountAmountBeforeTax = model.OriginDiscountAmountBeforeTax;
            OriginDiscountPercentBeforeTax = model.OriginDiscountPercentBeforeTax;
            DiscountAmountBeforeTaxAfterAdj = model.DiscountAmountBeforeTaxAfterAdj;
            DiscountPercentBeforeTaxAfterAdj = model.DiscountPercentBeforeTaxAfterAdj;
            PaymentAmount = model.PaymentAmount;
            OriginQuantity = model.Quantity;
            QuantityAfterAdjustment = model.QuantityAfterAdjustment;
            OriginUnitPrice = model.OriginUnitPrice;
            UnitPriceAfterAdjustment = model.UnitPriceAfterAdjustment;
            OriginAmount = model.OriginAmount;
            AmountAfterAdjustment = model.AmountAfterAdjustment;
            OriginVatPercent = model.OriginVatPercent;
            OriginVatAmount = model.OriginVatAmount;
            VatAmountAfterAdjustment = model.VatAmountAfterAdjustment;
            OriginPaymentAmount = model.OriginPaymentAmount;
            PaymentAmountAfterAdjustment = model.PaymentAmountAfterAdjustment;
            Note = model.Note;
        }

        /// <summary>
        ///     Id bản ghi
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Id sản phẩm
        /// </summary>
        [JsonProperty(PropertyName = "idProduct ")]
        public string ProductId { get; set; }

        /// <summary>
        ///     Id đơn vị tính
        /// </summary>
        [JsonProperty(PropertyName = "idUnit")]
        public string UnitId { get; set; }

        /// <summary>
        ///     Mã sản phẩm
        /// </summary>
        [JsonProperty(PropertyName = "productId")]
        public string ProductNo { get; set; }

        /// <summary>
        ///     Tên sản phẩm
        /// </summary>
        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

        /// <summary>
        ///     Đơn vị tính
        /// </summary>
        [JsonProperty(PropertyName = "unitName")]
        public string UnitName { get; set; }

        /// <summary>
        ///     Đơn giá
        /// </summary>
        [JsonProperty(PropertyName = "unitPrice")]
        public double UnitPrice { get; set; }

        /// <summary>
        ///     Số lượng
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public double Quantity { get; set; }

        /// <summary>
        ///     Thành tiền trước thuế
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        /// <summary>
        ///     Phần trăm thuế
        ///     -2: không kê khai
        ///     -1: không chịu thuế
        ///     0: 0%
        ///     5: 5%
        ///     10: 10%
        /// </summary>
        [JsonProperty(PropertyName = "vatPercent")]
        public double VatPercent { get; set; }

        /// <summary>
        ///     Phần trăm thuế hiển thị
        /// </summary>
        [JsonProperty(PropertyName = "vatPercentDisplay")]
        public string VatPercentDisplay { get; set; }

        /// <summary>
        ///     Tiền thuế
        /// </summary>
        [JsonProperty(PropertyName = "vatAmount")]
        public double VatAmount { get; set; }

        /// <summary>
        ///     Số tiền chiết khấu trước thuế
        /// </summary>
        [JsonProperty(PropertyName = "discountAmountBeforeTax")]
        public double? DiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu trước thuế
        /// </summary>
        [JsonProperty(PropertyName = "discountPercentBeforeTax")]
        public double? DiscountPercentBeforeTax { get; set; }

        /// <summary>
        ///     Tổng chiết khấu trước thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originDiscountAmountBeforeTax")]
        public double? OriginDiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu trước thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originDiscountPercentBeforeTax")]
        public double? OriginDiscountPercentBeforeTax { get; set; }

        /// <summary>
        ///     Tiền chiết khấu trước thuế sau khi điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "discountAmountBeforeTaxAfterAdj")]
        public double? DiscountAmountBeforeTaxAfterAdj { get; set; }

        /// <summary>
        ///     % chiết khấu trước thuế sau khi điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "discountPercentBeforeTaxAfterAdj")]
        public double? DiscountPercentBeforeTaxAfterAdj { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế
        /// </summary>
        [JsonProperty(PropertyName = "paymentAmount")]
        public double PaymentAmount { get; set; }

        /// <summary>
        ///     Số lượng trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originQuantity")]
        public double OriginQuantity { get; set; }

        /// <summary>
        ///     Số lượng sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "quantityAfterAdjustment")]
        public double QuantityAfterAdjustment { get; set; }

        /// <summary>
        ///     Đơn giá trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originUnitPrice")]
        public double OriginUnitPrice { get; set; }

        /// <summary>
        ///     Đơn giá sau điều chỉnh3
        /// </summary>
        [JsonProperty(PropertyName = "unitPriceAfterAdjustment")]
        public double UnitPriceAfterAdjustment { get; set; }

        /// <summary>
        ///     Thành tiền trước thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originAmount")]
        public double OriginAmount { get; set; }

        /// <summary>
        ///     Thành tiền trước thuế sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "amountAfterAdjustment")]
        public double AmountAfterAdjustment { get; set; }

        /// <summary>
        ///     % thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originVatPercent")]
        public double OriginVatPercent { get; set; }

        /// <summary>
        ///     Tiền thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originVatAmount")]
        public double OriginVatAmount { get; set; }

        /// <summary>
        ///     Tiền thuế sau điều chình
        /// </summary>
        [JsonProperty(PropertyName = "vatAmountAfterAdjustment")]
        public double VatAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originPaymentAmount")]
        public double OriginPaymentAmount { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế sau khi điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "paymentAmountAfterAdjustment")]
        public double PaymentAmountAfterAdjustment { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }

    public class InvoiceAdjustmentTaxBreakdown
    {
        public InvoiceAdjustmentTaxBreakdown()
        {
        }

        public InvoiceAdjustmentTaxBreakdown(InvoiceAdjustmentTaxBreakdownModel model) : this()
        {
            VatPercent = (int) model.VatPercent;
            VatAmount = model.VatAmount;
            OriginVatAmount = (int) model.OriginVatAmount;
            OriginVatAmountAfterAdj = model.OriginVatAmountAfterAdj;
            Name = model.VatPercent.ConvertToString();
        }

        /// <summary>
        ///     Tên hiển thị loại thuế
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     % thuế
        /// </summary>
        [JsonProperty(PropertyName = "vatPercent")]
        public double VatPercent { get; set; }

        /// <summary>
        ///     Tổng tiền 1 loại thuế
        /// </summary>
        [JsonProperty(PropertyName = "vatAmount")]
        public double VatAmount { get; set; }

        /// <summary>
        ///     % thuế trên hóa đơn gốc
        /// </summary>
        [JsonProperty(PropertyName = "originVatAmount")]
        public double OriginVatAmount { get; set; }

        /// <summary>
        ///     Tiền thuế sau điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "originVatAmountAfterAdj")]
        public double OriginVatAmountAfterAdj { get; set; }
    }
}
