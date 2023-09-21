using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Overview { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public long SoftwareHouseId { get; private set; }

        public Videogame(long id, string name, string overview, DateTime releaseDate, DateTime createdAt, DateTime updatedAt, long softwareHouseId)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            SoftwareHouseId = softwareHouseId;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Overview: {Overview}, Release Date: {ReleaseDate}, Created At: {CreatedAt}, Updated At: {UpdatedAt}, Software House ID: {SoftwareHouseId}";
        }
    }

}
