using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace Hotelin_Desktop.Login
{
    class LoginController : MyController
    {
        public LoginController(IMyView _myView) : base(_myView)
        {

        }

        public async void login(string _email, string _password)
        {
            var client = new ApiClient("http://192.168.1.2:8000/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addParameters("email", _email)
                .addParameters("password", _password)
                .setEndpoint("api/user/login")
                .setRequestMethod(HttpMethod.Post);
            client.setOnSuccessRequest(setViewLoginStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine("token : " + response.getJObject()["token"]);
            //client.setAuthorizationToken(response.getJObject()["access_token"].ToString());
        }

        private void setViewLoginStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                string token = _response.getJObject()["token"].ToString();
                getView().callMethod("saveToken", token);
                //getView().callMethod("tesPrint");
                //getView().callMethod("moveToDashboard");
            }
        }
    }
}
