using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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

        public MessageResult Replace(Authentication authentication,
                                     InvoiceReplaceModel model)
        {
            MessageResult result=new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if (!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/replace/{model.Id}";

                    InvoiceReplaceRequest request = new InvoiceReplaceRequest(model);

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            request.ToJson(),
                                                            token);
                    var response = rawResponse.ToObject<BaseResponse<InvoiceReplaceResponse>>();
                    if (response != null)
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

        public MessageResult ApproveAndSign(Authentication authentication,
                                            InvoiceApproveAndSignModel model)
        {
            MessageResult result=new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if (!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/approve-and-sign";

                    string strRequest = $"id={model.Id}";

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            strRequest,
                                                            token,
                                                            MethodType.POST,
                                                            "application/x-www-form-urlencoded");
                    var response = rawResponse.ToObject<BaseResponse<InvoiceApproveAndSignResponse>>();
                    if (response != null)
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

        public MessageResult AdjustmentHeader(Authentication authentication,
                                              InvoiceAdjustmentHeaderModel model)
        {
            MessageResult result=new MessageResult();
            try
            {
                var token = GetToken(authentication);

                if (!string.IsNullOrEmpty(token))
                {
                    string apiLink = $"{authentication.DomainName}/api/invoices/adjustment-header";

                    string strRequest = $"id={model.Id}";

                    var rawResponse = AppUtil.CreateRequest(apiLink,
                                                            strRequest,
                                                            token,
                                                            MethodType.POST,
                                                            "application/x-www-form-urlencoded");
                    var response = rawResponse.ToObject<BaseResponse<InvoiceApproveAndSignResponse>>();
                    if (response != null)
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
