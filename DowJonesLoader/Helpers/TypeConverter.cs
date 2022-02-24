using DowJonesLoader.Constants;

namespace DowJonesLoader.Helpers;

public static class TypeConverter
{
    public static int ToIdentityType(this char type)
    {
        return type == IdentityType.INDIVIDUAL.ToString()[0]
            ? (int)(IdentityType.INDIVIDUAL)
            : (int)IdentityType.ORGANIZATION;
    }

    public static int ToIdNoType(this string typeStr)
    {
        if (string.IsNullOrWhiteSpace(typeStr))
            return 0;
        
        return typeStr == IdNoType.NationTaxNo.ToString().ToUpper() ? (int)IdNoType.NationalId : (int)IdNoType.NationTaxNo;
    }

    public static int ToDateType(this string typeStr)
    {
        return typeStr == DateType.DOB.ToString() ? (int)DateType.DOB : (int)DateType.DOR;
    }

    public static int ToNameType(this string typeStr)
    {
        if(typeStr == NameType.PRIMARY.ToString())
            return (int)NameType.PRIMARY;

        if(typeStr == NameType.SPELLING.ToString())
            return (int)(NameType.SPELLING);

        if (typeStr == NameType.AKA.ToString())
            return (int)NameType.AKA;

        return 0;
    }
}