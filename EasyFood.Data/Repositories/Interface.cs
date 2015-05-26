using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFood.Data.Repositories.GenericResository;

namespace EasyFood.Data.Repositories
{
    #region ICuisineRepository
    public interface ICuisineRepository : IGenericRepository<cuisine>
    {

    }
    #endregion

    #region IDishRepository
    public interface IDishRepository : IGenericRepository<dish> { }
    #endregion

    #region IOrderRepository
    public interface IOrderRepositort : IGenericRepository<order> { }
    #endregion

    #region IOrderItemsRepository
    public interface IOrderItemsRepository : IGenericRepository<order_items> { }
    #endregion

    #region IRestaurantRepository
    public interface IRestaurantRepository : IGenericRepository<restaurant> { }
    #endregion

    #region IRestaurantRepository
    public interface IReviewRepository : IGenericRepository<review> { }
    #endregion

   


}
