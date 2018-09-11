using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class InternalDeliveryCreateRequest
    {
        public InternalDeliveryCreateRequest()
        {
            Id = Guid.NewGuid()
                     .ToString();
        }

        public InternalDeliveryCreateRequest(InternalDeliveryCreateModel model) : this()
        {
            if(!string.IsNullOrEmpty(model.Id))
            {
                Id = model.Id;
            }

            Username = model.Username;
            InvoiceDate = model.InvoiceDate.ConvertToString();
            TemplateNo = model.TemplateNo;
            SerialNo = model.SerialNo;
            InvoiceTypeCode = model.InvoiceTypeCode;
            TotalPaymentAmount = model.TotalPaymentAmount;
            DeliveryOrderNumber = model.DeliveryOrderNumber;
            DeliveryOrderDate = model.DeliveryOrderDate.ConvertToString();
            Note = model.Note;
            DeliveryBy = model.DeliveryBy;
            ContractNumber = model.ContractNumber;
            if(model.ContractDate != null)
            {
                ContractDate = model.ContractDate.Value.ConvertToString();
            }

            TransportationMethod = model.TransportationMethod;
            PlaceOfReceipt = model.PlaceOfReceipt;
            FromWarehouseName = model.FromWarehouseName;
            ToWarehouseName = model.ToWarehouseName;
            CointanerNumber = model.CointanerNumber;
            Details = new List<InternalDeliveryDetail>();
        }

        /// <summary>
        ///     Cá nhân/đơn vị điều động
        /// </summary>
        [JsonProperty(PropertyName = "deliveryOrderBy")]
        public string Username { get; set; }

        /// <summary>
        ///     Id phiếu xuất kho
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Ngày tạo phiếu xuất kho
        /// </summary>
        [JsonProperty(PropertyName = "invoiceDate")]
        public string InvoiceDate { get; set; }

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
        ///     Tổng thành tiền
        /// </summary>
        [JsonProperty(PropertyName = "totalPaymentAmount")]
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Lệnh điều động số
        /// </summary>
        [JsonProperty(PropertyName = "deliveryOrderNumber")]
        public string DeliveryOrderNumber { get; set; }

        /// <summary>
        ///     Ngày điều động
        /// </summary>
        [JsonProperty(PropertyName = "deliveryOrderDate")]
        public string DeliveryOrderDate { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        /// <summary>
        ///     Tên người vận chuyển
        /// </summary>
        [JsonProperty(PropertyName = "deliveryBy")]
        public string DeliveryBy { get; set; }

        /// <summary>
        ///     Hợp đồng vận chuyển số
        /// </summary>
        [JsonProperty(PropertyName = "contractNumber")]
        public string ContractNumber { get; set; }

        /// <summary>
        ///     Ngày hợp đồng
        /// </summary>
        [JsonProperty(PropertyName = "contractDate")]
        public string ContractDate { get; set; }

        /// <summary>
        ///     Phương tiện vận chuyển
        /// </summary>
        [JsonProperty(PropertyName = "transportationMethod")]
        public string TransportationMethod { get; set; }

        /// <summary>
        ///     Địa điểm nhận hàng
        /// </summary>
        [JsonProperty(PropertyName = "placeOfReceipt")]
        public string PlaceOfReceipt { get; set; }

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
        ///     Số container
        /// </summary>
        [JsonProperty(PropertyName = "idcontainerNumber")]
        public string CointanerNumber { get; set; }

        /// <summary>
        ///     Chi tiết
        /// </summary>
        [JsonProperty(PropertyName = "internalDeliveryDetails")]
        public List<InternalDeliveryDetail> Details { get; set; }
    }

    public class InternalDeliveryDetail
    {
        public InternalDeliveryDetail()
        {
            Id = Guid.NewGuid()
                     .ToString();
        }

        public InternalDeliveryDetail(InternalDeliveryCreateRequest request)
        {
            InternalDeliveryId = request.Id;
        }

        public InternalDeliveryDetail(InternalDeliveryDetailModel model) : this()
        {
            ProductId = model.ProductId;
            ProductNo = model.ProductNo;
            ProductName = model.ProductName;
            UnitId = model.UnitId;
            UnitName = model.UnitName;
            UnitPrice = model.UnitPrice;
            QuantityActualExport = model.QuantityActualExport;
            QuantityActualImported = model.QuantityActualImported;
            Amount = model.Amount;
            Note = model.Note;
        }

        public InternalDeliveryDetail(InternalDeliveryDetailModel model,
                                      InternalDeliveryCreateRequest request) : this(model)
        {
            InternalDeliveryId = request.Id;
        }

        /// <summary>
        ///     Id bản ghi
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Id phiếu xuất kho
        /// </summary>
        [JsonProperty(PropertyName = "idInternalDelivery")]
        public string InternalDeliveryId { get; set; }

        /// <summary>
        ///     Id bản ghi sản phẩm
        /// </summary>
        [JsonProperty(PropertyName = "idProduct")]
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
        ///     Số lượng thực xuất
        /// </summary>
        [JsonProperty(PropertyName = "quantityActualExport")]
        public double QuantityActualExport { get; set; }

        /// <summary>
        ///     Số lượng thực nhập
        /// </summary>
        [JsonProperty(PropertyName = "quantityActualImported")]
        public double? QuantityActualImported { get; set; }

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
