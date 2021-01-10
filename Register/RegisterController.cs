using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Velacro.Api;
using Velacro.Basic;

namespace Hotelin_Desktop.Register
{
    public class RegisterController : MyController
    {
        public RegisterController(IMyView _myView) : base(_myView) { }

        public async void register(
            string _username,
            string _email,
            string _name,
            string _password,
            string _passwordConfirmation)
        {
            if (validateRegisterInput(_username, _name, _email, _password, _passwordConfirmation))
            {
                //string API = "http://192.168.1.2:8000/";
                //var client = new ApiClient(API);
                //var request = new ApiRequestBuilder();
                string endPoint = "api/user/register";
                var client = new ApiClient(MyURL.MyURL.baseURL);
                var request = new ApiRequestBuilder();

                var req = request
                    .buildHttpRequest()
                    .addHeaders("Accept", "application/json")
                    .addParameters("username", _username)
                    .addParameters("name", _name)
                    .addParameters("email", _email)
                    .addParameters("password", _password)
                    .addParameters("password_confirmation", _passwordConfirmation)
                    .setEndpoint(endPoint)
                    .setRequestMethod(HttpMethod.Post);
                Console.WriteLine("tes2");
                client.setOnSuccessRequest(setViewRegisterStatus);
                client.setOnFailedRequest(onFailedRequest);
                var response = await client.sendRequest(request.getApiRequestBundle());
            }
            else
            {
                MessageBox.Show("One of the required field is empty. Please try again.", "Login Failed");
                // Console.WriteLine("One of the required field is empty. Please try again.");
            }
        }

        private bool validateRegisterInput(string _email, string _password, string _username, string _name, string _passwordConfirmation)
        {
            if (_username.Length == 0) return false;
            if (_name.Length == 0) return false;
            if (_email.Length == 0) return false;
            if (_password.Length == 0) return false;
            if (_passwordConfirmation.Length == 0) return false;
            return true;
        }

        private void onFailedRequest(HttpResponseBundle _response)
        {
            MessageBox.Show("Login Failed");
            //MessageBox.Show("Email-Password combination doesn't match. Please try again.", "Login Failed");
            //Console.WriteLine("Email-Password combination doesn't match. Please try again");
        }

        private void setViewRegisterStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("setRegisterStatus", status);
            }
        }


    }
}
