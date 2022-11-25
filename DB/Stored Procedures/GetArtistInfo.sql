Create PROCEDURE dbo.GetArtistInfo
	@ArtistId INT = NULL,
	@ArtistName VARCHAR(100) = Null
AS
BEGIN
	SELECT
		ArtistId = Artist.artistID,
		ArtistName = Artist.[title],
		ArtistBio = Artist.[biography],
		ArtistImageUrl = Artist.[imageURL],
		ArtistHeroImageUrl = Artist.[heroURL]
	FROM
		dbo.Artist
	WHERE
		(@ArtistId IS NULL OR artistID = @ArtistId)
	    And	(@ArtistName IS NULL OR dbo.Artist.title LIKE '%' + @ArtistName + '%')
END
