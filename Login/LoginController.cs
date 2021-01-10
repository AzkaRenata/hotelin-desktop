using Hotelin_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velacro.Api;
using Velacro.Basic;

namespace Hotelin_Desktop.Login
{
    class LoginController : MyController
    {
        public LoginController(IMyView _myView) : base(_myView)
        {

        }
        public async void validateToken(string token)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();
            var req = request
                .buildHttpRequest()
                .setEndpoint("test")
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setTokenStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setTokenStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("setTokenStatus", _response.getParsedObject<SuccessMessage>());
            }
        }

        private bool validateLoginInput(string _email, string _password)
        {
            if (_email.Length == 0) return false;
            if (_password.Length == 0) return false;
            return true;
        }

        public async void login(string _email, string _password)
        {
            if (validateLoginInput(_email, _password))
            {
                var client = new ApiClient(MyURL.MyURL.baseURL);
                var request = new ApiRequestBuilder();

                var req = request
                    .buildHttpRequest()
                    .addParameters("email", _email)
                    .addParameters("password", _password)
                    .setEndpoint("user/login")
                    .setRequestMethod(HttpMethod.Post);
                client.setOnSuccessRequest(setViewLoginStatus);
                client.setOnFailedRequest(onFailedRequest);
                var response = await client.sendRequest(request.getApiRequestBundle());
                // Console.WriteLine("token : " + response.getJObject()["token"]);
                //client.setAuthorizationToken(response.getJObject()["access_token"].ToString());
            }
            else
            {
                MessageBox.Show("One of the required field is empty. Please try again.", "Login Failed");
                // Console.WriteLine("One of the required field is empty. Please try again.");
            }
        }

        private void onFailedRequest(HttpResponseBundle _response)
        {
            MessageBox.Show("Email-Password combination doesn't match. Please try again.", "Login Failed");
            //Console.WriteLine("Email-Password combination doesn't match. Please try again");
        }

        private void setViewLoginStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                int statusCode = (int)_response.getHttpResponseMessage().StatusCode;

                Console.WriteLine(_response.getHttpResponseMessage());
                string token = _response.getJObject()["token"].ToString();
                getView().callMethod("saveToken", token);
                //getView().callMethod("tesPrint");
                //getView().callMethod("moveToDashboard");
            }
        }
    }
}