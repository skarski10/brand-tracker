using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
    public class Venue
    {
        private int _id;
        private string _name;

        public Venue(string name, int id = 0)
        {
            _id = id;
            _name = name;
        }

        public static List<Venue> GetAllVenues()
        {
            List<Venue> allVenues = new List<Venue>{};
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                int venueId = rdr.GetInt32(0);
                string venueName = rdr.GetName(1);
                Venue newVenue = new Venue(venueName, venueId);
                allVenues.Add(newVenue);
            }

            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
            return allVenues;
        }







        public int GetVenueId()
        {
            return _id;
        }
        public string GetVenueName()
        {
            return _name;
        }

        public override bool Equals(System.Object otherVenue)
        {
            if (!(otherVenue is Venue))
            {
                return false;
            }
            else
            {
                Venue newVenue = (Venue) otherVenue;
                bool nameEquality = this.GetVenueName()  == newVenue.GetVenueName();
                return false;
            }
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
