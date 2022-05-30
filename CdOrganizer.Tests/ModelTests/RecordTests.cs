using CDOrganizer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CDOrganizer.Tests
{
    [TestClass]
    public class RecordClass : IDisposable
    {
        public void Dispose()
        {
            Record.ClearAllRecords();
        }
        [TestMethod]
        public void RecordClass_CreatesAnInstanceOfRecordClass_Record()
        {
            // Arrange
            Record newRecord = new Record("big boys");

            // Assert
            Assert.AreEqual(typeof(Record) , newRecord.GetType());
        }

        [TestMethod]
        public void GetSong_ReturnsTheNameOfRecord_String()
        {
            // Arrange
            string song = "City Guys";
            Record record = new Record(song);

            // Act
            string songGotten = record.Song;

            // Assert
            Assert.AreEqual(song , songGotten);
        }

        [TestMethod]
        public void SetSong_SetsANewNameOfSong_String()
        {
            // Arrange
            string song = "City Guys";
            Record record = new Record(song);

            // Act
            string newSong = "bigGuys";
            record.Song = newSong;
            string songGotten = record.Song;

            // Assert
            Assert.AreEqual(newSong , songGotten);
        }

        [TestMethod]
        public void GetAllRecords_ReturnsAListOfAllRecords_RecordList()
        {
            // Arrange
            Record record1 = new Record("city guys");
            Record record2 = new Record("city boys");
            List<Record> recordsCreated = new List<Record>{record1 , record2};

            // Act
            List<Record> gottenRecords = Record.GetAllRecords();

            // Assert
            CollectionAssert.AreEqual(recordsCreated , gottenRecords);
        }

        [TestMethod]
        public void SetId_AssignsAnIdToARecord_int()
        {
            // Arrange
            Record record = new Record("city");

            // Act
            int recordId = record.Id;

            // Assert
            Assert.AreEqual(1 , recordId);
        }

        [TestMethod]
        public void GetRecord_ReturndTheRecordOfAGivenId_Record()
        {
            // Arrange
            Record record1 = new Record("cityBoys");
            Record record2 = new Record("allofu");

            // Act
            Record secondRecord = Record.GetRecord(2);

            // Assert
            Assert.AreEqual(record2 , secondRecord);
        }
    }
}