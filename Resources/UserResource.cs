namespace MyTrello.Resources
{
    public class UserResource : IResource
    {
        public int UserId { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_PhotoPath { get; set; }
        public string User_Email { get; set; }
    }
}