namespace TMS.Domain.ValueObjects;

public class NameVO
{
    public NameVO(string name)
    {
        if(!IsValidFormat(name))
            throw new ArgumentException("Invalid name");

        Name = name;
    }

    public string Value => Name;
    public string Name { get; }

    public static bool IsValidFormat(string validName)
    {
        if(validName.Length < 2)
            return false;

        return true;
    }
}