﻿using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Lookups
{
    public class LookupDataService : IFriendLookupDataService, IProgrammingLanguageLookupDataService
    {
        private Func<FriendOrganizerDBContext> _contextCreator;

        public LookupDataService(Func<FriendOrganizerDBContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking()
                    .Select(f =>
                    new LookupItem
                    {
                        Id = f.Id,
                        DisplayMember = f.FirstName + " " + f.LastName
                    })
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<LookupItem>> GetProgrammingLanguageLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.ProgrammingLanguages.AsNoTracking()
                    .Select(pl =>
                    new LookupItem
                    {
                        Id = pl.Id,
                        DisplayMember = pl.Name
                    })
                    .ToListAsync();
            }
        }
    }
}
