using System.Collections.Generic;
using System.Linq;

namespace OutCount.Sut
{
    public class NameFrequencySorter : INameFrequencySorter
    {
        public ICollection<NameFrequencyDto> Sort(ICollection<PersonDetail> personDetails)
        {
            var names = personDetails
                .Select(g => g.FirstName)
                .Concat(personDetails.Select(g => g.LastName));

            return names
                .GroupBy(s => s)
                .Select(g => new NameFrequencyDto
                {
                    Name = g.Key,
                    Count = g.Count(s => s == g.Key)
                }).OrderByDescending(g => g.Count).ThenBy(g => g.Name)
                .ToArray();
        }
    }
}