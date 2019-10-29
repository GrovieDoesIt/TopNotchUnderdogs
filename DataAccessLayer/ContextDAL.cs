using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Logger_;

namespace DataAccessLayer
{
    public class ContextDAL : IDisposable
    {
        SqlConnection conn = new SqlConnection();
        public void Dispose()
        {
            conn.Dispose();
        }
        void EnsureConnected()
        {
            switch (conn.State)
            {
                case (System.Data.ConnectionState.Closed):
                    conn.Open();//making sure that regardless of the state we open the connection
                    break;
                case (System.Data.ConnectionState.Broken):
                    conn.Close();
                    conn.Open();
                    break;
                case (System.Data.ConnectionState.Open):
                    // dont need to do anything since it is already open
                    break;


            }
        }
        public string ConnectionString
        {
            get
            {
                return conn.ConnectionString;
            }
            set
            {
                conn.ConnectionString = value;
            }
        }
        bool Log(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Logger.Log(ex);
            return false;
        }
        #region RoleProcedures
        public RoleDAL RoleFindByID(int RoleID)
        {
            RoleDAL ExpectedReturnValue = null;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RoleFindByID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper RM = new RoleMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ExpectedReturnValue = RM.ToRole(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple Roles found for ID {RoleID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                
            }
            return ExpectedReturnValue;
        }
        public List<RoleDAL> RolesGetAll(int skip, int take)
        {
            List<RoleDAL> ExpectedReturnValue = new List<RoleDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RolesGetAll", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper RM = new RoleMapper(reader);

                        while (reader.Read())
                        {
                            RoleDAL info = RM.ToRole(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                
            }
            return ExpectedReturnValue;
        }
        public int RolesObtainCount()
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RolesObtainCount", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    ExpectedReturnValue = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public int RoleCreate(string RoleName)
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RoleCreate", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", RoleName);
                    command.Parameters.AddWithValue("@RoleID", 0);
                    command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ExpectedReturnValue = (int)command.Parameters["@RoleID"].Value;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        public void RoleDelete(int RoleID)
        {    try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RoleDelete", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public void RoleUpdateJust(int RoleID, string RoleName)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RoleUpdateJust", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", RoleName);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        //This method was created just incase if for any reason in the future i need this feature however I don't think it will be needed.
        //referring to this update safe procedure since I don't believe 2 people will be editing a particular record at the same time.
        public int RoleUpdateSafe(int RoleID, string OldRoleName, string NewRoleName)
        {
            
            




                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RoleUpdateSafe", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@OldRoleName", OldRoleName);
                    command.Parameters.AddWithValue("NewRoleName", NewRoleName);
                    return command.ExecuteNonQuery();
                }
            
            




        }

        #endregion RoleProcedures
        #region UsersProcedures

        public UserDAL UserFindByID(int UserID)
        {
            UserDAL ExpectedReturnValue = null;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserFindByID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper um = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ExpectedReturnValue = um.ToUser(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple users found for ID{UserID}");
                        }

                    }

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        public List<UserDAL> UsersGetAll(int skip, int take)
        {
            List<UserDAL> ExpectedReturnValue = new List<UserDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersGetAll", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper um = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL info = um.ToUser(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        public int UsersObtainCount()
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersObtainCount", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    ExpectedReturnValue = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        public int UserCreate(string Email,string Hash, string Salt, int RoleID)
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserCreate", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", 0);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Hash", Hash);
                    command.Parameters.AddWithValue("@Salt", Salt);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ExpectedReturnValue = (int)command.Parameters["@UserID"].Value;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        public void UserDelete(int UserId)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserDelete", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public void UserUpdateJust(int UserID, string Email, string Hash, string Salt, int RoleID)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserUpdateJust", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Hash", Hash);
                    command.Parameters.AddWithValue("@Salt", Salt);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public List<UserDAL> UsersGetRelatedToRoleID(int RoleID,int skip, int take)
        {
            List<UserDAL> ExpectedReturnValue = new List<UserDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersGetRelatedToRoleID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper um = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL info = um.ToUser(reader);
                            ExpectedReturnValue.Add(info);
                        }


                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
            
        }
        public UserDAL UserRoleFindByEmail(string Email)
        {
            UserDAL ExpectedReturnValue = null;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserRoleFindByEmail", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", Email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper um = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL info = um.ToUser(reader);
                            ExpectedReturnValue = info;
                        }

                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        public UserDAL UserFindByEmail(string Email)
        {
            UserDAL ExpectedReturnValue = null;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserFindByEmail", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper um = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ExpectedReturnValue = um.ToUser(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple emails found for email{Email}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
            
        }





        #endregion UserProcedures


        #region RatingProcedures
        public int RatingCreate(int UserID, decimal RatingScore)
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RatingCreate", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RatingID", 0);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@RatingScore", RatingScore);
                    command.Parameters["RatingID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ExpectedReturnValue = (int)command.Parameters["@RatingID"].Value;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
            
        }
        public void RatingDelete(int MixtapeID, int UserID)
        {  try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RatingDelete", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public List<RatingDAL>RatingsGetAllMixtapeRatingsByUserID (int skip, int take, int UserID)
        {
            List<RatingDAL> ExpectedReturnValue = new List<RatingDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RatingsGetAllMixtapeRatingsByUserID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RatingMapper rm = new RatingMapper(reader);
                        while (reader.Read())
                        {
                            RatingDAL info = rm.ToRate(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public List<RatingDAL> RatingsGetAllUsersRatingsByMixtapeID(int skip, int take, int MixtapeID)
        {
            List<RatingDAL> ExpectedReturnValue = new List<RatingDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RatingsGetAllUsersRatingsByMixtapeID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RatingMapper rm = new RatingMapper(reader);
                        while (reader.Read())
                        {
                            RatingDAL info = rm.ToRate(reader);
                            ExpectedReturnValue.Add(info);
                        }

                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }




        #endregion

        #region GenresProcedures
        public int GenreCreate(string GenreName)
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GenreCreate", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GenreID", 0);
                    command.Parameters.AddWithValue("@GenreName", GenreName);
                    command.Parameters["@GenreID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ExpectedReturnValue = (int)command.Parameters["@GenreID"].Value;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;

        }
        public List<GenreDAL> GenresGetAll(int skip, int take)
        {
            List<GenreDAL> ExpectedReturnValue = new List<GenreDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GenresGetAll", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        GenreMapper um = new GenreMapper(reader);
                        while (reader.Read())
                        {
                            GenreDAL info = um.ToGenre(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        public void GenreDelete(int GenreID)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GenreDelete", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GenreId", GenreID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }

        public GenreDAL GenreFindByID(int GenreID)
        {
            GenreDAL ExpectedReturnValue = null;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GenreFindByID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GenreID", GenreID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        GenreMapper um = new GenreMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ExpectedReturnValue = um.ToGenre(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple users found for ID{GenreID}");
                        }

                    }

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public int GenresObtainCount()
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GenresObtainCount", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    ExpectedReturnValue = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public void GenreUpdateJust(int GenreID, string GenreName)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GenreUpdateJust", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GenreID", GenreID);
                    command.Parameters.AddWithValue("@GenreName", GenreName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        #endregion
        #region MixtapeProcedures
        public int MixtapeCreate(string ArtistName, string Title, int NumberOfSongs, int Length)
        {
           int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeCreate", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MixtapeID", 0);
                    command.Parameters.AddWithValue("@ArtistName", ArtistName);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@NumberOfSongs", NumberOfSongs);
                    command.Parameters.AddWithValue("@Length", Length);
                    command.Parameters["@MixtapeID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ExpectedReturnValue = (int)command.Parameters["@MixtapeID"].Value;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public void MixtapeDelete(int MixtapeID)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeDelete", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public MixtapeDAL MixtapeFindByID(int MixtapeID)
        {
            MixtapeDAL ExpectedReturnValue = null;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeFindByID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        MixtapeMapper um = new MixtapeMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ExpectedReturnValue = um.ToMixtape(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple users found for ID{MixtapeID}");
                        }

                    }

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public List<MixtapeDAL> MixtapesGetAll(int skip, int take)
        {
            List<MixtapeDAL> ExpectedReturnValue = new List<MixtapeDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapesGetAll", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        MixtapeMapper um = new MixtapeMapper(reader);
                        while (reader.Read())
                        {
                            MixtapeDAL info = um.ToMixtape(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public int MixtapesObtainCount()
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapesObtainCount", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    ExpectedReturnValue = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public void MixtapeUpdateJust(int MixtapeID, string ArtistName, string Title, int NumberOfSongs, int Length)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeUpdateJust", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    command.Parameters.AddWithValue("@ArtistName", ArtistName);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@NumberOfSongs", NumberOfSongs);
                    command.Parameters.AddWithValue("@Length", Length);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        #endregion

        #region ListeningsProcedures
        public int ListeningCreate(int MixtapeID, int UserID)
        {
            int ExpectedReturnValue = 0;
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ListeningCreate", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    command.Parameters["@ListeningID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ExpectedReturnValue = (int)command.Parameters["@ListeningID"].Value;

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public void ListeningDelete(int ListeningID, int MixtapeID, int UserID)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ListeningID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ListeningID", ListeningID);
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }

        public List<ListeningsDAL> ListeningsGetAllMixtapeListeningsByUserID(int skip, int take, int UserID)
        {
            List<ListeningsDAL> ExpectedReturnValue = new List<ListeningsDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ListeningsGetAllMixtapeListeningsByUserID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ListeningMapper lm = new ListeningMapper(reader);
                        while (reader.Read())
                        {
                            ListeningsDAL info = lm.ToListening(reader);
                            ExpectedReturnValue.Add(info);
                        }

                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public List<ListeningsDAL> ListeningsGetAllUserListeningsByMixtapeID(int skip, int take, int MixtapeID)
        {
            List<ListeningsDAL> ExpectedReturnValue = new List<ListeningsDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ListeningsGetAllUserListeningsByMixtapeID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ListeningMapper lm = new ListeningMapper(reader);
                        while (reader.Read())
                        {
                            ListeningsDAL info = lm.ToListening(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }
        #endregion


        public void MixtapeGenresCreate (int MixtapeID, int GenreID)
        { try
            {



                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeGenresCreate", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    command.Parameters.AddWithValue("@GenreID", GenreID);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }

        public void MixtapeGenresDelete( int MixtapeID, int GenreID)
        { try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeGenresDelte", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    command.Parameters.AddWithValue("@GenreID", GenreID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public List<MixtapeDAL> MixtapeGenresGetAllMixtapesByGenreID(int skip, int take, int GenreID)
        {
            List<MixtapeDAL> ExpectedReturnValue = new List<MixtapeDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeGenresGetAllMixtapesByGenreID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@GenreID", GenreID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        MixtapeMapper mm = new MixtapeMapper(reader);
                        while (reader.Read())
                        {
                            MixtapeDAL info = mm.ToMixtape(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }

        public List<GenreDAL> MixtapeGenresGetAllGenresByMixtapeID(int skip, int take, int MixtapeID)
        {
            List<GenreDAL> ExpectedReturnValue = new List<GenreDAL>();
            try
            {


                EnsureConnected();
                using (SqlCommand command = new SqlCommand("MixtapeGenresGetAllGenresByMixtapeID", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@MixtapeID", MixtapeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        GenreMapper gm = new GenreMapper(reader);
                        while (reader.Read())
                        {
                            GenreDAL info = gm.ToGenre(reader);
                            ExpectedReturnValue.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ExpectedReturnValue;
        }


    }





}
