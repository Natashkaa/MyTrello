namespace MyTrello.Resources
{
    public class UserResource : IResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhotoPath { get; set; }
        public string Email { get; set; }
    }
}