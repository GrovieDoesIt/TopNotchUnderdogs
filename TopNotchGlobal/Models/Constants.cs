using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopNotchGlobal.Models
{
    public static class Constants//we do not want to be hard coding anything in our project so instead we will be using these magic constants to keep certaing things the same throughout the project without having to code the certain limits constraints etc everytime
    {
       
        public const int PremiumUser = 4;
        public const string PremiumUserRoleName = "PremiumUser,Administrator";

        public const int AdministratorRole = 2;
        public const string AdministratorRoleName = "Administrator";
        public const int NonVerifiedUser = 8;
        public const string NonVerifiedUserRoleName = "NonVerifiedUser,PremiumUser,Administrator";

        public const int DefaultDefaultPageSize = 3;
        public const int MinUserNameLength = 6;
        public const int MaxUserNameLength = 18;
        public const int DefaultPageNumber = 1;
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 20;
        public const int SaltSize = 24;
        public const string PasswordRequirementsMessage = "The Password must contain at Least One Capital letter, One Lowercase letter and One Number";
        public const string PasswordRequirements = @"^((?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()+=:;.,\-])).+$";
    }
}