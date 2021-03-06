﻿using CityInfo.API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>
            {
                new City
                {
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterest>
                    {
                        new PointOfInterest
                        {
                            Name="Central Park",
                            Description = "The most visited urban park in the United States."
                        },
                        new PointOfInterest
                        {
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhatten."
                        }
                    }
                },
                new City
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished."
                },
                new City
                {
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterest>
                    {
                        new PointOfInterest
                        {
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                        },
                        new PointOfInterest
                        {
                            Name = "The Louvre",
                            Description = "The world's largets museum."
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
