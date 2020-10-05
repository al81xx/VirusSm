using System.Linq;
using System.Reflection;
using VirusSm.Database.Interfaces;
using VirusSm.v1.Shared.Interfaces;

namespace VirusSm.v1.Shared.Utils
{
    public static class Mapper
    {
        public static TU ToDbModel<T, TU>(this T from)
            where T : IBaseMapperModel
            where TU : IDbModel, new()
        {
            return from.Map<T, TU>();
        }

        public static TU ToExposedModel<T, TU>(this T from)
            where T : IDbModel
            where TU : IBaseMapperModel, new()
        {
            return from.Map<T, TU>();
        }

        private static TU Map<T, TU>(this T from) 
            where TU : new()
        {
            var to = new TU();
            var toType = typeof(TU);
            var fromType = typeof(T);

            var toPropertiesInfo = toType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var fromPropertiesInfo = fromType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            foreach (var toPropertyInfo in toPropertiesInfo)
            {
                var fromPropertyInfo = fromPropertiesInfo.FirstOrDefault(fp => fp.Name == toPropertyInfo.Name);
                if (fromPropertyInfo == null)
                    continue;

                toPropertyInfo.SetValue(to, fromPropertyInfo.GetValue(from));
            }
            
            return to;
        }
    }
}