namespace Domain;

[Flags]
public enum Role
{
    Admin = 1,
    PM = 2,
    QA = 4,
    RD = 8
}