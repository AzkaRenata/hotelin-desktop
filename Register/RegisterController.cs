using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            if (validateInput(_password, _passwordConfirmation) == 1)
            {

                var req = request
                    .buildHttpRequest()
                    .addHeaders("Accept", "application/json")
                    .addParameters("username", _username)
                    .addParameters("name", _name)
                    .addParameters("email", _email)
                    .addParameters("password", _password)
                    .addParameters("password_confirmation", _passwordConfirmation)
                    .setEndpoint(MyURL.MyURL.registerOwneURL)
                    .setRequestMethod(HttpMethod.Post);
                client.setOnSuccessRequest(setViewRegisterStatus);
                var response = await client.sendRequest(request.getApiRequestBundle());
            }
            else if (validateInput(_password, _passwordConfirmation) == 112)
            {
                MessageBox.Show("password and password confirmation must be same. Please try again.", "Try Again");
            }
            else 
            {
                MessageBox.Show("Password must be 8 digit or more. Please try again.", "Try Again");
            }
            
        }


        private int validateInput(string _password, string _passwordConfirmation)
        {
            if (_password.Length < 8) return 113;
            if (_passwordConfirmation.Length < 8) return 114;
            if (!_passwordConfirmation.Equals(_password)) return 112;
            return 1;
        }

        private void setViewRegisterStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string token = _response.getJObject()["token"].ToString();
                getView().callMethod("saveToken", token);
            }
        }


    }
}
