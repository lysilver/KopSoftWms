using YL.Core.Entity;
using IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Wms_stockoutRepository : BaseRepository<Wms_stockout>, IWms_stockoutRepository
    {
         public Wms_stockoutRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}