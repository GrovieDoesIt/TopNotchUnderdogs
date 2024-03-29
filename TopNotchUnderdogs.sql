USE [master]
GO
/****** Object:  Database [TopNotchUnderDogs]    Script Date: 10/14/2019 10:51:28 AM ******/
CREATE DATABASE [TopNotchUnderDogs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TopNotchUnderDogs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TopNotchUnderDogs.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TopNotchUnderDogs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TopNotchUnderDogs_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TopNotchUnderDogs] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TopNotchUnderDogs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TopNotchUnderDogs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET ARITHABORT OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TopNotchUnderDogs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TopNotchUnderDogs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TopNotchUnderDogs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TopNotchUnderDogs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TopNotchUnderDogs] SET  MULTI_USER 
GO
ALTER DATABASE [TopNotchUnderDogs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TopNotchUnderDogs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TopNotchUnderDogs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TopNotchUnderDogs] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TopNotchUnderDogs] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TopNotchUnderDogs] SET QUERY_STORE = OFF
GO
USE [TopNotchUnderDogs]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Listenings]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Listenings](
	[ListeningID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[mixtapeID] [int] NOT NULL,
 CONSTRAINT [PK_Listeners] PRIMARY KEY CLUSTERED 
(
	[ListeningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MixtapeGenres]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MixtapeGenres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[MixtapeID] [int] NOT NULL,
 CONSTRAINT [PK_MixtapeGenres] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC,
	[MixtapeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mixtapes]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mixtapes](
	[MixtapeID] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[NumberOfSongs] [int] NOT NULL,
	[Length] [int] NOT NULL,
 CONSTRAINT [PK_Mixtapes] PRIMARY KEY CLUSTERED 
(
	[MixtapeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[MixtapeID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[RatingScore] [decimal](2, 1) NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[MixtapeID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Hash] [nvarchar](200) NOT NULL,
	[Salt] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Listenings]  WITH CHECK ADD  CONSTRAINT [FK_Listeners_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Listenings] CHECK CONSTRAINT [FK_Listeners_Users]
GO
ALTER TABLE [dbo].[Listenings]  WITH CHECK ADD  CONSTRAINT [FK_Listenings_Mixtapes] FOREIGN KEY([mixtapeID])
REFERENCES [dbo].[Mixtapes] ([MixtapeID])
GO
ALTER TABLE [dbo].[Listenings] CHECK CONSTRAINT [FK_Listenings_Mixtapes]
GO
ALTER TABLE [dbo].[MixtapeGenres]  WITH CHECK ADD  CONSTRAINT [FK_MixtapeGenres_Genres] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[MixtapeGenres] CHECK CONSTRAINT [FK_MixtapeGenres_Genres]
GO
ALTER TABLE [dbo].[MixtapeGenres]  WITH CHECK ADD  CONSTRAINT [FK_MixtapeGenres_Mixtapes] FOREIGN KEY([MixtapeID])
REFERENCES [dbo].[Mixtapes] ([MixtapeID])
GO
ALTER TABLE [dbo].[MixtapeGenres] CHECK CONSTRAINT [FK_MixtapeGenres_Mixtapes]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Mixtapes] FOREIGN KEY([UserID])
REFERENCES [dbo].[Mixtapes] ([MixtapeID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Mixtapes]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[GenreCreate]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GenreCreate]
@GenreName nvarchar(100),
@GenreID int output
as 
begin
 insert into Genres(GenreName) values (@GenreName)
 select @GenreID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[GenreDelete]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GenreDelete]
@GenreID int
as
begin
delete from Genres
where GenreID = @GenreID
end
GO
/****** Object:  StoredProcedure [dbo].[GenreFindbyID]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GenreFindbyID]
@GenreId int
as
begin
select GenreID, GenreName from Genres
where GenreID = @GenreID
end
GO
/****** Object:  StoredProcedure [dbo].[GenresGetAll]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GenresGetAll]
@skip int,
@take int
as
begin
select GenreID, GenreName from Genres
Order by GenreID
 offset @skip rows
 fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[GenresObtainCount]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GenresObtainCount]
as
begin
select count(*) from Genres
end
GO
/****** Object:  StoredProcedure [dbo].[GenreUpdateJust]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GenreUpdateJust]
@GenreID int,
@GenreName nvarchar(100)
as
begin
Update genres set GenreName = @GenreName
where GenreID = @GenreID
end
GO
/****** Object:  StoredProcedure [dbo].[ListeningCreate]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListeningCreate]
@UserID int,
@MixtapeID int,
@ListeningID int output
as
begin
insert into Listenings(UserID, MixtapeID) values (@UserID, @MixtapeID)
select @ListeningID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[MixtapeCreate]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MixtapeCreate]
@ArtistName nvarchar(100),
@Title nvarchar(100),
@NumberOfSongs int,
@Length int,
@MixtapeID int output
as 
begin
 insert into Mixtapes (ArtistName, Title, NumberOfSongs,Length) values (@ArtistName, @Title, @NumberOfSongs,@Length)
 select @MixtapeID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[MixtapeDelete]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MixtapeDelete]
@mixtapeID int
as
begin
delete from Mixtapes
where MixtapeID = @MixtapeID
end
GO
/****** Object:  StoredProcedure [dbo].[MixtapeFindByID]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MixtapeFindByID]
@MixtapeID int
as
begin
Select MixtapeID, ArtistName, Title, NumberOfSongs,Length from Mixtapes
where MixtapeID = @MixtapeID
end
GO
/****** Object:  StoredProcedure [dbo].[MixtapesGetAll]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MixtapesGetAll]
@skip int,
@take int
as
begin
select MixtapeID, ArtistName, Title, NumberOfSongs, Length from Mixtapes
Order by MixtapeID
 offset @skip rows
 fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[MixtapesObtainCount]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MixtapesObtainCount]
as
begin
select count(*) from Mixtapes
end
GO
/****** Object:  StoredProcedure [dbo].[MixtapeUpdateJust]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MixtapeUpdateJust]
@MixtapeID int,
@ArtistName nvarchar(100),
@Title nvarchar (100),
@NumberOfSongs int,
@Length int
as
begin
Update Mixtapes set ArtistName = @ArtistName, Title = @Title, NumberOfSongs = @NumberOfSongs, Length = @Length
where MixtapeID = @MixtapeID
end
GO
/****** Object:  StoredProcedure [dbo].[RatingCreate]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RatingCreate]
@UserID int,
@ratingID int output,
@RatingScore decimal
as
begin
 insert into Ratings(UserID, RatingScore) values (@UserID, @RatingScore)
 select @RatingID = @@Identity
end
GO
/****** Object:  StoredProcedure [dbo].[RoleCreate]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleCreate]
@RoleName nvarchar(200),
@RoleID int output
as 
begin
 insert into roles(RoleName) values (@RoleName)
 select @RoleID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleDelete]
@RoleID int
as
begin
delete from Roles
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleFindbyID]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleFindbyID]
@RoleId int
as
begin
select RoleID, RoleName from Roles
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RolesGetAll]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RolesGetAll]
@skip int,
@take int
as
begin
select RoleID, RoleName from Roles
Order by RoleID
 offset @skip rows
 fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[RolesObtainCount]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RolesObtainCount]
as
begin
select count(*) from Roles
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateJust]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleUpdateJust]
@RoleID int,
@RoleName nvarchar(200)
as
begin
Update roles set RoleName = @RoleName
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateSafe]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleUpdateSafe]
@RoleID int,
@OldRoleName nvarchar(200),
@NewRoleName nvarchar(200)
as
begin
update roles set RoleName = @NewRoleName
where RoleID = @RoleID and
RoleName = @OldRoleName
end
GO
/****** Object:  StoredProcedure [dbo].[UserCreate]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserCreate]
@RoleID int,
@Email nvarchar(200),
@Hash nvarchar(200),
@Salt nvarchar(200),
@UserID int output
as 
begin
 insert into Users (Email, Hash, Salt, RoleID) values (@Email, @Hash, @Salt, @RoleID)
 select @UserID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserDelete]
@UserID int
as
begin
delete from Users
where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[UserFindByID]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserFindByID]
@UserID int
as
begin
Select UserID, Email, Hash, Salt, Users.RoleID, RoleName from users
inner join Roles on Users.RoleID = Roles.RoleID
where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[UserRoleFindbyEmail]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserRoleFindbyEmail]
@email nvarchar(200)
as
begin
select UserID, Email, Hash, Salt, Users.RoleID, RoleName from users
inner join Roles on Users.RoleID = Roles.RoleID
where email = @email
end
GO
/****** Object:  StoredProcedure [dbo].[UsersGetAll]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UsersGetAll]
@skip int,
@take int
as
begin
select UserID, Email, Hash, Salt, Users.RoleID, RoleName from users
inner join Roles on Users.RoleID = Roles.RoleID
Order by UserID
 offset @skip rows
 fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[UsersGetRelatedToRoleID]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UsersGetRelatedToRoleID]
@skip int,
@take int,
@RoleID int --We're searching for the related ROleID's not userID which is why if you place userID here you'll get errors in your syntax
AS
BEGIN
SET NOCOUNT ON;
SELECT UserID, Email, Hash, Salt, Users.RoleID, RoleName from users
inner join Roles on Users.RoleID = Roles.RoleID
WHere Roles.RoleID = @RoleID 
ORDER BY UserID OFFSET
@skip ROWS FETCH NEXT @take ROWS ONLY
END
GO
/****** Object:  StoredProcedure [dbo].[UsersObtainCount]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UsersObtainCount]
as
begin
select count(*) from Users
end
GO
/****** Object:  StoredProcedure [dbo].[UserUpdateJust]    Script Date: 10/14/2019 10:51:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserUpdateJust]
@RoleID int,
@Email nvarchar(200),
@UserID int,
@Hash nvarchar(200),
@Salt nvarchar(200)
as
begin
Update Users set Email = @Email, Hash = @hash, RoleID = @RoleID, Salt = @Salt
where UserID = @UserID
end
GO
USE [master]
GO
ALTER DATABASE [TopNotchUnderDogs] SET  READ_WRITE 
GO
