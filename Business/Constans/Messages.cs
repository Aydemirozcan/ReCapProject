using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public  class Messages
    {
        public static string CarAdded = "New Car Added ";
        public static string CarDeleted = " The Car Deleted";
        public static string CarUpdated = "The Car Updated";
        public static string CarDescriptionInvalid = "Car Description Invalid";
        public static string BrandAdded = "New Brand Added";
        public static string BrandDeleted = "The Brand Deleted";
        public static string BrandUpdated = "The Car Updated";
        public static string ColorAdded = "New Color Added";
        public static string ColorDeleted = "The Color Deleted";
        public static string ColorUpdated = "The Color Updated";
        public static string MaintenanceTime = "Now is Maintenance Time";
        public static string CarsListed = "Cars Listed";
        public static string NewCustomerAdded = "New Customer Added";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerUpdated = "Customer Updated";
        public static string TheCarRented = "The Car Rented";
        public static string TheRentalDataDeleted = "The Rental Data Deleted";
        public static string TheCarUpdated = " The Car Updated";
        public static string NewUserAdded = " New User Added";
        public static string TheUserDeleted = "The User Deleted";
        public static string TheUserUpdated = " The User Updated";
        public static string RentalAddedError = "Rental didn't Add";
        public static string RentalAdded = "Rental Added";
        public static string CarDidntReturn = "Car Didn't Return";
        public static string CarReturned = "Car Returned";
        public static string ImageAded="The Image Added";
        public static string ImageDeleted="The Image Deleted";
        public static string ImagesListed="Images Listed";
        public static string ImageUpdated="The Image Updated";
        public static string ImageLimitExceded= "One Car Must Have A maximum Of Five Photos";
        public static string TheFileTypeInvalid="The File Type İs Invalid";
        internal static string ImageDidntAdd="Image Didn't Add";
        internal static string ImageNotFound    ="Image NotFound";
        internal static string ImageDidntUpload="Image Didn't Upload";
        internal static string AuthorizationDenied= "You have't Authorization";
        internal static string UserRegistered="User Registered";
        internal static string UserNotFound="User Not Found";
        internal static string PasswordError="Password Error";
        internal static string SuccessfulLogin="Successful Login";
        internal static string UserAlreadyExists="User Already Exists";
        internal static string AccessTokenCreated="Access Token Created";
    }
}
