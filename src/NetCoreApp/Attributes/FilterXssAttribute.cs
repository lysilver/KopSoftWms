using Microsoft.AspNetCore.Mvc.Filters;
using System;
using YL.Utils.Security;

namespace YL.NetCore.Attributes
{
    /// <summary>
    /// https://www.cnblogs.com/sagecheng/p/9462239.html
    /// https://www.cnblogs.com/87Super/p/9294850.html
    /// </summary>
    public class FilterXssAttribute : ActionFilterAttribute
    {
        private Xss _xss;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var req = context.HttpContext.Request;
            var ps = context.ActionDescriptor.Parameters;
            _xss = context.HttpContext.RequestServices.GetService(typeof(Xss)) as Xss;
            foreach (var p in ps)
            {
                if (context.ActionArguments[p.Name] != null)
                {
                    //当参数等于字符串
                    if (p.ParameterType == typeof(string))
                    {
                        context.ActionArguments[p.Name] = _xss.Filter(context.ActionArguments[p.Name].ToString());
                    }
                    else if (p.ParameterType.IsClass)//当参数等于类
                    {
                        ModelFieldFilter(p.Name, p.ParameterType, context.ActionArguments[p.Name]);
                    }
                }
            }
            //var qs = QueryHelpers.ParseQuery(req.QueryString.ToUriComponent());
            //var ret = new QueryString();
            //foreach (var k in qs.Keys)
            //{
            //    for (var i = 0; i < qs[k].Count(); i++)
            //    {
            //        try
            //        {
            //            ret.Add(k, _xss.Filter(qs[k][i]));
            //        }
            //        catch
            //        {
            //            ret.Add(k, qs[k][i]);
            //        }
            //    }
            //}
            //req.QueryString = ret;
            base.OnActionExecuting(context);
        }

        private object ModelFieldFilter(string key, Type t, object obj)
        {
            //获取类的属性集合
            //var ats = t.GetCustomAttributes(typeof(FieldFilterAttribute), false);
            if (obj != null)
            {
                //Type type = obj.GetType().GetGenericArguments()[0];
                //获取类的属性集合
                var pps = t.GetProperties();

                foreach (var pp in pps)
                {
                    if (pp.GetValue(obj) != null)
                    {
                        //当属性等于字符串
                        if (pp.PropertyType == typeof(string))
                        {
                            string value = pp.GetValue(obj).ToString();
                            pp.SetValue(obj, _xss.Filter(value));
                        }
                        else if (pp.PropertyType.IsClass)//当属性等于类进行递归
                        {
                            pp.SetValue(obj, ModelFieldFilter(pp.Name, pp.PropertyType, pp.GetValue(obj)));
                        }
                    }
                }
            }

            return obj;
        }
    }
}