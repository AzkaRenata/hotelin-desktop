using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            string _password)
        {
            string API = "http://192.168.1.2:8000/";
            string endPoint = "api/user/register";
            var client = new ApiClient(API);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .addParameters("username", "ajezz")
                .addParameters("name", "ajezzK")
                .addParameters("email", "ajezz@gmail.com")
                .addParameters("password", "ajez123")
                .addParameters("password_confirmation", "ajez123")
                .setEndpoint(endPoint)
                .setRequestMethod(HttpMethod.Post);
            Console.WriteLine("tes2");
            client.setOnSuccessRequest(setViewRegisterStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine("tes1");
            //Console.WriteLine(response.getJObject()["user"]);
            Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);

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
