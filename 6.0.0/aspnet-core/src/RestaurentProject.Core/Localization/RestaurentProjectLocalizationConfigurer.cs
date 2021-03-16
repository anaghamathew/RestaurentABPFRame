using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace RestaurentProject.Localization
{
    public static class RestaurentProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(RestaurentProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(RestaurentProjectLocalizationConfigurer).GetAssembly(),
                        "RestaurentProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
