using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopNotchGlobal.Models
{
    public static class Constants
    {
        public const int Artist = 1;
        public const string ArtistRoleName = "Artist";

        public const int PremiumUser = 4;
        public const string PremiumUserRoleName = "PremiumUser";

        public const int AdministratorRole = 2;
        public const string AdministratorRoleName = "Administrator";
        public const int NonVerifiedUser = 8;
        public const string NonVerifiedUserRoleName = "NonVerifiedUser";

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