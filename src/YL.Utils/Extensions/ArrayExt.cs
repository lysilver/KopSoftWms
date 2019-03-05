using System;
using System.Collections.Generic;
using System.Text;

namespace YL.Utils.Extensions
{
    public static class ArrayExt
    {
        public static Span<T> GetSpan<T>(T[] arr)
        {
            var part = new Span<T>(arr);
            return part;
        }

        public static Span<T> GetSpan<T>(T[] arr, int start, int length)
        {
            var part = new Span<T>(arr, start: start, length: length);
            return part;
        }

        public static Memory<T> GetMemory<T>(T[] arr)
        {
            var part = new Memory<T>(arr);
            return part;
        }

        public static Memory<T> GetMemory<T>(T[] arr, int start, int length)
        {
            var part = new Memory<T>(arr, start: start, length: length);
            return part;
        }
    }
}