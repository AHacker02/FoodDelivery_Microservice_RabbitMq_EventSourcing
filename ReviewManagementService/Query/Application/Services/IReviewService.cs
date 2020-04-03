using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;

namespace OMF.ReviewManagementService.Query.Application.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetRestaurantReviews(Guid restaurantId);
    }
}
