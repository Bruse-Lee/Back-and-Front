using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContosoPizza.Models;

namespace ContosoPizza.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// 属性,查询表 T:代表任意表(Models里的实体类)
        /// </summary>
        /// <value></value>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 根据获取的Id,查询对应的T类型实例
        /// </summary>
        /// <param name="id">获取的id,数据类型可能为:int、long、Guid等常见的主键类型</param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// 根据提供的实体对象,插入到数据库
        /// </summary>
        /// <param name="entity">提供的实体对象</param>
        void Insert(T entity);

        /// <summary>
        /// 根据提供的实体对象,插入到数据库（异步）
        /// </summary>
        /// <param name="entity">提供的实体对象</param>
        Task InsertAsync(T entity);

        /// <summary>
        /// 根据提供的实体对象,批量插入到数据
        /// </summary>
        /// <param name="entities">提供的实体对象</param>
        void InsertRange(IEnumerable<T> entities);

        /// <summary>
        /// 根据提供的实体对象,批量插入到数据（异步）
        /// </summary>
        /// <param name="entities">提供的实体对象集合</param>
        /// <returns></returns>
        Task InsertBulkAsync(IEnumerable<T> entities);

        /// <summary>
        /// 根据提供的主键Id,删除数据库中对应的数据
        /// </summary>
        /// <param name="id">提供的id</param>
        void Delete(object id);

        /// <summary>
        /// 根据提供的主键Id集合,批量删除数据库中对应的数据
        /// </summary>
        /// <param name="ids">提供的id的集合</param>
        // void DeleteRange(IEnumerable<T> ids);

        /// <summary>
        /// 根据提供的实体对象,更新实体到数据库
        /// </summary>
        /// <param name="entity">提供的实体对象</param>
        void Update(T entity);

        /// <summary>
        /// 提供的实体对象集合,批量更新实体到数据库
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        void UpdateRange(IEnumerable<T> entities);
    }
}