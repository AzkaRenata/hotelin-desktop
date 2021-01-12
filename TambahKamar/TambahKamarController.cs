using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using System.IO;
using Hotelin_Desktop.Model;

namespace Hotelin_Desktop.TambahKamar
{
    public class TambahKamarController : MyController
    {
        public TambahKamarController(IMyView _myView) : base(_myView) { }

        public async void addKamar(RoomModel room, byte[] fileByte, string fullFileName)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            string bearerToken = File.ReadAllText(@"userToken.txt");
            var multiPartContent = new MultipartFormDataContent();
            multiPartContent.Add(new StringContent(room.room_code), "room_code");
            multiPartContent.Add(new StringContent(room.room_type), "room_type");
            multiPartContent.Add(new StringContent(room.bed_type), "bed_type");
            multiPartContent.Add(new StringContent(Convert.ToString(room.bed_count)), "bed_count");
            multiPartContent.Add(new StringContent(Convert.ToString(room.room_price)), "room_price");
            multiPartContent.Add(new StringContent(Convert.ToString(room.guest_capacity)), "guest_capacity");
            if (fileByte != null)
                multiPartContent.Add(new StreamContent(new MemoryStream(fileByte)), "room_picture", fullFileName);
            var req = request
                .buildMultipartRequest(new MultiPartContent(multiPartContent))
                .setEndpoint(MyURL.MyURL.addRoomURL)
                .setRequestMethod(HttpMethod.Post);
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddRoomStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setViewAddRoomStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("redirectToRoomFacility", _response.getParsedObject<RoomModel>());
            }
        }
    }
}
