using Hotelin_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace Hotelin_Desktop.Detail
{
    class RoomListController : MyController
    {
        public RoomListController(IMyView _myView) : base(_myView)
        {

        }

        public async void requestRoomList(string token)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint(MyURL.MyURL.roomListURL)
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());

        }

        public async void deleteRoom(string token, int id)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint(MyURL.MyURL.deleteRoomURL + id)
                .setRequestMethod(HttpMethod.Delete);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(redirectToRoomList);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }


        private void redirectToRoomList(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;

                getView().callMethod("getRoomList");
            }
        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;

                getView().callMethod("setRoomList", _response.getParsedObject<List<Room>>());
            }
        }
    }
}
