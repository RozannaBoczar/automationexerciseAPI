using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace automationexerciseAPI.HelpersRest
{
    public interface IRestSharpClientApi
    {
        Task<RestResponse> GetAsync(string endpoint, object body = null); 
        Task<RestResponse> PostAsync(string endpoint, object body = null); 
        Task<RestResponse> PutAsync(string endpoint, object body = null);
        Task<RestResponse> DeleteAsync(string endpoint, object body = null);
    }
}
