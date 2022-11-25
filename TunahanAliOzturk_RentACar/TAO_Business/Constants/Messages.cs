using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TAO_Core.Entities.Concrete;

namespace TAO_Business.Constants
{
  public static class Messages
  {
    /* Car Messages */
    public static string CarAdded = "Car added.";
    public static string CarUpdated = "Car updated.";
    public static string CarDeleted = "Car deleted.";
    public static string CarNameInvalid = "Car name invalid.";
    public static string CarsListed = "Cars listed.";


    /* Color Messages */
    public static string ColorAdded = "Color added.";
    public static string ColorUpdated = "Color updated.";
    public static string ColorDeleted = "Color deleted.";
    public static string ColorNameInvalid = "Color name invalid.";


    /* Brand Messages */
    public static string BrandAdded = "Brand added.";
    public static string BrandUpdated = "Brand updated";
    public static string BrandDeleted = "Brand deleted.";
    public static string BrandNameInvalid = "Brand name invalid.";




    public static string MaintenceTime = "Maintence Time";
    public static string RentalAdded;
    internal static string NotAvailableCarForRental;
    internal static string RentalDeleted;
    internal static string UserAdded;
    internal static string UserDeleted;
    internal static string UserUpdated;
    internal static string CarNumberExceeded;
    internal static string EmailAldreadyExists;
    internal static string ColorAldreadyExists;

    public static string RetroactiveActionIsNotPossible="Retroactive Action Is Not Possible";
    internal static string BrandNameAlreadyExists;
    internal static string RentalLimitExceded;
    internal static string AuthorizationDenied;
    internal static string UserRegistered;
    internal static User UserNotFound;
    internal static User PasswordError;
    internal static string SuccessfulLogin;
    internal static string AccessTokenCreated;
    internal static string UserAlreadyExists;
  }
}
