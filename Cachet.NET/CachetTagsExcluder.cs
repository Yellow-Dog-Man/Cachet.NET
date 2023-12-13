using Cachet.NET.Responses.Objects;
using System;
using System.Text.Json.Serialization.Metadata;

namespace Cachet.NET
{
    // Cachet throws errors if we re-serialize the tags, so for now we exclude them
    // Based on: https://devblogs.microsoft.com/dotnet/system-text-json-in-dotnet-7/#example-conditional-serialization
    // But: https://github.com/dotnet/runtime/issues/66490#issuecomment-1235547214 should be used in the future
    public class CachetTagsExcluder
    {
        public static void IgnoreTags(JsonTypeInfo typeInfo)
        {
            
            if (typeInfo.Type != typeof(ComponentObject))
                return;

            foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
            {
                if (propertyInfo.Name.ToLowerInvariant() == "tags")
                {
                    propertyInfo.ShouldSerialize = static (obj, value) => false;
                }
            }
        }
    }
}
