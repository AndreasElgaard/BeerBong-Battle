using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace WebApiProjekt4.Data.EFCore
{
    //A collection of objects
    public interface IRepository<TEntity> where TEntity : class
    {
        //Finding Objects
        Task<TEntity> Get(int id); //Returns an entity with the given ID
        Task<IEnumerable<TEntity>> GetAll(); //Retunr all objects
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate); //Find takes a predicate which is an expression of func, so we use 
        //an Lamda expression to filter objects, Same as where with linq

        //Adding Objects
        Task Add(TEntity entity); //Add one
        Task AddRange(IEnumerable<TEntity> entities); //Add a list

        //Removing Objects
        void Remove(int id); //Remove one
        void RemoveRange(IEnumerable<TEntity> entities); //Remove a list

        //Update object
        void Update(TEntity entity);

    }
}
