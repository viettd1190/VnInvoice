using System.Collections.Generic;
using Newtonsoft.Json;

namespace vnyi.HaLinh.Models
{
    public class InvoiceCreateRequest
    {
        /// <summary>
        ///     Mã giao dịch
        /// </summary>
        [JsonProperty(PropertyName = "idTransaction")]
        public string TransactionId { get; set; }

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
        ///     Mã khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerCode")]
        public string BuyerCode { get; set; }

        /// <summary>
        ///     Id nhóm khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "idBuyerGroup")]
        public string BuyerGroupId { get; set; }

        /// <summary>
        ///     Tên nhóm khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerGroupName")]
        public string BuyerGroupName { get; set; }

        /// <summary>
        ///     Mã tiền tệ
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        ///     Ngày lập hóa đơn, định dạng: yyyy-mm-dd
        /// </summary>
        [JsonProperty(PropertyName = "invoiceDate")]
        public string InvoiceDate { get; set; }

        /// <summary>
        ///     Ghi chú trên toàn hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        /// <summary>
        ///     Mẫu hóa đơn. VD: 01GTKT0/001; 02GTTT0/001;...
        /// </summary>
        [JsonProperty(PropertyName = "templateNo")]
        public string TemplateNo { get; set; }

        /// <summary>
        ///     Ký hiệu hóa đơn. VD: AA/18E; AB/18E;...
        /// </summary>
        [JsonProperty(PropertyName = "serialNo")]
        public string SerialNo { get; set; }

        /// <summary>
        ///     Loại hóa đơn. VD: 01GTKT; 02GTTT;...
        /// </summary>
        [JsonProperty(PropertyName = "invoiceTypeCode")]
        public string InvoiceTypeCode { get; set; }

        /// <summary>
        ///     Tỷ giá, với VND mặc định là 1
        /// </summary>
        [JsonProperty(PropertyName = "exchangeRate")]
        public double ExchangeRate { get; set; }

        /// <summary>
        ///     Hình thức thanh toán: TM, CK, TM/CK
        /// </summary>
        [JsonProperty(PropertyName = "paymentMethod")]
        public string PaymentMethod { get; set; }

        /// <summary>
        ///     Ngày thanh toán, định dạng: yyyy-mm-dd
        /// </summary>
        [JsonProperty(PropertyName = "paymentDate")]
        public string PaymentDate { get; set; }

        /// <summary>
        ///     Tổng thành tiền chưa bao gồm thuế vat
        /// </summary>
        [JsonProperty(PropertyName = "totalAmount")]
        public double TotalAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thuế
        /// </summary>
        [JsonProperty(PropertyName = "totalVatAmount")]
        public double TotalVatAmount { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán, tính cả vat
        /// </summary>
        [JsonProperty(PropertyName = "totalPaymentAmount")]
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu cho từng dòng
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountAmountBeforeTax")]
        public double TotalDiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu toàn hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountPercentAfterTax")]
        public double TotalDiscountPercentAfterTax { get; set; }

        /// <summary>
        ///     Tổng tiền chiết khấu toàn hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "totalDiscountAmountAfterTax")]
        public double TotalDiscountAmountAfterTax { get; set; }

        /// <summary>
        ///     Mã nhóm khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerGroupCode")]
        public string BuyerGroupCode { get; set; }

        /// <summary>
        ///     Email khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerEmail")]
        public string BuyerEmail { get; set; }

        /// <summary>
        ///     Tên người/tổ chức mua hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerFullName")]
        public string BuyerFullName { get; set; }

        /// <summary>
        ///     Tên người đại diện
        /// </summary>
        [JsonProperty(PropertyName = "buyerLegalName")]
        public string BuyerLegalName { get; set; }

        /// <summary>
        ///     Mã số thuế đơn vị mua hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerTaxCode")]
        public string BuyerTaxCode { get; set; }

        /// <summary>
        ///     Địa chỉ đơn vị mua hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerAddressLine")]
        public string BuyerAddressLine { get; set; }

        /// <summary>
        ///     Mã bưu chính đơn vị mua hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerPostalCode")]
        public string BuyerPostalCode { get; set; }

        /// <summary>
        ///     Quận huyện
        /// </summary>
        [JsonProperty(PropertyName = "buyerDistrictName")]
        public string BuyerDistrictName { get; set; }

        /// <summary>
        ///     Tỉnh thành
        /// </summary>
        [JsonProperty(PropertyName = "buyerCityName")]
        public string BuyerCityName { get; set; }

        /// <summary>
        ///     Mã quốc gia
        /// </summary>
        [JsonProperty(PropertyName = "buyerCountryCode")]
        public string BuyerCountryCode { get; set; }

        /// <summary>
        ///     SĐT
        /// </summary>
        [JsonProperty(PropertyName = "buyerPhoneNumber")]
        public string BuyerPhoneNumber { get; set; }

        /// <summary>
        ///     Số fax
        /// </summary>
        [JsonProperty(PropertyName = "buyerFaxNumber")]
        public string BuyerFaxNumber { get; set; }

        /// <summary>
        ///     Tên ngân hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerBankName")]
        public string BuyerBankName { get; set; }

        /// <summary>
        ///     Số tài khoản
        /// </summary>
        [JsonProperty(PropertyName = "buyerBankAccount")]
        public string BuyerBankAccount { get; set; }

        /// <summary>
        ///     Thông tin chi tiết hàng hóa
        /// </summary>
        [JsonProperty(PropertyName = "invoiceDetails")]
        public List<InvoiceDetail> Details { get; set; }

        /// <summary>
        ///     Tổng các loại thuế suất trên hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "invoiceTaxBreakdowns")]
        public List<InvoiceTaxBreakdown> InvoiceTaxBreakdowns { get; set; }
    }

    public class InvoiceDetail
    {
        /// <summary>
        ///     Id sản phẩm
        /// </summary>
        [JsonProperty(PropertyName = "idProduct")]
        public string ProductId { get; set; }

        /// <summary>
        ///     Id đơn vị tính
        /// </summary>
        [JsonProperty(PropertyName = "idUnit")]
        public string UnitId { get; set; }

        /// <summary>
        ///     Id bản ghi detail
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Số tiền chiết khấu trước thuế
        /// </summary>
        [JsonProperty(PropertyName = "discountAmountBeforeTax")]
        public double DiscountAmountBeforeTax { get; set; }

        /// <summary>
        ///     Phần trăm chiết khấu trước thuế
        /// </summary>
        [JsonProperty(PropertyName = "discountPercentBeforeTax")]
        public double DiscountPercentBeforeTax { get; set; }

        /// <summary>
        ///     Thành tiền sau thuế
        /// </summary>
        [JsonProperty(PropertyName = "paymentAmount")]
        public double PaymentAmount { get; set; }

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
        ///     Thuế suất hiển thị
        /// </summary>
        [JsonProperty(PropertyName = "vatPercentDisplay")]
        public string VatPercentDisplay { get; set; }

        /// <summary>
        ///     Tiền thuế
        /// </summary>
        [JsonProperty(PropertyName = "vatAmount")]
        public double VatAmount { get; set; }

        /// <summary>
        ///     Ghi chú cho mặt hàng
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }

    public class InvoiceTaxBreakdown
    {
        /// <summary>
        ///     Tên loại thuế
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Tổng số tiền chịu thuế của 1 loại thuế
        /// </summary>
        [JsonProperty(PropertyName = "vatAmount")]
        public double VatPercent { get; set; }

        /// <summary>
        ///     Phần trăm thuế
        /// </summary>
        [JsonProperty(PropertyName = "vatPercent")]
        public double VatAmount { get; set; }
    }
}
