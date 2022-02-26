using System.ComponentModel;

namespace YL.Utils.Pub
{
    public enum PubEnum
    {
        [Description("成功")]
        Success = 100,

        [Description("model验证失败返回")]
        Failed = 101,

        [Description("提示错误")]
        Error = 102
    }

    public enum ExcelVersion
    {
        V2007,
        V2003
    }

    public enum Qualified
    {
        [Description("不合格")]
        IsUn = 0,

        [Description("合格")]
        Un = 1,
    }

    public enum EProductType
    {
        [Description("原物料")]
        Material = 1,

        [Description("半成品")]
        SFG = 2,

        [Description("产成品")]
        Goods = 3,

        [Description("虚拟件")]
        Part = 4,
    }

    public enum PubDictType
    {
        [Description("单位类别")]
        unit = 1,

        [Description("物料分类")]
        material = 2,

        [Description("入库单")]
        stockin = 3,

        [Description("出库单")]
        stockout = 4,

        [Description("设备分类")]
        device = 5,

        [Description("设备产权")]
        property = 6
    }

    public enum PubLevel
    {
        [Description("一级")]
        one = 1,

        [Description("二级")]
        two = 2,

        [Description("三级")]
        three = 3
    }

    /// <summary>
    /// 入出库单状态
    /// </summary>
    public enum StockInStatus
    {
        [Description("初始")]
        initial = 1,

        [Description("审核通过")]
        egis = 2,

        [Description("审核未通过")]
        auditfailed = 3,

        [Description("审核中")]
        underReview = 4,

        /// <summary>
        /// 出库用
        /// </summary>
        [Description("已发货")]
        delivery = 5,
    }

    public enum LogType
    {
        [Description("登录")]
        login = 1,

        [Description("添加")]
        add = 2,

        [Description("修改")]
        update = 3,

        [Description("添加或修改")]
        addOrUpdate = add | update,

        [Description("删除")]
        delete = 4,

        [Description("删除")]
        select = 5,

        [Description("异常")]
        exception = 6,

        [Description("错误")]
        error = 7,

        [Description("导出")]
        export = 8,

        [Description("导入")]
        import = 9,

        [Description("上传")]
        upload = 10,

        [Description("下载")]
        download = 11,
    }
}