using _4._0_GetPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4._0_GetPost
{
    public class SampleData
    {
        public static void Initialize(EssenceContext context)
        {
            if (!context.Musics.Any())
            {
                context.Musics.AddRange(
                    new Music
                    {
                        Executor = "Alan Walker",
                        Name = "Fade",
                        Genre = "Club",
                        Lenght = 100
                    },
                    new Music
                    {
                        Executor = "Scorpions",
                        Name = "Last song",
                        Genre = "Rock",
                        Lenght = 200
                    },
                    new Music
                    {
                        Executor = "Skillet",
                        Name = "Rise",
                        Genre = "Rock",
                        Lenght = 150
                    }
                );
                context.SaveChanges();
            }

            if(!context.Alcohols.Any())
            {
                context.Alcohols.AddRange(
                    new Alcohol
                    {
                        Brand = "Триозерье",
                        Type = "Водка",
                        Volume = 15,
                        Strength = 40
                    },
                    new Alcohol
                    {
                        Brand = "Jack Daniel's",
                        Type = "Виски",
                        Volume = 20,
                        Strength = 40
                    }
                );
            }
            context.SaveChanges();
        }
    }
}
