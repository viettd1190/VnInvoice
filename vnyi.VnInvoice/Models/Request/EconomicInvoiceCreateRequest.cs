using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class EconomicInvoiceCreateRequest
    {
        public EconomicInvoiceCreateRequest()
        {
            Id = Guid.NewGuid()
                     .ToString();
        }

        public EconomicInvoiceCreateRequest(EconomicInvoiceCreateModel model) : this()
        {
            if(!string.IsNullOrEmpty(model.Id))
            {
                Id = model.Id;
            }

            EconomicContractDate = model.EconomicContractDate.ConvertToString();
            EconocmicContractNumber = model.EconocmicContractNumber;
            DeliveryBy = model.DeliveryBy;
            ContractNumber = model.ContractNumber;
            FromWarehouseName = model.FromWarehouseName;
            ToWarehouseName = model.ToWarehouseName;
            TransactionMethod = model.TransactionMethod;
            TemplateNo = model.TemplateNo;
            SerialNo = model.SerialNo;
            InvoiceTypeCode = model.InvoiceTypeCode;
            Currency = model.Currency;
            ExchangeRate = model.ExchangeRate;
            TotalPaymentAmount = model.TotalPaymentAmount;
            BuyerAddressLine = model.BuyerAddressLine;
            BuyerFullName = model.BuyerFullName;
            BuyerLegalName = model.BuyerLegalName;
            BuyerTaxCode = model.BuyerTaxCode;
            Details = new List<EconomicInvoiceDetail>();
            if(model.Details != null)
            {
                Details.AddRange(model.Details.Select(c => new EconomicInvoiceDetail(c)));
                if (model.TotalPaymentAmount == 0)
                {
                    TotalPaymentAmount = model.Details.Sum(c => c.UnitPrice * c.Quantity);
                }
            }
            
        }

        /// <summary>
        ///     Id phiếu xuất
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Ngày hợp đồng giao hàng
        /// </summary>
        [JsonProperty(PropertyName = "economicContractDate")]
        public string EconomicContractDate { get; set; }

        /// <summary>
        ///     Hợp đồng giao hàng số
        /// </summary>
        [JsonProperty(PropertyName = "economicContractNumber")]
        public string EconocmicContractNumber { get; set; }

        /// <summary>
        ///     Họ tên người vận chuyển
        /// </summary>
        [JsonProperty(PropertyName = "deliveryBy")]
        public string DeliveryBy { get; set; }

        /// <summary>
        ///     Số hợp đồng vận chuyển
        /// </summary>
        [JsonProperty(PropertyName = "contractNumber")]
        public string ContractNumber { get; set; }

        /// <summary>
        ///     Kho xuất
        /// </summary>
        [JsonProperty(PropertyName = "fromWarehouseName")]
        public string FromWarehouseName { get; set; }

        /// <summary>
        ///     Kho nhập
        /// </summary>
        [JsonProperty(PropertyName = "toWarehouseName")]
        public string ToWarehouseName { get; set; }

        /// <summary>
        ///     Phương tiện vận chuyển
        /// </summary>
        [JsonProperty(PropertyName = "transportationMethod")]
        public string TransactionMethod { get; set; }

        /// <summary>
        ///     Mẫu số
        /// </summary>
        [JsonProperty(PropertyName = "templateNo")]
        public string TemplateNo { get; set; }

        /// <summary>
        ///     Ký hiệu
        /// </summary>
        [JsonProperty(PropertyName = "serialNo")]
        public string SerialNo { get; set; }

        /// <summary>
        ///     Loại hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "invoiceTypeCode")]
        public string InvoiceTypeCode { get; set; }

        /// <summary>
        ///     Tiền tệ
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        ///     Tỷ giá
        /// </summary>
        [JsonProperty(PropertyName = "exchangeRate")]
        public double ExchangeRate { get; set; }

        /// <summary>
        ///     Tổng tiền thanh toán
        /// </summary>
        [JsonProperty(PropertyName = "totalPaymentAmount")]
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Địa chỉ nhận hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerAddressLine")]
        public string BuyerAddressLine { get; set; }

        /// <summary>
        ///     Tên khách hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerFullName")]
        public string BuyerFullName { get; set; }

        /// <summary>
        ///     Tên đơn vị mua hàng
        /// </summary>
        [JsonProperty(PropertyName = "buyerLegalName")]
        public string BuyerLegalName { get; set; }

        /// <summary>
        ///     Mã số thuế người mua
        /// </summary>
        [JsonProperty(PropertyName = "buyerTaxCode")]
        public string BuyerTaxCode { get; set; }

        /// <summary>
        ///     Chi tiết đơn hàng
        /// </summary>
        [JsonProperty(PropertyName = "invoice04Details")]
        public List<EconomicInvoiceDetail> Details { get; set; }
    }

    public class EconomicInvoiceDetail
    {
        public EconomicInvoiceDetail()
        {
        }

        public EconomicInvoiceDetail(EconomicInvoiceDetailModel model) : this()
        {
            ProductId = model.ProductId;
            ProductNo = model.ProductNo;
            ProductName = model.ProductName;
            UnitId = model.UnitId;
            UnitName = model.UnitName;
            UnitPrice = model.UnitPrice;
            Quantity = model.Quantity;
            if(model.Amount > 0)
            {
                Amount = model.Amount;
            }
            else
            {
                Amount = model.UnitPrice * model.Quantity;
            }

            Note = model.Note;
        }

        /// <summary>
        ///     Id sản phẩm
        /// </summary>
        [JsonProperty(PropertyName = "idProduct")]
        public string ProductId { get; set; }

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
        ///     Mã đơn vị tính
        /// </summary>
        [JsonProperty(PropertyName = "idUnit")]
        public string UnitId { get; set; }

        /// <summary>
        ///     Tên đơn vị tính
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
        ///     Thành tiền
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }
}
