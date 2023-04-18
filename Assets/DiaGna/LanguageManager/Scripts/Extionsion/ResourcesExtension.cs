using System.IO;
using UnityEngine;

namespace DiaGna.Freamwork.Language
{
    public class ResourcesExtension
    {
        public static string ResourcesPath = Application.dataPath + "/Resources";

        /// <summary>
        /// Loads an asset stored at path in a Resources folder using an optional systemTypeInstance filter.
        /// </summary>
        /// <param name="resourceName">The name of the resource to load.</param>
        /// <param name="systemTypeInstance">Type filter for objects returned.</param>
        /// <returns>The requested asset returned as an Object.</returns>
        public static Object Load(string resourceName, System.Type systemTypeInstance)
        {
            Object result = Resources.Load(resourceName, systemTypeInstance);

            if (result != null)
                return result;

            string[] directories = Directory.GetDirectories(ResourcesPath, "*.*", SearchOption.AllDirectories);
            foreach (var item in directories)
            {
                string itemPath = item.Substring(ResourcesPath.Length + 1);
                result = Resources.Load(itemPath + "\\" + resourceName, systemTypeInstance);
                if (result != null)
                    return result;
            }
            return null;
        }

        /// <summary>
        /// Loads a resource of the specified type with the specified resource name.
        /// </summary>
        /// <typeparam name="T">The type of the resource to load.</typeparam>
        /// <param name="resourceName">The name of the resource to load.</param>
        /// <returns>The loaded resource of the specified type, or null if the resource could not be found.</returns>
        public static T Load<T>(string resourceName) where T : Object
        {
            Object result = Resources.Load<T>(resourceName);

            if (result != null && result is T t)
                return t;

            string[] directories = Directory.GetDirectories(ResourcesPath, "*", SearchOption.AllDirectories);
            foreach (var item in directories)
            {
                string itemPath = item.Substring(ResourcesPath.Length + 1);
                result = Resources.Load(itemPath + "\\" + resourceName, typeof(T));
                if (result != null && result is T TResult)
                    return TResult;
            }
            return null;
        }
    }
}