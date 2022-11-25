using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Artists_Songs_details : System.Web.UI.Page
{
    public SQL Sql { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        var artistId = Request.Params["ArtistId"];
        GetArtistInfo(artistId);
    }

    private void GetArtistInfo(string artistId)
    {
        var data = this.newSQL(artistId, "GetArtistInfo");

        if (data.Rows.Count > 0)
        {
            setHref(data.Rows[0]["ArtistId"].ToString());
            var artist = data.Rows[0]["ArtistName"].ToString();
            artistName.Text = artist;
            artistImage.ImageUrl = data.Rows[0]["ArtistImageUrl"].ToString();
            artistHeroImage.ImageUrl = data.Rows[0]["ArtistHeroImageUrl"].ToString();
            PageTitle.InnerText = $"{artist} | Songs | MultiTracks";
            GetArtistSongs(data.Rows[0]["ArtistId"].ToString());

        }
        else
        {
            Response.Redirect("../../default.aspx");
        }
    }

    private void GetArtistSongs(string artistId)
    {
        var songsDb = this.newSQL(artistId, "GetSongs");
        songs.DataSource = songsDb;
        songs.DataBind();
    }

    private DataTable newSQL(string artistId, string spName)
    {
        this.Sql = new SQL();
        this.Sql.Parameters.Add("@ArtistId", artistId);
        return this.Sql.ExecuteStoredProcedureDT(spName);
    }

    private void setHref(string artistId)
    {
        overviewPage.HRef = "../../artistDetails.aspx?ArtistId=" + artistId;
        songsPage.HRef = "./details.aspx?ArtistId=" + artistId;
        albumsPage.HRef = "../albums/details.aspx?ArtistId=" + artistId;
    }
}