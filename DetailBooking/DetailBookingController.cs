using Hotelin_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace Hotelin_Desktop.DetailBooking
{
    class DetailBookingController :MyController
    {
        public DetailBookingController(IMyView _myView) : base(_myView)
        {

        }

        public async void requestBookingDetail(string token, int id)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint(MyURL.MyURL.detailBookingURL + id)
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());

            Booking booking = response.getParsedObject<Booking>();

            getView().callMethod("setBookingDetail", booking);
        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;

            }
        }
    }
}
