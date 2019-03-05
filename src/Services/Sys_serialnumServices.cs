using IRepository;
using IServices;
using YL.Core.Entity;
using YL.Utils.Extensions;

namespace Services
{
    public class Sys_serialnumServices : BaseServices<Sys_serialnum>, ISys_serialnumServices
    {
        private readonly ISys_serialnumRepository _repository;

        public Sys_serialnumServices(ISys_serialnumRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public string GetSerialnum(long userId, string tableName)
        {
            var dt = DateTimeExt.GetDateTimeS(DateTimeExt.DateTimeShortFormat);
            var model = _repository.QueryableToEntity(c => c.TableName == tableName && c.IsDel == 1);
            if (dt == null || model.ModifiedDate == null || dt != model.ModifiedDate.Value.ToString(DateTimeExt.DateTimeShortFormat))
            {
                model.SerialCount = 0;
            }
            model.SerialCount++;
            var num = model.Prefix + DateTimeExt.GetDateTimeS(DateTimeExt.DateTimeFormatString) + model.SerialCount.ToString($"x{model.Mantissa}");
            var flag = _repository.Update(new Sys_serialnum { SerialNumberId = model.SerialNumberId, SerialNumber = num, SerialCount = model.SerialCount, ModifiedBy = userId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.SerialNumber, c.SerialCount, c.ModifiedBy, c.ModifiedDate });
            return num;
        }

        public Sys_serialnum GetSerialnumEntity(long userId, string tableName)
        {
            var dt = DateTimeExt.GetDateTimeS(DateTimeExt.DateTimeShortFormat);
            var model = _repository.QueryableToEntity(c => c.TableName == tableName && c.IsDel == 1);
            if (dt == null || model.ModifiedDate == null || dt != model.ModifiedDate.Value.ToString(DateTimeExt.DateTimeShortFormat))
            {
                model.SerialCount = 0;
            }
            model.SerialCount++;
            var num = model.Prefix + DateTimeExt.GetDateTimeS(DateTimeExt.DateTimeFormatString) + model.SerialCount.ToString($"x{model.Mantissa}");
            model.SerialNumber = num;
            _repository.Update(new Sys_serialnum { SerialNumberId = model.SerialNumberId, SerialCount = model.SerialCount, ModifiedBy = userId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.SerialNumber, c.SerialCount, c.ModifiedBy, c.ModifiedDate });
            return model;
        }
    }
}