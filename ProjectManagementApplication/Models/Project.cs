namespace ProjectManagementApplication.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Members { get; set; }

    public string Deadline { get; set; }

}