using OrdersApiAppPV012.Model.Entity;


namespace OrdersApiAppPV012.Service

{
    public interface IDao<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
         Task<T> Add(T model);
         Task<T> Update(T model);
         Task<bool> Delete(int id);

    }
}
