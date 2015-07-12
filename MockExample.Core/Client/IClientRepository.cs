namespace MockExample.Core.Client
{
    public interface IClientRepository
    {
        Models.Client Get(int id);
    }
}