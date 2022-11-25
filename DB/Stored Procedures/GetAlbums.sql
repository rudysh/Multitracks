CREATE PROCEDURE dbo.GetAlbums
	@ArtistId INT = null,
	@AlbumId INT = null,
	@AlbumName VARCHAR(100) = Null
AS
BEGIN

	SELECT
		AlbumId = Album.[albumID],
		AlbumDateCreated = Album.[dateCreation],
		AlbumTitle = Album.[title],
        AlbumImageUrl = Album.[imageURL],
		AlbumYear = Album.[year],
		ArtistName = Artist.[title],
		ArtistId = Artist.[artistID],
		Artist.heroURL
	FROM
		dbo.Artist
		INNER JOIN dbo.Album ON Artist.artistID = Album.artistID
	WHERE
	     (@AlbumId IS NULL OR Album.albumID = @ArtistId)
   		And (@ArtistId IS NULL OR Album.artistID = @ArtistId)
		And	(@AlbumName IS NULL OR Album.title = @AlbumName)
	order by Album.[year] desc
END

