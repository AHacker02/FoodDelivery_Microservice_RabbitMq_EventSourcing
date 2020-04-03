using OMF.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstractions;
using DataAccess.MongoDb;
using MongoDB.Driver;

namespace OMF.ReviewManagementService.Command.Application.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly INoSqlDataAccess _database;

        public ReviewRepository(IMongoClient client)
        {
            _database = new MongoDbDataAccess(new MongoConnectionFactory("OMF-Reviews",client), "Reviews");
        }

        public async Task<IEnumerable<Review>> GetRestaurantReviews(Guid restaurantId)
            => await _database.Find<Review>(x => x.RestaurantId == restaurantId);

        public async Task UpsertReview(Review review)
        {
            var existingReview = await _database.Single<Review>(x => x.UserId==review.UserId && x.RestaurantId==review.RestaurantId);
            if (existingReview != null)
            {
                await _database.Delete<Review>(x => x.Id == review.Id);
                
            }
            await _database.Add(review);
        }
    }
}
