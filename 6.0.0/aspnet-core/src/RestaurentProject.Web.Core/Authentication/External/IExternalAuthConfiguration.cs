using System.Collections.Generic;

namespace RestaurentProject.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
