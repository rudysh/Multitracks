CREATE PROCEDURE dbo.GetSongs
	@ArtistId INT = null,
	@AlbumId INT = null,
	@SongName VARCHAR(100) = Null
AS
BEGIN

	SELECT
		SongTitle = Song.[title],
		Bpm = Song.[bpm],
		TimeSignature = Song.[timeSignature],
		MultiTracks = Song.[multitracks],
		CustomMix = Song.[customMix],
		ChordChart = Song.[chart],
		RehearsalMix = Song.[rehearsalMix],
		Patches = Song.[patches],
		SongSpecificPatches = Song.[songSpecificPatches],
		ProPresenter = Song.[proPresenter],
		AlbumImageUrl = Album.[imageURL],
		AlbumId = Album.[albumId],
		AlbumTitle = Album.[title],
		ArtisTId = Artist.[artistId],
		ArtistTitle = Artist.title,
		Artist.heroURL
	FROM
		dbo.Song
		INNER JOIN dbo.Album ON Song.albumID = Album.albumID
		INNER JOIN dbo.Artist ON Song.artistID = Artist.artistID
	WHERE
		(@ArtistId IS NULL OR Song.artistID = @ArtistId)
	    And	(@AlbumId IS NULL OR Song.albumID = @ArtistId)
		And	(@SongName IS NULL OR Song.title = @SongName)
END

