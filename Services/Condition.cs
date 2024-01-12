using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace uHub_API.Services
{
    [Keyless]
    public class Condition{
        public static string NewItem { get {return "New";} }
        public static string  LikeNew { get {return "Like New";} }
        public static string  Good { get {return "Good";} }
        public static string  Fair { get {return "Fair";} }
        public static string  Refurbished { get {return "Refurbished";} }
    }
}