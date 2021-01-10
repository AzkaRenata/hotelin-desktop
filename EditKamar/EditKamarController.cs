using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using Hotelin_Desktop.Model;
using Newtonsoft.Json;
using System.IO;

namespace Hotelin_Desktop.EditKamar
{
    public class EditKamarController : MyController
    {
        private RoomResponse currentRoom;
        private string bearerToken = File.ReadAllText(@"userToken.txt"); // BEARER TOKEN GOES HERE
        int id;

        public EditKamarController(IMyView _myView, int _roomID) : base(_myView)
        {
            this.id = _roomID;
            getCurrentRoomDetail(_roomID);
        }

        public async void getCurrentRoomDetail(int _roomID)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint("room/detail/" + _roomID)
                .setRequestMethod(HttpMethod.Get);
            Console.WriteLine("tes2");
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine("tes1");
            //var hotelData = response.getParsedObject<HotelList>().hotels;

            string anotherResponse = await response.getHttpResponseMessage().Content.ReadAsStringAsync();

            Console.WriteLine(anotherResponse);

            //currentRoom = JsonConvert.DeserializeObject<RoomResponse>(anotherResponse).room;
            currentRoom = response.getParsedObject<RoomResponse>();

            // Console.WriteLine(currentRoom.room_type);

            getView().callMethod("setCurrentRoomValue", currentRoom);

            // Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            // Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            // Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
        }

        public async void updateKamar(RoomModel room, byte[] fileByte, string fullFileName)
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
                .setEndpoint("room/update/" + id)
                .setRequestMethod(HttpMethod.Post);
            Console.WriteLine("tes2");
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        /*
        private Boolean hasUserEdited(
            string _roomType,
            string _bedType,
            long _roomPrice,
            int _guestCapacity
            )
        {
            if (String.Compare(_roomType, currentRoom.room_type) != 0) return true;
            if (String.Compare(_bedType, currentRoom.bed_type) != 0) return true;
            if (_roomPrice - currentRoom.room_price != 0) return true;
            if (_guestCapacity - currentRoom.guest_capacity != 0) return true;

            return false;
        }
        */
        private void setViewAddHotelStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                //getView().callMethod("setRegisterStatus", status);
            }
        }
    }
}
