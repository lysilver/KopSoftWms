using YL.Core.Entity;

namespace IServices
{
    public interface ISys_serialnumServices : IBaseServices<Sys_serialnum>
    {
        string GetSerialnum(long userId, string tableName);

        Sys_serialnum GetSerialnumEntity(long userId, string tableName);
    }
}