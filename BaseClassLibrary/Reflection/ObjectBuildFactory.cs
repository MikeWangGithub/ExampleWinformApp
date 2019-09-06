using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BaseClassLibrary.Reflection
{
    /// <summary>
    /// DIP Class
    /// </summary>
    /// <typeparam name="T">generic class</typeparam>
    public class ObjectBuildFactory<T>
    {
        /// <summary>
        /// Create concrete class by ClassName
        /// </summary>
        /// <param name="key">fullClassName</param>
        /// <returns></returns>
        public static T Instance(string key)
        {
            return Instance(key, null);
        }
        /// <summary>
        /// Create concrete class by ClassName
        /// </summary>
        /// <param name="key">fullClasName</param>
        /// <returns></returns>
        public static T Instance(string key,object[] objects)
        {
            Assembly[] assemblies =  System.AppDomain.CurrentDomain.GetAssemblies();
            T t = default(T);
            foreach (var item in assemblies)
            {
                t  = Instance(item, key, objects);
                if (t != null)
                {
                    break;
                }
            }
            return t;
        }

        public static T Instance(System.Reflection.Assembly assembly ,  string key, object[] objects)
        {
            Type obj = assembly.GetType(key);
            if (obj == null) return default(T);
            //return CreateInstance(typeName, ignoreCase: false, BindingFlags.Instance | BindingFlags.Public, null, null, null, null);
            T factory = (T)obj.Assembly.CreateInstance(obj.FullName, false, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, objects, null, null); ;

            return factory;
        }

        //Console.WriteLine("============ \n");
        //    Console.WriteLine("FullName:" + assembly.FullName);
        //    Console.WriteLine("CodeBase:" + assembly.CodeBase);
        //    Console.WriteLine("EscapedCodeBase:" + assembly.EscapedCodeBase);
        //    Console.WriteLine("GlobalAssemblyCache:" + assembly.GlobalAssemblyCache);
        //    Console.WriteLine("HostContext:" + assembly.HostContext);
        //    Console.WriteLine("ImageRuntimeVersion:" + assembly.ImageRuntimeVersion);
        //    Console.WriteLine("IsDynamic:" + assembly.IsDynamic);
        //    Console.WriteLine("IsFullyTrusted:" + assembly.IsFullyTrusted);
        //    Console.WriteLine("Location:" + assembly.Location);
        //    Console.WriteLine("ReflectionOnly:" + assembly.ReflectionOnly);
        //    Console.WriteLine("SecurityRuleSet:" + assembly.SecurityRuleSet);
    }
}
