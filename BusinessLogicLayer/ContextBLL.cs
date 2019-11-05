using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class ContextBLL : IDisposable
    {
        ContextDAL context = new ContextDAL();
        public ContextBLL()
        {
            context.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        #region RoleBLL
        public List<RoleBLL> RoleGetAll(int skip, int take)
        {
            List<RoleBLL> ExpectedReturnValue = new List<RoleBLL>();
            List<RoleDAL> infos = context.RolesGetAll(skip, take);

            foreach (RoleDAL info in infos )
            {
                RoleBLL correctedInfo = new RoleBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        public RoleBLL RoleFindByID(int RoleID)
        {
            RoleBLL ExpectedReturnValue = null;
            RoleDAL info = context.RoleFindByID(RoleID);
            if (info != null)
            {
                ExpectedReturnValue = new RoleBLL(info);
            }
            return ExpectedReturnValue;
        }
         public int RoleCreate(string RoleName)
        {
            int ExpectedReturnValue = 0;
             ExpectedReturnValue = context.RoleCreate(RoleName);
            return ExpectedReturnValue;
        }

        public void RoleDelete(int RoleID)
        {
            context.RoleDelete(RoleID);
        }
        public void RoleUpdateJust(int RoleID, string RoleName)
        {
            context.RoleUpdateJust(RoleID, RoleName);
        }
        public void RoleUpdateSafe( int RoleID, string OldRoleName, string NewRoleName)
        {
            context.RoleUpdateSafe(RoleID, OldRoleName, NewRoleName);
        }
        public int RolesObtainCount()
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.RolesObtainCount();
            return ExpectedReturnValue;
        }
        #endregion RoleBLL


        #region UserBLL
        public List<UserBLL> UsersGetAll(int skip, int take)
        {
            List< UserBLL> ExpectedReturnValue = new List<UserBLL>();
            List<UserDAL> infos = context.UsersGetAll(skip, take);
            foreach (UserDAL info in infos)
            {
                UserBLL correctedInfo = new UserBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        public UserBLL UserFindByID(int UserID)
        {
            UserBLL ExpectedReturnValue = null;
            UserDAL info = context.UserFindByID(UserID);
            if (info != null)
            {
                ExpectedReturnValue = new UserBLL(info);
            }
            return ExpectedReturnValue;
        }
        public UserBLL UserFindByEmail(string Email)
        {
            UserBLL ExpectedReturnValue = null;
            UserDAL info = context.UserFindByEmail(Email);
            if (info != null)
            {
                ExpectedReturnValue = new UserBLL(info);
            }
            return ExpectedReturnValue;
        }

        public int UserCreate(string Email,string Hash, string Salt, int RoleID )
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.UserCreate(Email, Hash, Salt, RoleID);
            return ExpectedReturnValue;
        }
        public void UserDelete(int UserID)
        {
            context.UserDelete(UserID);
        }
        public void UserUpdateJust(int UserID, string Email, string Hash, string Salt, int RoleID)
        {
            context.UserUpdateJust(UserID, Email, Hash, Salt, RoleID);
        }
        public int UsersObtainCount()
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.UsersObtainCount();
            return ExpectedReturnValue;
        }
        public List<UserBLL> UsersGetRelatedToRoleID(int RoleID, int skip, int take)
        {
            List<UserBLL> ExpectedReturnValue = new List<UserBLL>();
            List<UserDAL> infos = context.UsersGetRelatedToRoleID(RoleID, skip, take);
            foreach(UserDAL info in infos)
            {
                UserBLL correctedInfo = new UserBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        public UserBLL UserRoleFindByEmail(string Email)
        {
            UserBLL ExpectedReturnValue = null;
            UserDAL user  = context.UserRoleFindByEmail(Email);//if null statement required
            ExpectedReturnValue = new UserBLL(user);
            return ExpectedReturnValue;
            

        }



        #endregion UserBLL


        #region RatingsBLL
        public void RatingCreate(int MixtapeID,int UserID, decimal RatingScore)
        {
            
            context.RatingCreate(MixtapeID,UserID, RatingScore);
            
        }

        public void RatingDelete(int MixtapeID, int UserID)
        {
            context.RatingDelete(MixtapeID, UserID);
        }

        public List<MixtapeBLL> RatingsGetAllMixtapeRatingsByUserID(int skip, int take, int UserID)
        {
            List<MixtapeBLL> ExpectedReturnValue = new List<MixtapeBLL>();
            List<MixtapeDAL> infos = context.RatingsGetAllMixtapeRatingsByUserID(skip, take, UserID);
            foreach(MixtapeDAL info in infos)
            {
                MixtapeBLL correctedInfo = new MixtapeBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        public List<UserBLL> RatingsGetAllUsersRatingsByMixtapeID(int skip, int take, int MixtapeID)
        {
            List<UserBLL> ExpectedReturnValue = new List<UserBLL>();
            List<UserDAL> infos = context.RatingsGetAllUsersRatingsByMixtapeID(skip, take, MixtapeID);
            foreach(UserDAL info in infos)
            {
                UserBLL correctedInfo = new UserBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }


        #endregion


        #region GenreBLL
        public List<GenreBLL> GenresGetAll(int skip, int take)
        {

            List<GenreBLL> ExpectedReturnValue = new List<GenreBLL>();
            List<GenreDAL> infos = context.GenresGetAll(skip, take);
            foreach (GenreDAL info in infos)
            {
                GenreBLL correctedInfo = new GenreBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        public void GenreDelete(int GenreID)
        {
            context.GenreDelete(GenreID);
        }
        public void GenreUpdateJust(int GenreID, string GenreName)
        {
            context.GenreUpdateJust(GenreID, GenreName);
        }
        public int GenreCreate(string GenreName)
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.GenreCreate(GenreName);
            return ExpectedReturnValue;
        }
        public GenreBLL GenreFindByID(int GenreID)
        {
            GenreBLL ExpectedReturnValue = null;
            GenreDAL info = context.GenreFindByID(GenreID);
            if (info != null)
            {
                ExpectedReturnValue = new GenreBLL(info);
            }
            return ExpectedReturnValue;
        }

        public int GenresObtainCount()
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.GenresObtainCount();
            return ExpectedReturnValue;
        }

        #endregion


        #region MixtapeBLL
        public int MixtapeCreate(string MixtapePath,string ArtistName, string Title, int NumberOfSongs, int Length)
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.MixtapeCreate(MixtapePath,ArtistName, Title, NumberOfSongs, Length);
            return ExpectedReturnValue;
        }
        public void MixtapeDelete(int MixtapeID)
        {
            context.MixtapeDelete(MixtapeID);
        }
        public MixtapeBLL MixtapeFindByID(int MixtapeID)
        {
            MixtapeBLL ExpectedReturnValue = null;
            MixtapeDAL info = context.MixtapeFindByID(MixtapeID);
            if (info != null)
            {
                ExpectedReturnValue = new MixtapeBLL(info);
            }
            return ExpectedReturnValue;
        }

        public List<MixtapeBLL> MixtapesGetAll(int skip, int take)
        {
            List<MixtapeBLL> ExpectedReturnValue = new List<MixtapeBLL>();
            List<MixtapeDAL> infos = context.MixtapesGetAll(skip, take);
            foreach (MixtapeDAL info in infos)
            {
                MixtapeBLL correctedInfo = new MixtapeBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }

        public int MixtapesObtainCount()
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.MixtapesObtainCount();
            return ExpectedReturnValue;
        }
        public void MixtapeUpdateJust(int MixtapeID, string MixtapePath, string ArtistName, string Title, int NumberOfSongs, int Length)
        {
            context.MixtapeUpdateJust(MixtapeID, MixtapePath, ArtistName, Title, NumberOfSongs, Length);
        }
        #endregion


        #region ListeningsBLL
        public int ListeningCreate(int MixtapeID, int UserID)
        {
            int ExpectedReturnValue = 0;
            ExpectedReturnValue = context.ListeningCreate(MixtapeID, UserID);
                return ExpectedReturnValue;
        }

        public void ListeningDelete(int ListeningID, int MixtapeID, int UserID)
        {
            context.ListeningDelete(ListeningID, MixtapeID,UserID);
        }
        
        public List<MixtapeBLL> ListeningsGetAllMixtapeListeningsByUserID(int skip, int take, int UserID)
        {
            List<MixtapeBLL> ExpectedReturnValue = new List<MixtapeBLL>();
            List<MixtapeDAL> infos = context.ListeningsGetAllMixtapeListeningsByUserID(skip, take, UserID);
            foreach (MixtapeDAL info in infos)
            {
                MixtapeBLL correctedInfo = new MixtapeBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        public List<UserBLL> ListeningsGetAllUserListeningsByMixtapeID(int skip, int take, int MixtapeID)
        {
            List<UserBLL> ExpectedReturnValue = new List<UserBLL>();
            List<UserDAL> infos = context.ListeningsGetAllUserListeningsByMixtapeID(skip, take, MixtapeID);
            foreach(UserDAL info in infos)
            {
                UserBLL correctedInfo = new UserBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        #endregion


        #region MixtapeGenresBLL
        public void MixtapeGenresDelete( int MixtapeID, int GenreID)
        {
            context.MixtapeGenresDelete(MixtapeID, GenreID);
        }
        
        public void MixtapeGenresCreate(int MixtapeID, int GenreID)
        {
            context.MixtapeGenresCreate(MixtapeID, GenreID);
        }
        
        public List<MixtapeBLL> MixtapeGenresGetAllMixtapesByGenreID(int skip, int take, int GenreID)
        {
            List<MixtapeBLL> ExpectedReturnValue = new List<MixtapeBLL>();
            List<MixtapeDAL> infos = context.MixtapeGenresGetAllMixtapesByGenreID(skip, take, GenreID);
            foreach(MixtapeDAL info in infos)
            {
                MixtapeBLL correctedInfo = new MixtapeBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }
        
        public List<GenreBLL> MixtapeGenresGetAllGenresByMixtapeID(int skip, int take, int MixtapeID)
        {
            List<GenreBLL> ExpectedReturnValue = new List<GenreBLL>();
            List<GenreDAL> infos = context.MixtapeGenresGetAllGenresByMixtapeID(skip, take, MixtapeID);
            foreach(GenreDAL info in infos)
            {
                GenreBLL correctedInfo = new GenreBLL(info);
                ExpectedReturnValue.Add(correctedInfo);
            }
            return ExpectedReturnValue;
        }

        #endregion

       


    }






}
