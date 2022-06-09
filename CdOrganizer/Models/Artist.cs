using System.Collections.Generic;

namespace CDOrganizer.Models
{
    public class Artist
    {
        public string Name{get; set;}
        public List<Record> Records{get; set;}
        public int Id{get;}
        private static List<Artist> _artists = new List<Artist>{};

        public Artist(string name)
        {
            Name = name;
            _artists.Add(this);
            Id = _artists.Count;
            Records = new List<Record>{};
        }

        public static List<Artist> GetAllArtists()
        {
            return _artists;
        }

        public static void ClearAllArtists()
        {
            _artists.Clear();
        }

        public static Artist GetArtist(int artistId)
        {
            return _artists[artistId - 1];
        }

        public void AddRecord(Record record)
        {
            Records.Add(record);
        }

        public int GetRecordsAmount()
        {
            return Records.Count;
        }

        public static List<Artist> Search(string artist)
        {
            List<Artist> artists = new List<Artist>{};
            foreach(Artist artist1 in _artists)
            {
                if(artist1.Name.ToLower().Contains(artist.ToLower()))
                {
                    artists.Add(artist1);
                }
            }
            return artists;
        }
    }
}