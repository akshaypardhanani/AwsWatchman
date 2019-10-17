using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Watchman.AwsResources.Services.SageMaker
{
    public class SageMakerSource : ResourceSourceBase<EndpointSummary>
    {
        private readonly IAmazonSageMaker _amazonSageMaker;

        public SageMakerSource(IAmazonSageMaker amazonSageMaker)
        {
            _amazonSageMaker = amazonSageMaker;
        }

        protected override string GetResourceName(EndpointSummary resource)
        {
            return resource.EndpointName;
        }

        protected override async Task<IEnumerable<EndpointSummary>> FetchResources()
        {
            var results = new List<IEnumerable<EndpointSummary>>();
            string nextToken = null;

            do
            {
                var response = await _amazonSageMaker.ListEndpointsAsync(new ListEndpointsRequest()
                {
                    NextToken = nextToken
                });

                results.Add(response.Endpoints.ToList());
                nextToken = response.NextToken;
            } while (!string.IsNullOrEmpty(nextToken));

            return results.SelectMany(x => x).ToList();
        }
    }
}
