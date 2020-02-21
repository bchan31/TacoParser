using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            var lines = File.ReadAllLines(csvPath);
            // Log and error if you get 0 lines and a warning if you get 1 line
            if(lines.Length == 0)
            {
                logger.LogError("Target file returned no data");
            }
            if(lines.Length == 1)
            {
                logger.LogWarning("Target file only contains one location");
            }

            foreach(var item in lines)
            {
                logger.LogInfo($"Lines: {item}");
            }

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file

            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // Create a `double` variable to store the distance
            double distance = 0;
            ITrackable locA = null;
            ITrackable locB = null;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
           for(int i = 0; i < locations.Length; i++)
            {
                for(int j = 1; j < locations.Length; j++)
                {
                    var corA = new GeoCoordinate(locations[i].Location.Latitude, locations[i].Location.Longitude);
                    var corB = new GeoCoordinate(locations[j].Location.Latitude, locations[j].Location.Longitude);
                    double newDistance = corA.GetDistanceTo(corB);
                    
                    if(newDistance > distance)
                    {
                        distance = newDistance;
                        locA = locations[i];
                        locB = locations[j];
                    }
                }
            }

            Console.WriteLine(locA.Name);
            Console.WriteLine(locB.Name);
            Console.WriteLine(distance + "meters");
            
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.


            
        }
    }
}