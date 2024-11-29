namespace BilethubApi.Api.Application.OrganizerOperations.Queries.GetOrganizers;

public class GetOrganizersViewModel
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
}