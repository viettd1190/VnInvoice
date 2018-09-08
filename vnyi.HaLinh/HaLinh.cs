using System;
using vnyi.HaLinh.Models;

namespace vnyi.HaLinh
{
    public class HaLinh
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

        public MessageResult Login(LoginRequest request)
        {
            MessageResult result = new MessageResult();

            try
            {
                string apiLink = $"{request.DomainName}/login";

                var rawResponse = AppUtil.CreateRequest(apiLink,
                                                        request.ToJson(),
                                                        string.Empty);
                var response = rawResponse.ToObject<BaseResponse<LoginResponse>>();
                if(response != null)
                {
                    result.Code = response.Code;
                    result.Succeeded = response.Succeeded;
                    result.Data = response.Data;
                }
            }
            catch (Exception exception)
            {
                //
            }

            return result;
        }
    }
}
