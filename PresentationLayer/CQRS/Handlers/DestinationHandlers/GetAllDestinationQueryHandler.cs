using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.CQRS.Queries.DestinationQueries;
using PresentationLayer.CQRS.Results.DestinationResults;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                DestinationId = x.DestinationId,
                Capacity = x.Capacity,
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price

            }).AsNoTracking().ToList();
            return values;
        }
    }
}
