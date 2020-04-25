using RCP.DL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
    public class BaseRepository<T> : IDisposable where T : class, new()
        //where Context : DbContext,new()
    {
        //protected Context context;
        protected readonly RentCarContext context = new RentCarContext();

        public bool Add(T data)
        {
            try
            {
                //using (context=new Context())
                {
                    var T = context.Set<T>().Add(data);
                    //context.Entry<T>(data).State = EntityState.Added;

                    int result = context.SaveChanges();
                    return result > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                //using (context = new Context())
                {
                    var silinecekData = context.Set<T>().Find(id);
                    context.Set<T>().Remove(silinecekData);
                    //context.Entry<T>(silinecekData).State = EntityState.Deleted;
                    var result = context.SaveChanges();
                    return result > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<T> GetAll()
        {

            //using (context=new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {

            //using (context = new Context())
            {
                return context.Set<T>().Find(id);
            }
        }

        public bool Update(T data)
        {
            //using (context = new Context())
            {
                context.Entry<T>(data).State = EntityState.Modified;
                int result = context.SaveChanges();
                //ternary if
                return result > 0 ? true : false;
            }
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)//arama filtreleme
        {
            //using (context=new Context())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }
        public T GetByFilterx(Expression<Func<T, bool>> filter)//arama filtreleme
        {
            //using (context=new Context())
            {
                return context.Set<T>().Where(filter).FirstOrDefault();
            }
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
