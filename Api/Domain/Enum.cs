namespace Domain;

public class Enum
{
    [Flags]
    public enum Role
    {
        Admin = 1,
        PM = 2,
        QA = 3,
        RD = 4
    }
}