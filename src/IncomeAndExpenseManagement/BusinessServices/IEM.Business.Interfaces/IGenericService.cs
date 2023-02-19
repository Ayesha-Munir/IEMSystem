namespace IEM.Business.Interfaces
{
    public interface IGenericService<TModel>
    {
        public List<TModel> GetAll();
        public TModel GetByID(int id);
        public void Add(TModel user);
        public void Update(TModel user);
        public void Delete(int id);
    }
}
