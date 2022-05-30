using System.Collections.Generic;

namespace CDOrganizer.Models
{
    public class Record
    {
        private static List<Record> _records = new List<Record>{};
        public string Song{get; set;}
        public int Id{get;}
         public Record(string song)
         {
             Song = song;
             _records.Add(this);
             Id = _records.Count;
         }

         public static List<Record> GetAllRecords()
         {
             return _records;
         }

         public static void ClearAllRecords()
         {
             _records.Clear();
         }

         public static Record GetRecord(int recordId)
         {
             return _records[recordId - 1];
         }
    }
}