using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using projekt4.Model;

namespace projekt4.Repositories
{
    //A collection of objects
    public interface IRepository<TEntity> where TEntity : class
    {
        //Finding Objects
        TEntity Get(int id); //Returns an entity with the given ID
        IEnumerable<TEntity> GetAll(); //Retunr all objects
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate); //Find takes a predicate which is an expression of func, so we use 
        //an Lamda expression to filter objects, Same as where with linq

        //Adding Objects
        void Add(TEntity entity); //Add one
        void AddRange(IEnumerable<TEntity> entities); //Add a list

        //Removing Objects
        void Remove(TEntity entity); //Remove one
        void RemoveRange(IEnumerable<TEntity> entities); //Remove a list
    }
}
