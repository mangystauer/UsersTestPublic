namespace DataAccessLibrary.Models
{
    public interface IUser
    {
        string AdLogin { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        bool IsDeleted { get; set; }
        string LastName { get; set; }
        string? MiddleName { get; set; }
    }
}