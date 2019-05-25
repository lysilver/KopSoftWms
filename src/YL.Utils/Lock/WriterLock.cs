using System;
using System.Threading;

namespace YL.Utils.Lock
{
    public class WriterLock : IDisposable
    {
        /// <summary>
        /// 表示用于管理资源访问的锁定状态，可实现多线程读取或进行独占式写入访问。
        /// </summary>
        private readonly ReaderWriterLockSlim _rwLock;

        public WriterLock(ReaderWriterLockSlim rwLock)
        {
            _rwLock = rwLock;
            _rwLock.EnterWriteLock();
        }

        void IDisposable.Dispose()
        {
            _rwLock.ExitWriteLock();
        }
    }
}