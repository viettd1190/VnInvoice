﻿using System;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class InternalDeliveryUpdateModel : InternalDeliveryCreateModel
    {
        /// <summary>
        ///     Id phiếu xuất kho cần thay thế
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        ///     Số biên bản
        /// </summary>
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày lập biên bản
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        ///     Lý do thay thế
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        ///     Tên file biên bản
        /// </summary>
        public string FileNameOfRecord { get; set; }

        /// <summary>
        ///     Nội dung biên bản
        /// </summary>
        public string FileOfRecord { get; set; }
    }
}
