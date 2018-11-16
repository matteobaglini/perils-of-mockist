namespace AccessControl.App
{
    public class Account
    {
        private readonly string id;
        private readonly string[] permittedGates;

        public Account(string id, string name, string[] permittedGates)
        {
            this.id = id;
            this.permittedGates = permittedGates;
        }
    }
}