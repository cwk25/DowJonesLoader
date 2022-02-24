namespace DowJonesLoader.Domains;

public class DowJonesIdentity
{
    public int Id { get; set; }
    public string DowJonesId { get; set; }
    public int IndOrgTypeId { get; set; }
    public string IdNo { get; set; }
    public int IdTypeId { get; set; }
    public string DowJonesDesc1 { get; set; }
    public DateTime Dob { get; set; }
    public int DobTypeId { get; set; }
    public char Gender { get; set; }
    public bool HasSanction { get; set; }
    public bool HasOccupation { get; set; }
    public bool HasRelationship { get; set; }
    public bool HasOtherList { get; set; }
    public bool IsActive { get; set; }
    public string Citizenship { get; set; }
}