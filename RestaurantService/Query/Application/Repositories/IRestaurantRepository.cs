using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;

namespace OMF.RestaurantService.Query.Application.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    }
}
