using <Site>.Web.Features.OrphanProperties.Models;

namespace <Site>.Web.Features.OrphanProperties.Services
{
    public interface IOrphanPropertiesService
    {
        OrphanPropertiesReportModel CompileOrphanProperties();
    }
}
