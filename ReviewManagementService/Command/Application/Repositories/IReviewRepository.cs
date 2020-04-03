using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;

namespace OMF.ReviewManagementService.Command.Application.Repositories
{
    public interface IReviewRepository
    {
        Task UpsertReview(Review review);
        Task<IEnumerable<Review>> GetRestaurantReviews(Guid restaurantId);
    }
}
