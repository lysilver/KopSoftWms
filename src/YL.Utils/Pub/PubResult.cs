using MessagePack;
using System.ComponentModel;

namespace YL.Utils.Pub
{
    [MessagePackObject]
    public class PubResult
    {
        [Key(0)]
        [Description("标识")]
        public bool Flag { get; set; }

        [Key(1)]
        [Description("信息")]
        public string Msg { get; set; }

        [Key(2)]
        [Description("数据")]
        public object Data { get; set; }
    }

    public class PubDelete
    {
        public string Id { get; set; }
    }

    public class PubResult<T>
    {
        public T Data { get; set; }

        public int Code { get; set; }

        public string Msg { get; set; }
    }

    public class PubResultTwo
    {
        [Description("标识")]
        public bool Flag { get; set; }

        [Description("信息")]
        public string Msg { get; set; }
    }
}