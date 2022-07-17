using Project_Model.Context;
using Project_Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hiexpert.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    
    {
        Hiexpert_Context db;
        DbSet<T> dbset; 

        public GenericRepository(Hiexpert_Context Context)
        {
            db = Context;
            dbset = Context.Set<T>(); 

        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList(); 
        }

        public T GetEntity(int id)
        {
            return dbset.Find(id); 
        }

        public bool AddEntity(T entity)
        {
            try
            {
                dbset.Add(entity);
                return true; 
            }
            catch
            {
                return false; 

            }
        }

        public bool UpdateEntity(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception e )
            {
                return false;

            }

        }

        public bool DeleteEntity(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;

            }
        }

        public bool DeleteEntity(int id)
        {

            try
            {
                var entity = dbset.Find(id);//GetEntity(int id)
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;

            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        

       

        

        
    }
}
