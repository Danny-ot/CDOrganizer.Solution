using CDOrganizer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CDOrganizer.Tests
{
    [TestClass]
    public class ArtistClass : IDisposable
    {
        public void Dispose()
        {
            Artist.ClearAllArtists();
        }
        [TestMethod]
        public void ArtistClass_CreatesAnInstanceOfArtist_Artist()
        {
            // Arrange
            Artist artist = new Artist("bign");

            // Assert
            Assert.AreEqual(typeof(Artist), artist.GetType());
        }

        [TestMethod]
        public void GetArtist_ReturnsTheArtistName_String()
        {
            // Arrange
            string name = "kendrick";
            Artist artist = new Artist(name);

            // Act
            string artistName = artist.Name;

            // Assert
            Assert.AreEqual(name, artistName);
        }

        [TestMethod]
        public void SetArtist_SetsANewNameOfArtist_String()
        {
            // Arrange
            string artist = "king";
            Artist artist1 = new Artist(artist);

            // Act
            string newArtist = "realTy";
            artist1.Name = newArtist;
            string ArtistGotten = artist1.Name;

            // Assert
            Assert.AreEqual(newArtist, ArtistGotten);
        }

        [TestMethod]
        public void GetAllArtists_ReturnsAListOfAllArtists_ArtistList()
        {
            // Arrange
            Artist artist1 = new Artist("city guys");
            Artist artist2 = new Artist("city boys");
            List<Artist> ArtistsCreated = new List<Artist> { artist1, artist2 };

            // Act
            List<Artist> gottenArtists = Artist.GetAllArtists();

            // Assert
            CollectionAssert.AreEqual(ArtistsCreated, gottenArtists);
        }

        [TestMethod]
        public void SetId_AssignsAnIdToAArtist_int()
        {
            // Arrange
            Artist artist = new Artist("city");

            // Act
            int artistId = artist.Id;

            // Assert
            Assert.AreEqual(1, artistId);
        }

        [TestMethod]
        public void GetArtist_ReturndTheArtistOfAGivenId_Artist()
        {
            // Arrange
            Artist artist1 = new Artist("cityBoys");
            Artist artist2 = new Artist("kennedy");

            // Act
            Artist secondArtist = Artist.GetArtist(2);

            // Assert
            Assert.AreEqual(artist2, secondArtist);
        }

        [TestMethod]
        public void AddRecord_MakesSureThatRecordAndArtistAreAssociated_RecordList()
        {
            // Arrange
            Artist artist = new Artist("BTS");
            Record record1 = new Record("Dynamite");
            Record record2 = new Record("Stay Gold");
            artist.AddRecord(record1);
            artist.AddRecord(record2);
            List<Record> btsRecords = new List<Record> { record1, record2 };

            // Act
            List<Record> records = artist.Records;

            // Assert
            CollectionAssert.AreEqual(btsRecords, records);
        }

        [TestMethod]
        public void GetRecordAmount_ReturnsTheNumberOfSongsThatAreRegisteredUnderTheArtist_Int()
        {
            // Arrange
            Artist artist = new Artist("BTS");
            Record record1 = new Record("Dynamite");
            Record record2 = new Record("Stay Gold");
            artist.AddRecord(record1);
            artist.AddRecord(record2);
            List<Record> btsRecords = new List<Record> { record1, record2 };

            // Act
            int recordAmount = artist.GetRecordsAmount();

            // Assert
            Assert.AreEqual(btsRecords.Count, recordAmount);
        }

        [TestMethod]
        public void SearchByArtist_ReturnsAnEmptyList_ArtistList()
        {
            // Arrange
            List<Artist> artists = new List<Artist> { };

            // Act
            string artist = "Dach";
            List<Artist> artistConfirmed = Artist.Search(artist);

            // Assert
            CollectionAssert.AreEqual(artists, artistConfirmed);
        }

        [TestMethod]
        public void SearchByArtist_ReturnsTheArtisteswhichNameIsEqualToTheSearchedName_ArtistList()
        {
            // Arrange
            Artist artist = new Artist("danny");
            Artist artist1 = new Artist("danny");

            // Act
            List<Artist> artists = new List<Artist>{artist , artist1};
            List<Artist> confirmedArtist = Artist.Search("danny");

            // Assert
            CollectionAssert.AreEqual(artists , confirmedArtist);
        }
        [TestMethod]
        public void SearchByArtist_ReturnsTheArtisteswhichNameContainsTheSearchedName_ArtistList()
        {
            // Arrange
            Artist artist = new Artist("danny");
            Artist artist1 = new Artist("dannyOladeji");

            // Act
            List<Artist> artists = new List<Artist>{artist , artist1};
            List<Artist> confirmedArtist = Artist.Search("danny");

            // Assert
            CollectionAssert.AreEqual(artists , confirmedArtist);
        }

        [TestMethod]
        public void SearchByArtist_ReturnsTheArtistsSearchedIrrespectiveOfTheCase_ArtistList()
        {
            // Arrange
            Artist artist = new Artist("danny");
            Artist artist1 = new Artist("dannyOladeji");

            // Act
            List<Artist> artists = new List<Artist>{artist , artist1};
            List<Artist> confirmedArtist = Artist.Search("DANNY");

            // Assert
            CollectionAssert.AreEqual(artists , confirmedArtist);
        }
    }
}