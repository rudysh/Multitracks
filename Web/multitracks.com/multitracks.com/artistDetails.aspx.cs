using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artistDetails : System.Web.UI.Page
{
    public SQL Sql { get; set; }
    public DataTable ArtistSong { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var artistId = Request.Params["ArtistId"];
        GetArtistInfo(artistId);
    }

    private void GetArtistInfo(string artistId)
    {
        var data = this.newSQL(artistId,"GetArtistInfo");

        if (data.Rows.Count > 0)
        {
            setHref(data.Rows[0]["ArtistId"].ToString());
            var artist = data.Rows[0]["ArtistName"].ToString();
            artistName.Text = artist;
            artistBio.Text = data.Rows[0]["ArtistBio"].ToString();
            artistImage.ImageUrl = data.Rows[0]["ArtistImageUrl"].ToString();
            artistHeroImage.ImageUrl = data.Rows[0]["ArtistHeroImageUrl"].ToString();
            PageTitle.InnerText = $"{artist} | MultiTracks";
            GetArtistSongs(data.Rows[0]["ArtistId"].ToString());
            getArtistAlbums(data.Rows[0]["ArtistId"].ToString());
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }

    private void GetArtistSongs(string artistId)
    {
        this.ArtistSong = this.newSQL(artistId, "GetSongs");
        DataTable dt = this.ArtistSong.AsEnumerable().Take(5).CopyToDataTable();
        songs.DataSource = dt;
        songs.DataBind();
    }

    private DataTable newSQL(string artistId,string spName)
    {
        this.Sql = new SQL();
        this.Sql.Parameters.Add("@ArtistId", artistId);
        return this.Sql.ExecuteStoredProcedureDT(spName);
    }

    private void setHref(string artistId)
    {
        overviewPage.HRef = "../artistDetails.aspx?ArtistId=" + artistId;
        allSongs.HRef = "../artists/songs/details.aspx?ArtistId=" + artistId;
        songsPage.HRef = "../artists/songs/details.aspx?ArtistId=" + artistId;
        albumsPage.HRef = "../artists/albums/details.aspx?ArtistId=" + artistId;
        allAlbums.HRef = "../artists/albums/details.aspx?ArtistId=" + artistId;
    }

    private void getArtistAlbums(string artistId)
    {
        var artistAlbums = this.newSQL(artistId, "GetAlbums");
        DataTable dt = artistAlbums.AsEnumerable().Take(12).CopyToDataTable();
        albums.DataSource = dt;
        albums.DataBind();
    }
}