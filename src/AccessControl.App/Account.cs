namespace AccessControl.App
{
    public class Account
    {
        public string Name { get; }
        private readonly string id;
        private readonly string[] permittedGates;

        public Account(string id, string name, string[] permittedGates)
        {
            Name = name;
            this.id = id;
            this.permittedGates = permittedGates;
        }
    }
}