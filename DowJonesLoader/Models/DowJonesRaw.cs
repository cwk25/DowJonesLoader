namespace DowJonesLoader.Models;

public class DowJonesRaw
{
    public string DJ_NAME { get; set; }
    public string DJ_ID_NO { get; set; }
    public string DJ_PERSON_ID { get; set; }
    public char DJ_IND_ORG { get; set; }
    public string DJ_DESC1 { get; set; }
    public DateTime DJ_DOB_DOR { get; set; }
    public string DJ_NAME_TYPE { get; set; }
    public string DJ_ID_TYPE { get; set; }
    public string DJ_DATE_TYPE { get; set; }
    public char DJ_GENDER { get; set; }
    public bool DJ_SANCTION_INDC { get; set; }
    public bool DJ_OCCUP_INDC { get; set; }
    public bool DJ_RLENSHIP_INDC { get; set; }
    public bool DJ_OTHER_LIST_INDC { get; set; }
    public bool DJ_ACTIVE_STATUS { get; set; }
    public string DJ_CITIZENSHIP { get; set; }
}