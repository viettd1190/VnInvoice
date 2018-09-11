using System;
using System.Collections.Generic;
using System.Linq;
using vnyi.VnInvoice.Enums;
using vnyi.VnInvoice.Models;
using vnyi.VnInvoice.Models.DataModel;
using vnyi.VnInvoice.Models.Request;
using vnyi.VnInvoice.Models.Response;

namespace vnyi.VnInvoice
{
    public class VnInvoice
    {
        private string GetToken(Authentication authentication)
        {
            var callApi = true;
            if(AppUtil.UserTokens.ContainsKey(authentication.Username))
            {
                if(AppUtil.UserTokens[authentication.Username]
                          .ExpiredOn > DateTime.Now)
                {
                    callApi = false;
                }
            }

            if(callApi)
            {
                try
                {
                    string apiLink = $"{authentication.DomainName}/login";

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            authentication.ToJson(),
                                                            string.Empty);
                    var response = rawResponse.ToObject<BaseResponse<LoginResponse>>();
                    if(response?.Data != null)
                    {
                        if(response.Succeeded)
                        {
                            if(AppUtil.UserTokens.ContainsKey(authentication.Username))
                            {
                                AppUtil.UserTokens[authentication.Username]
                                       .Password = authentication.Password;
                                AppUtil.UserTokens[authentication.Username]
                                       .ExpiredOn = response.Data.ExpiredOn;
                                AppUtil.UserTokens[authentication.Username]
                                       .Token = response.Data.Token;
                                AppUtil.UserTokens[authentication.Username]
                                       .ValidFor = response.Data.ValidFor;
                            }
                            else
                            {
                                AppUtil.UserTokens.Add(authentication.Username,
                                                       new UserToken
                                                       {
                                                               Username = authentication.Username,
                                                               Password = authentication.Password,
                                                               DomainName = authentication.DomainName,
                                                               Token = response.Data.Token,
                                                               ExpiredOn = response.Data.ExpiredOn,
                                                               ValidFor = response.Data.ValidFor
                                                       });
                            }

                            return AppUtil.UserTokens[authentication.Username]
                                          .Token;
                        }
                    }
                }
                catch (Exception exception)
                {
                    return string.Empty;
                }
            }
            else
            {
                return AppUtil.UserTokens[authentication.Username]
                              .Token;
            }

            return string.Empty;
        }

        /// <summary>
        ///     Tạo mới hóa đơn.
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult Create(Authentication authentication,
                                    InvoiceCreateModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/create-batch";

                    InvoiceCreateRequest request = new InvoiceCreateRequest(model);

                    List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>();
                    if(model.Details != null)
                    {
                        invoiceDetails.AddRange(model.Details.Select(c => new InvoiceDetail(c)));
                    }

                    request.Details = invoiceDetails;

                    List<InvoiceTaxBreakdown> taxBreakdowns = new List<InvoiceTaxBreakdown>();
                    if(model.InvoiceTaxBreakdowns != null)
                    {
                        taxBreakdowns.AddRange(model.InvoiceTaxBreakdowns.Select(c => new InvoiceTaxBreakdown(c)));
                    }

                    request.InvoiceTaxBreakdowns = taxBreakdowns;

                    request.TotalAmount = request.Details.Sum(c => c.Amount);
                    request.TotalVatAmount = request.Details.Sum(c => c.VatAmount);
                    request.TotalDiscountAmountBeforeTax = request.Details.Sum(c => c.DiscountAmountBeforeTax);

                    if(request.TotalDiscountAmountAfterTax == 0)
                    {
                        if(request.TotalDiscountPercentAfterTax > 0)
                        {
                            request.TotalDiscountAmountAfterTax = request.TotalAmount * request.TotalDiscountPercentAfterTax / 100;
                        }
                    }

                    request.TotalPaymentAmount = request.TotalAmount + request.TotalVatAmount - request.TotalDiscountAmountAfterTax;

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceCreateResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Sửa hóa đơn hiện có trên hệ thống.
        ///     Nếu hóa đơn được sửa chưa ký thì bản ghi mới sẽ update đè lên bản ghi đã có.
        ///     Nếu hóa đơn được sửa đã ký thì hóa đơn này sẽ được đưa về trạng thái hủy bỏ và tạo hóa đơn mới với thông tin đưa
        ///     vào
        ///     Nếu hóa đơn được sửa đã báo cáo kê khai, thông tin sau khi sửa sẽ tạo thành 2 hóa đơn mới: 1 hóa đơn điều chỉnh
        ///     giảm toàn bộ hóa đơn sửa và 1 hóa đơn điều chỉnh tăng theo thông tin mới
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult Update(Authentication authentication,
                                    InvoiceUpdateModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/update/{model.Id}";

                    InvoiceCreateRequest request = new InvoiceCreateRequest(model);

                    List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>();
                    if(model.Details != null)
                    {
                        invoiceDetails.AddRange(model.Details.Select(c => new InvoiceDetail(c)));
                    }

                    request.Details = invoiceDetails;

                    List<InvoiceTaxBreakdown> taxBreakdowns = new List<InvoiceTaxBreakdown>();
                    if(model.InvoiceTaxBreakdowns != null)
                    {
                        taxBreakdowns.AddRange(model.InvoiceTaxBreakdowns.Select(c => new InvoiceTaxBreakdown(c)));
                    }

                    request.InvoiceTaxBreakdowns = taxBreakdowns;

                    request.TotalAmount = request.Details.Sum(c => c.Amount);
                    request.TotalVatAmount = request.Details.Sum(c => c.VatAmount);
                    request.TotalDiscountAmountBeforeTax = request.Details.Sum(c => c.DiscountAmountBeforeTax);

                    if(request.TotalDiscountAmountAfterTax == 0)
                    {
                        if(request.TotalDiscountPercentAfterTax > 0)
                        {
                            request.TotalDiscountAmountAfterTax = request.TotalAmount * request.TotalDiscountPercentAfterTax / 100;
                        }
                    }

                    request.TotalPaymentAmount = request.TotalAmount + request.TotalVatAmount - request.TotalDiscountAmountAfterTax;

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token,
                                                            MethodType.PUT);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceCreateResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Xóa 1 hóa đơn đã ký.
        ///     Nếu hóa đơn chưa báo cáo, hệ thống đưa hóa đơn về trạng thái Hủy bỏ
        ///     Nếu hóa đơn đã keek hai, báo cáo, hệ thống sẽ tạo hóa đơn điều chỉnh giảm cho hóa đơn này
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult Delete(Authentication authentication,
                                    InvoiceDeleteModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/delete/{model.Id}";

                    InvoiceDeleteRequest request = new InvoiceDeleteRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceDeleteResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Xóa 1 hóa đơn chưa ký
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult Cancel(Authentication authentication,
                                    InvoiceCancelModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/cancel/{model.Id}";

                    InvoiceCancelRequest request = new InvoiceCancelRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceCancelResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Sửa 1 hóa đơn có sẵn trên hệ thống
        ///     Nếu hóa đơn được sửa chưa ký thì các bản ghi mới sẽ update đè lên bản ghi đã có, trạng thái hóa đơn không thay đổi.
        ///     Nếu hóa đơn được sửa đã ký thì hóa đơn này sẽ được đưa về trạng thái hủy bỏ và thông tin sau khi sửa sẽ tạo thành
        ///     hóa đơn mới.
        ///     Nếu hóa đơn được sửa đã báo cáo, kê khai thì thông tin sau khi sửa sẽ tạo thành 2 hóa đơn mới. 1 hóa đơn điều chỉnh
        ///     giảm toàn bộ hóa đơn sửa và 1 hóa đơn điều chỉnh tăng theo thông tin mới
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult Replace(Authentication authentication,
                                     InvoiceReplaceModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/replace/{model.Id}";

                    InvoiceReplaceRequest request = new InvoiceReplaceRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceReplaceResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Duyệt và ký 1 hóa đơn
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult ApproveAndSign(Authentication authentication,
                                            InvoiceApproveAndSignModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/approve-and-sign";

                    string strRequest = $"id={model.Id}";

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            strRequest,
                                                            token,
                                                            MethodType.POST,
                                                            "application/x-www-form-urlencoded");
                    var response = rawResponse.ToObject<BaseResponse<InvoiceApproveAndSignResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Điều chỉnh định danh cho hóa đơn
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult AdjusementHeader(Authentication authentication,
                                              InvoiceAdjusementHeaderModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/adjusement-header";

                    InvoiceAdjusementHeaderRequest request = new InvoiceAdjusementHeaderRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token,
                                                            MethodType.PUT);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceAdjusementHeaderResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Điều chỉnh tăng hoặc giảm cho hóa đơn
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult Adjustment(Authentication authentication,
                                        InvoiceAdjustmentModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/adjustment-detail/{model.Id}";

                    InvoiceAdjustmentRequest request = new InvoiceAdjustmentRequest(model);

                    List<InvoiceAdjustmentDetail> invoiceDetails = new List<InvoiceAdjustmentDetail>();
                    if(model.Details != null)
                    {
                        invoiceDetails.AddRange(model.Details.Select(c => new InvoiceAdjustmentDetail(c)));
                    }

                    request.Details = invoiceDetails;

                    List<InvoiceAdjustmentTaxBreakdown> taxBreakdowns = new List<InvoiceAdjustmentTaxBreakdown>();
                    if(model.TaxBreakdowns != null)
                    {
                        taxBreakdowns.AddRange(model.TaxBreakdowns.Select(c => new InvoiceAdjustmentTaxBreakdown(c)));
                    }

                    request.TaxBreakdowns = taxBreakdowns;

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceAdjustmentResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Tạo phiếu xuất kho kiêm vận chuyển nội bộ
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult DeliveryCreate(Authentication authentication,
                                            InternalDeliveryCreateModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/interval-delivery/create";

                    InternalDeliveryCreateRequest request = new InternalDeliveryCreateRequest(model);

                    List<InternalDeliveryDetail> invoiceDetails = new List<InternalDeliveryDetail>();
                    if(model.Details != null)
                    {
                        invoiceDetails.AddRange(model.Details.Select(c => new InternalDeliveryDetail(c)));
                    }

                    request.Details = invoiceDetails;

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InternalDeliveryCreateResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Cập nhật 1 hóa đơn chưa ký hoặc thay thế 1 hóa đơn đã ký trên hệ thống
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult DeliveryUpdate(Authentication authentication,
                                            InternalDeliveryUpdateModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/interval-delivery/update/{model.ReferenceId}";

                    InternalDeliveryUpdateRequest request = new InternalDeliveryUpdateRequest(model);

                    List<InternalDeliveryDetail> invoiceDetails = new List<InternalDeliveryDetail>();
                    if(model.Details != null)
                    {
                        invoiceDetails.AddRange(model.Details.Select(c => new InternalDeliveryDetail(c)));
                    }

                    request.Details = invoiceDetails;

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token,
                                                            MethodType.PUT);
                    var response = rawResponse.ToObject<BaseResponse<InternalDeliveryUpdateResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Xóa hủy với hóa đơn chưa ký và xóa bỏ với hóa đơn đã ký
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult DeliveryDelete(Authentication authentication,
                                            InternalDeliveryDeleteModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/interval-delivery/delete/{model.Id}";

                    InternalDeliveryDeleteRequest request = new InternalDeliveryDeleteRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InternalDeliveryDeleteResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Ký một hóa đơn có trên hệ thống
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult DeliverySign(Authentication authentication,
                                          InternalDeliverySignModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/interval-delivery/sign/{model.Id}";

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            string.Empty,
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InternalDeliverySignResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Tạo phiếu xuất hàng gửi đại lý
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult EconomicCreate(Authentication authentication,
                                            EconomicInvoiceCreateModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoice04-api/creates";

                    EconomicInvoiceCreateRequest request = new EconomicInvoiceCreateRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<EconomicInvoiceCreateResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Cập nhật hoặc thay thế 1 phiếu xuất hàng gửi đại lý
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult EconomicUpdate(Authentication authentication,
                                            EconomicInvoiceUpdateModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoice04-api/update/{model.ReferenceId}";

                    EconomicInvoiceUpdateRequest request = new EconomicInvoiceUpdateRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token,
                                                            MethodType.PUT);
                    var response = rawResponse.ToObject<BaseResponse<EconomicInvoiceUpdateResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Xóa bỏ hoặc xóa hủy 1 phiếu xuất có trên hệ thống dựa vào trạng thái của phiếu đó
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult EconomicDelete(Authentication authentication,
                                            EconomicInvoiceDeleteModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoice04-api/delete/{model.Id}";

                    EconomicInvoiceDeleteRequest request = new EconomicInvoiceDeleteRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<EconomicInvoiceDeleteResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception)
            {
                result.ErrorApi();
            }

            return result;
        }

        /// <summary>
        ///     Ký phiếu xuất kho trên hệ thống
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageResult EconomicSign(Authentication authentication,
                                          EconomicInvoiceSignModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if(!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoice04-api/sign/{model.Id}";

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            string.Empty,
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<EconomicInvoiceSignResponse>>();
                    if(response != null)
                    {
                        result.Code = response.Code;
                        result.Succeeded = response.Succeeded;
                        result.Data = response.Data;
                    }
                }
                else
                {
                    result.CannotLogin();
                }
            }
            catch (Exception exception)
            {
                result.ErrorApi();
            }

            return result;
        }
    }
}
