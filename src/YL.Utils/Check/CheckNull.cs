using System;
using YL.Utils.Extensions;

namespace YL.Utils.Check
{
    public static class CheckNull
    {
        public static void ArgumentIsNullException<TArgument>(TArgument argument, string argumentName = "不能为空")
            where TArgument : class
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argumentName));
        }

        public static void ArgumentIsNullException(string argument, string argumentName = "不能为空")
        {
            if (argument.IsNull2())
                throw new ArgumentException(nameof(argumentName));
        }

        public static void ArgumentIsNullException(string argumentName = "不能为空")
        {
            throw new ArgumentException(nameof(argumentName));
        }

        public static void ThrowException(string argumentName = "未实现")
        {
            throw new Exception(nameof(argumentName));
        }
    }
}