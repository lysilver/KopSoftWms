using System;
using System.Reflection.Emit;

namespace YL.Utils.Reflection
{
    public class EmitUtil
    {
        public static Func<object> CreateBuilder(Type type)
        {
            DynamicMethod dm = new DynamicMethod(string.Empty, typeof(object), Type.EmptyTypes);
            var gen = dm.GetILGenerator();
            if (type.IsValueType)
            {
                gen.DeclareLocal(type);
                gen.Emit(OpCodes.Ldloca_S, 0);
                gen.Emit(OpCodes.Initobj, type);
                gen.Emit(OpCodes.Ldloc_0);
                gen.Emit(OpCodes.Box, type);
            }
            else
            {
                gen.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
            }
            gen.Emit(OpCodes.Ret);
            Func<object> func = (Func<object>)dm.CreateDelegate(typeof(Func<object>));
            return func;
        }
    }
}