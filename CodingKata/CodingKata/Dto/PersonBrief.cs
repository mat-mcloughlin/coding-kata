namespace CodingKata.Dto
{
    public class PersonBrief
    {
        public PersonBrief(string firstName, string lastName, bool isAuthorised, bool isEnabled)
        {
            this.IsEnabled = isEnabled;
            this.Name = firstName + " " + lastName;
            this.IsAuthorised = isAuthorised;
        }

        public bool IsEnabled { get; private set; }

        public bool IsAuthorised { get; private set; }

        public string Name { get; private set; }
    }
}