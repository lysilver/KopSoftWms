using System.ComponentModel;
using YL.Localization;

namespace YL.Utils.Pub
{
    public enum PubEnum
    {
        [LocalizableDescription("成功")]
        Success = 100,

        [LocalizableDescription("model验证失败返回")]
        Failed = 101,

        [LocalizableDescription("提示错误")]
        Error = 102
    }

    public enum ExcelVersion
    {
        V2007,
        V2003
    }

    public enum Qualified
    {
        [LocalizableDescription("不合格")]
        IsUn = 0,

        [LocalizableDescription("合格")]
        Un = 1,
    }

    public enum EProductType
    {
        [LocalizableDescription("原物料")]
        Material = 1,

        [LocalizableDescription("半成品")]
        SFG = 2,

        [LocalizableDescription("产成品")]
        Goods = 3,

        [LocalizableDescription("虚拟件")]
        Part = 4,
    }

    public enum PubDictType
    {
        [LocalizableDescription("单位类别")]
        unit = 1,

        [LocalizableDescription("物料分类")]
        material = 2,

        [LocalizableDescription("入库单")]
        stockin = 3,

        [LocalizableDescription("出库单")]
        stockout = 4,

        [LocalizableDescription("设备分类")]
        device = 5,

        [LocalizableDescription("设备产权")]
        property = 6
    }

    public enum PubLevel
    {
        [LocalizableDescription("一级")]
        one = 1,

        [LocalizableDescription("二级")]
        two = 2,

        [LocalizableDescription("三级")]
        three = 3
    }

    /// <summary>
    /// 入出库单状态
    /// </summary>
    public enum StockInStatus
    {
        [LocalizableDescription("初始")]
        initial = 1,

        [LocalizableDescription("审核通过")]
        egis = 2,

        [LocalizableDescription("审核未通过")]
        auditfailed = 3,

        [LocalizableDescription("审核中")]
        underReview = 4,

        /// <summary>
        /// 出库用
        /// </summary>
        [LocalizableDescription("已发货")]
        delivery = 5,
    }

    public enum LogType
    {
        [LocalizableDescription("LOGIN")]
        login = 1,

        [LocalizableDescription("INSERT")]
        add = 2,

        [LocalizableDescription("UPDATE")]
        update = 4,

        [LocalizableDescription("INSERT_OR_UPDATE")]
        addOrUpdate = add | update,

        [LocalizableDescription("DELETE")]
        delete = 8,

        [LocalizableDescription("SELECT")]
        select = 16,

        [LocalizableDescription("EXCEPTION")]
        exception = 32,

        [LocalizableDescription("ERROR")]
        error = 64,

        [LocalizableDescription("导出")]
        export = 128,

        [LocalizableDescription("导入")]
        import = 256,

        [LocalizableDescription("上传")]
        upload = 512,

        [LocalizableDescription("下载")]
        download = 1024,
    }
}