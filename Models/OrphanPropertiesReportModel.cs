using System.Collections.Generic;

namespace <Site>.Web.Features.OrphanProperties.Models
{
    public class OrphanPropertiesReportModel
    {
        public IEnumerable<OrphanPropertiesModel> PagesList { get; set; }

        public IEnumerable<OrphanPropertiesModel> BlocksList { get; set; }

        public IEnumerable<OrphanPropertiesModel> MediaList { get; set; }
    }
}
