﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelin_Desktop.MyURL
{
    public static class MyURL
    {
        public static String baseURL = "http://localhost:8000/api/";
        public static String imageURL = "http://localhost:8000/storage/";
        public static String roomListURL = "room/list";
        public static String deleteRoomURL = "room/delete/";
        public static String detailBookingURL = "booking/show/";
        public static String detailRoomURL = "room/detail/";
        public static String profileHotelURL = "hotel/profile";
        public static String updateHotelURL = "hotel/update";
        public static String addHotelURL = "hotel/create";
        public static String detailHotelURL = "hotel/detail/";
        public static String detailRoomURL = "room/detail/";
        public static String updateRoomURL = "room/update/";
        public static String loginURL = "user/login";
        public static String canceledBookingURL = "booking/list/3";
        public static String doneBookingURL = "booking/list/2";
        public static String onGoingBookingURL = "booking/list/1";
        public static String registerOwneURL = "user/register";
        public static String addRoomURL = "room/create";


    }
}
