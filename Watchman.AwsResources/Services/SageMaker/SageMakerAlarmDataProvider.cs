using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SageMaker.Model;
using Amazon.CloudWatch.Model;
//using Watchman.Configuration.Generic;

namespace Watchman.AwsResources.Services.SageMaker
{
    public class SageMakerAlarmDataProvider : IAlarmDimensionProvider<EndpointSummary>,
        IResourceAttributesProvider<EndpointSummary, Watchman.Configuration.Generic.ResourceConfig>
    {
        public List<Dimension> GetDimensions(EndpointSummary resource, IList<string> dimensionNames)
        {
            return dimensionNames.Select(x => GetDimension(resource, x)).ToList();
        }

        public Task<decimal> GetValue(EndpointSummary resource, Watchman.Configuration.Generic.ResourceConfig config, 
            string property)
        {
            throw new NotImplementedException();
        }

        private Dimension GetDimension(EndpointSummary resource, string dimensionName)
        {
            var dim = new Dimension
            {
                Name = dimensionName
            };

            return dim;
        }
    }
}
