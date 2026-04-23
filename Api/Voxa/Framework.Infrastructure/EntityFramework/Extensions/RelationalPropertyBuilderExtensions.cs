using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Infrastructure.EntityFramework.Extensions;

public static class RelationalPropertyBuilderExtensions
{
    public static PropertyBuilder<Guid> HasRandomUUID(this PropertyBuilder<Guid> propertyBuilder)
    {
        return propertyBuilder.HasDefaultValueSql("gen_random_uuid()");
    }
}