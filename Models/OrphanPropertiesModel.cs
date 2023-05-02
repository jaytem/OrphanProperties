using System.Collections.Generic;

namespace <Site>.Web.Features.OrphanProperties.Models
{
    public class OrphanPropertiesModel
    {
        public string TypeName { get; set; }

        public string DisplayName { get; set; }

        public int ContentTypeId { get; set; }

        public IEnumerable<string> OrphanPropertiesList { get; set; }
    }
}
