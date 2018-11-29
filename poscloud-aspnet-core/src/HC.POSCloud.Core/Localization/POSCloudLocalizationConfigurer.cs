using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HC.POSCloud.Localization
{
    public static class POSCloudLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(POSCloudConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(POSCloudLocalizationConfigurer).GetAssembly(),
                        "HC.POSCloud.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
