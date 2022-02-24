using DowJonesLoader.Domains;
using DowJonesLoader.Helpers;
using DowJonesLoader.Models;
using DowJonesLoader.Repositories;
using FuzzySharp;

var lines = File.ReadAllLines(@"D:\Prototype\SanctionList\dowjones.txt");
//var input = "VANESSA TORIBIO YSABEL";
//Console.WriteLine($"Match Ratio: {Fuzz.Ratio(input, "TORIBIO YSABEL VANESSA")}");
//Console.WriteLine($"Match Ratio: {Fuzz.Ratio(input, "VANESSA TORIBIO YSABEL")}");
//Console.WriteLine($"Match Ratio: {Fuzz.TokenSetRatio(input, "TORIBIO YSABEL VANESSA")}");
//Console.WriteLine($"Match Ratio: {Fuzz.TokenSetRatio(input, "TORIBIO YSABEL VANESSA")}");

var rawData = new List<DowJonesRaw>();
foreach (var line in lines)
{
    rawData.Add(new DowJonesRaw
    {
        DJ_NAME = line[..42].Trim(),
        DJ_ID_NO = line[42..84].Trim(),
        DJ_PERSON_ID = line[84..98].Trim(),
        DJ_IND_ORG = line[98],
        DJ_DESC1 = line[110..120].Trim(),
        DJ_DOB_DOR = DateTime.Parse(line[120..130]),
        DJ_NAME_TYPE = line[132..146].Trim(),
        DJ_ID_TYPE = line[146..198],
        DJ_DATE_TYPE = line[198..200].Trim(),
        DJ_GENDER = line[212],
        DJ_SANCTION_INDC = line[223] == 'Y',
        DJ_OCCUP_INDC = line[241] == 'Y',
        DJ_RLENSHIP_INDC = line[256] == 'Y',
        DJ_OTHER_LIST_INDC = line[274] == 'Y',
        DJ_ACTIVE_STATUS = line[294] == 'Y',
        DJ_CITIZENSHIP = line[312..314]
    });
}

var distinct = rawData.Select(r => r.DJ_PERSON_ID).Distinct();
Console.WriteLine(distinct.Count());

var sortedRawData = rawData.OrderBy(d => d.DJ_PERSON_ID).ToList();

Console.WriteLine(sortedRawData.Count());

var repo = new WatchListRepo();
var insertedId = 0;
foreach (var data in sortedRawData)
{
    var currentIndex = sortedRawData.IndexOf(data);

    if (currentIndex == 0 || data.DJ_PERSON_ID != sortedRawData[currentIndex - 1].DJ_PERSON_ID)
    {
        var identity = new DowJonesIdentity
        {
            DowJonesId = data.DJ_PERSON_ID,
            IndOrgTypeId = data.DJ_IND_ORG.ToIdentityType(),
            IdNo = data.DJ_ID_NO,
            IdTypeId = data.DJ_ID_TYPE.ToIdNoType(),
            DowJonesDesc1 = data.DJ_DESC1,
            Dob = data.DJ_DOB_DOR,
            DobTypeId = data.DJ_DATE_TYPE.ToDateType(),
            Gender = data.DJ_GENDER,
            HasSanction = data.DJ_SANCTION_INDC,
            HasOccupation = data.DJ_OCCUP_INDC,
            HasRelationship = data.DJ_RLENSHIP_INDC,
            HasOtherList = data.DJ_OTHER_LIST_INDC,
            IsActive = data.DJ_ACTIVE_STATUS,
            Citizenship = data.DJ_CITIZENSHIP
        };
        insertedId = identity.Id = await repo.AddIdentity(identity);
    }
    var identityName = new DowJonesIdentityName
    {
        IdentityId = insertedId,
        Name = data.DJ_NAME,
        NameTypeId = data.DJ_NAME_TYPE.ToNameType()
    };

    await repo.AddIdentityName(identityName);
}


