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

namespace Hotelin_Desktop.UpdateKamar
{
    public class UpdateKamarController : MyController
    {
        private RoomModel currentRoom;
        private string bearerToken = File.ReadAllText(@"userToken.txt");

        public UpdateKamarController(IMyView _myView, int _roomID) : base(_myView) 
        {
            getCurrentRoomDetail(_roomID);
        }

        public async void getCurrentRoomDetail(int _roomID)
        {
            
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint(MyURL.MyURL.detailRoomURL + _roomID)
                .setRequestMethod(HttpMethod.Get);
                client.setAuthorizationToken(bearerToken);
                client.setOnSuccessRequest(setViewAddHotelStatus);
                var response = await client.sendRequest(request.getApiRequestBundle());

            string anotherResponse = await response.getHttpResponseMessage().Content.ReadAsStringAsync();
            currentRoom = JsonConvert.DeserializeObject<RoomResponse>(anotherResponse).room;
            getView().callMethod("setCurrentRoomValue", currentRoom.room_type, currentRoom.bed_type, currentRoom.room_price, currentRoom.guest_capacity);            
        }

        public async void updateKamar(
            string _roomType,
            string _bedType,
            long _roomPrice,
            int _guestCapacity
            )
        {
            
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            if (hasUserEdited(_roomType, _bedType, _roomPrice, _guestCapacity) == true) // HANDLING IF USER DID CHANGE SOMETHING
            {
                var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .addParameters("hotel_id", Convert.ToString(currentRoom.hotel_id))
                .addParameters("room_type", _roomType)
                .addParameters("bed_type", _bedType)
                .addParameters("room_price", Convert.ToString(_roomPrice))
                .addParameters("guest_capacity", Convert.ToString(_guestCapacity))
                .setEndpoint(MyURL.MyURL.updateRoomURL+ currentRoom.id)
                .setRequestMethod(HttpMethod.Post);
                client.setAuthorizationToken(bearerToken);
                var response = await client.sendRequest(request.getApiRequestBundle());
            }
            else // HANDLING IF USER DIDN'T CHANGE ANYTHING
            {
            }
        }

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

        private void setViewAddHotelStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
            }
        }
    }
}
