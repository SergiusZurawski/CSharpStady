using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereImplementation
{
    public class OrderUsersByLengthOfNameWithLet
    {
        public static void Example()
        {
            var query = from user in SampleData.AllUsers
                        let length = user.Name.Length
                        orderby length
                        select new { Name = user.Name, Length = length };

            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}", entry.Length, entry.Name);
            }

            ///The query is translated to the following 
            /// New type is introduced 
            SampleData.AllUsers.Select(user => new { user, length = user.Name.Length })
                               .OrderBy(z => z.length)
                               .Select(z => new { Name = z.user.Name, Length = z.length });

        }
    }

}
