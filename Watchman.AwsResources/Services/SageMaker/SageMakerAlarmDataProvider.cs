using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SageMaker.Model;
using Amazon.CloudWatch.Model;
using Watchman.Configuration.Generic;

namespace Watchman.AwsResources.Services.SageMaker
{
    public class SageMakerAlarmDataProvider : IAlarmDimensionProvider<EndpointSummary>,
            IResourceAttributesProvider<EndpointSummary, ResourceConfig>
    {
        public List<Dimension> GetDimensions(EndpointSummary resource, IList<string> dimensionNames)
        {
            return dimensionNames.Select(x => GetDimension(resource, x)).ToList();
        }

        public Task<decimal> GetValue(EndpointSummary resource, IList<string> dimensionNames)
        {
            throw new NotImplementedException();
        }

        private Dimension GetDimension(EndpointSummary resource, string dimensionName)
        {
            var dim = new Dimension
            {
                Name = dimensionName
            };

            switch (dimensionName)
            {
                case "EndpointName":
                    dim.Status = resource.EndpointStatus.Value;
                    break;
                
                default:
                    throw new Exception("Unsupported Dimension "+ dimensionName);
            }

            return dim;
        }
    }
}
