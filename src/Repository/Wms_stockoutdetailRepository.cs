using YL.Core.Entity;
using IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Wms_stockoutdetailRepository : BaseRepository<Wms_stockoutdetail>, IWms_stockoutdetailRepository
    {
         public Wms_stockoutdetailRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}