using adonet_db_videogame;

Console.WriteLine("Welcome to our Videogames manager!!!");


while (true)
{
    Console.WriteLine(@"
- 1: Create VideoGames 
- 2: Show VideoGames by Id
- 3: Search Videogames by String
- 4: Delete VideoGames
- 5: Exit 

");

    Console.Write("Make your choice: ");

    int selectedOption = int.Parse(Console.ReadLine());

    switch (selectedOption)
    {
        //CREATE A VIDEOGAME
        case 1:
            {
                Console.WriteLine("Create a Videogame:");
                Console.WriteLine("Enter the title of the game: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the overview of the game: ");
                string overview = Console.ReadLine();
                Console.WriteLine("Enter the release date of the game: ");
                DateTime releasedate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the software house ID of the game: ");
                long softwareHouseId = long.Parse(Console.ReadLine());

                Videogame vg = new Videogame(0, name, overview, releasedate, softwareHouseId);
                bool inserted = VideogameManager.AddVideogame(vg);

                if (inserted)
                {
                    Console.WriteLine("Game added!");
                }
                else
                {
                    Console.WriteLine("Game not created!");
                }

            }
            break;

        //FILTER BY ID
        case 2:

            Console.WriteLine("Insert Game Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Videogame videogame = VideogameManager.GetVideogameById(id);

            if (videogame != null)
            {
                Console.WriteLine($"Videogame found: {videogame.Name}");
            }
            else
            {
                Console.WriteLine("No videogame found with the specified ID.");
            }

            break;

        case 3:
            {
                Console.WriteLine("Insert a string");
                string gamestring = Console.ReadLine();

                List<Videogame> videogames = VideogameManager.GetVideogamesByString($"%{gamestring}%");

                if (videogames != null && videogames.Count > 0)
                {
                    Console.WriteLine("Here the games founded:");

                    foreach (Videogame vg in videogames)
                    {
                        Console.WriteLine(vg.Name);
                    }
                }
                else
                {
                    Console.WriteLine("No game found.");
                }

                return;
            }

            case 4:
            return;

        case 5:
            Console.WriteLine("Exiting the program...");
            return;


        default:
            Console.WriteLine("No options choosed");
            break;

    }


}

