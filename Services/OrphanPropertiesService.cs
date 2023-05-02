using System.Collections.Generic;
using System.Linq;

using EPiServer.DataAbstraction;

using <Site>.Web.Features.OrphanProperties.Models;

namespace <Site>.Web.Features.OrphanProperties.Services
{
    public class OrphanPropertiesService : IOrphanPropertiesService
    {
        private readonly IContentTypeRepository _contentTypeRepository;

        public OrphanPropertiesService(IContentTypeRepository contentTypeRepository)
        {
            _contentTypeRepository = contentTypeRepository;
        }

        public OrphanPropertiesReportModel CompileOrphanProperties()
        {
            var orphanPropertiesReport = new OrphanPropertiesReportModel();
            orphanPropertiesReport.PagesList = GetOrphanPropertiesByContentType(_contentTypeRepository.List().Where(x => x.Base == ContentTypeBase.Page));
            orphanPropertiesReport.BlocksList = GetOrphanPropertiesByContentType(_contentTypeRepository.List().Where(x => x.Base == ContentTypeBase.Block));
            orphanPropertiesReport.MediaList = GetOrphanPropertiesByContentType(_contentTypeRepository.List()
                .Where(
                x => x.Base == ContentTypeBase.Media
                || x.Base == ContentTypeBase.Image
                || x.Base == ContentTypeBase.Video));

            return orphanPropertiesReport;
        }

        private IEnumerable<OrphanPropertiesModel> GetOrphanPropertiesByContentType(IEnumerable<ContentType> contentTypes)
        {
            var orphanPropertyList = new List<OrphanPropertiesModel>();

            foreach (var type in contentTypes)
            {
                List<string> propertyList = new List<string>();

                foreach (var property in type.PropertyDefinitions)
                {
                    if (!property.ExistsOnModel)
                    {
                        propertyList.Add(property.Name);
                    }
                }

                if (propertyList.Count > 0)
                {
                    orphanPropertyList.Add(new OrphanPropertiesModel
                    {
                        TypeName = type.Name,
                        DisplayName = type.DisplayName,
                        ContentTypeId = type.ID,
                        OrphanPropertiesList = propertyList,
                    });
                }
            }

            return orphanPropertyList;
        }
    }
}
