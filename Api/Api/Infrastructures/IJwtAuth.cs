namespace Api.Infrastructures;

public interface IJwtAuth
{
    void Decode(string bearer);
}