using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ToNotGiveAFuck.Services
{
    public class ConotationService
    {
        public static bool DoIHaveAFriend(Guid id, ClaimsPrincipal identity)
        {
            var context = new Models.ToNotGiveAFuckContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Models.ToNotGiveAFuckContext>());
            var ret = context.Conotation.Count(c => c.Kind == Models.TODOs.Enumerations.ConotationKinds.Friend
            && ((c.Person1Id == id && c.Person2Id == Guid.Parse(identity.Claims.First().Value))
            || (c.Person2Id == id && c.Person1Id == Guid.Parse(identity.Claims.First().Value)))) == 1;

            context.Dispose();

            return ret;
        }
    }
}
