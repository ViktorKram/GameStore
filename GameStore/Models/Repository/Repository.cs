﻿using System.Collections.Generic;

namespace GameStore.Models.Repository
{
    public class Repository
    {
        readonly private EFDbContext context = new EFDbContext();

        public IEnumerable<Game> Games
        {
            get { return context.Games; }
        }
    }
}