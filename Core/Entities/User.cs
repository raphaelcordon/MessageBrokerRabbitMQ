namespace Core.Entities;

public class User : Base
{
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    
}