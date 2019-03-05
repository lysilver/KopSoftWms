using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using YL.Utils.Check;
using YL.Utils.Pub;
using YL.Utils.Log;

namespace YL.Utils.Delegate
{
    public class DelegateUtil
    {
        public static void TryExecute(Action action)
        {
            //CheckNull.ArgumentIsNullException(action, nameof(action));
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string TryCatch(Action action)
        {
            try
            {
                action.Invoke();
                return PubEnum.Success.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static void TryCatch(Action action, Action<string> actionException)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                actionException.Invoke(ex.ToString());
            }
        }

        public static T TryExecute<T>(Func<T> fun)
        {
            try
            {
                return fun();
            }
            catch (Exception ex)
            {
                SingletonUtil<NlogUtil>.GetInstance().Debug(ex);
                //new NlogUtil().Debug(ex);
                return default;
            }
        }

        public static T TryExecute<T>(Func<T> func, T defaultValue = default)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                SingletonUtil<NlogUtil>.GetInstance().Debug(ex);
                //new NlogUtil().Debug(ex);
                return defaultValue;
            }
        }

        public static T TryExecute<T>(Func<T> func, Func<T> exception)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                SingletonUtil<NlogUtil>.GetInstance().Debug(ex);
                return exception();
            }
        }

        public static void TryScope(Action action, Action<Exception> onException = null, Action onFinally = null)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                onException?.Invoke(e);
            }
            finally
            {
                onFinally?.Invoke();
            }
        }

        public static void TryCatchTask(Action action, Action<string> actionException)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    actionException.Invoke(ex.ToString());
                }
            });
        }

        public static void SafeStartTask(Action action)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }

        public static void SafeInvoke(Action action)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    action();
                }
                catch { }
            });
        }

        public static async Task<T> SafeStartTaskAsync<T>(Func<T> func)
        {
            TaskCompletionSource<T> ts = new TaskCompletionSource<T>();
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    T result = func();
                    ts.SetResult(result);
                }
                catch (Exception ex)
                {
                    ts.SetException(ex);
                }
            });
            return await ts.Task;
        }

        public static Task<T> SafeStartTask<T>(Func<T> func)
        {
            TaskCompletionSource<T> ts = new TaskCompletionSource<T>();
            Task.Factory.StartNew(() =>
           {
               try
               {
                   T result = func();
                   ts.SetResult(result);
               }
               catch (Exception ex)
               {
                   ts.SetException(ex);
               }
           });
            return ts.Task;
        }

        public static long TryStopWatch(Action action)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                action();
                watch.Stop();
                return watch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RunAsync(Action firstFunc, Action next)
        {
            Task firstTask = new Task(() =>
            {
                firstFunc();
            });

            firstTask.Start();
            firstTask.ContinueWith(x => next());
        }

        public static void RunAsync(Func<object> firstFunc, Action<object> next)
        {
            Task<object> firstTask = new Task<object>(() =>
            {
                return firstFunc();
            });

            firstTask.Start();
            firstTask.ContinueWith(x => next(x.Result));
        }

        public static void UseTransactionScope(Action action)
        {
            using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    action();
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    tran.Dispose();
                }
            }
        }
    }
}