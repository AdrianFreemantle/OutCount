using System.Collections.Generic;
using OutCount.DataObjects;
using OutCount.FileProcessing;

namespace OutCount.Parsers
{
    public class PersonDetailsFileParser
    {
        private readonly IPersonDetailParser personDetailParser;

        public PersonDetailsFileParser(IPersonDetailParser personDetailParser)
        {
            this.personDetailParser = personDetailParser;
        }

        public ICollection<PersonDetail> ParseFile(string fileName)
        {
            var dataFile = CsvFile.OpenFile(fileName);
            List<PersonDetail> personDetails = new List<PersonDetail>();

            foreach (CsvFileRow row in dataFile)
            {
                PersonDetail details = personDetailParser.Parse(row.ToString());
                personDetails.Add(details);
            }

            return personDetails;
        }
    }
}