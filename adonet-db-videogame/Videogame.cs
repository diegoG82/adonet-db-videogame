namespace adonet_db_videogame
{
    public class Videogame
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Overview { get; private set; }
        public DateTime ReleaseDate { get; private set; }
       
        public long SoftwareHouseId { get; private set; }

        public Videogame(long id, string name, string overview, DateTime releaseDate,  long softwareHouseId)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
          
  SoftwareHouseId = softwareHouseId;
        }


        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Overview: {Overview}, Release Date: {ReleaseDate}, Software House ID: {SoftwareHouseId}";
        }
    }

}
