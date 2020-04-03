using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstractions;
using OMF.Common.Models;

namespace OMF.ReviewManagementService.Query.Application.Repositories
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly INoSqlDataAccess _database;

        public ReviewRepository(INoSqlDataAccess database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Review>> GetRestaurantReviews(Guid restaurantId)
            => await _database.Find<Review>(x => x.RestaurantId == restaurantId);
    }
}
