using AutoMapper;
using IEM.Business.Interfaces;
using IEM.Data.Interfaces;
using IEM.Data.Models;

namespace IEM.Business.DataServices
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<TModel> GetAll()
        {
            var AllEntity = _repository.GetAll();
            var AllModels = _mapper.Map<List<TModel>>(AllEntity);
            return AllModels;
        }
        public TModel GetByID(int id)
        {
            var Entity = _repository.Get(x => x.Id == id).FirstOrDefault();
            var Models = _mapper.Map<TModel>(Entity);
            return Models;
        }

        public void Add(TModel user)
        {
            var Entity = _mapper.Map<TEntity>(user);
            _repository.Save(Entity);
        }
        public void Update(TModel user)
        {
            var Entity = _mapper.Map<TEntity>(user);
            _repository.Save(Entity);
        }
        public void Delete(int id)
        {
            var Entity = _repository.Get(x => x.Id == id).FirstOrDefault();
            if (Entity != null)
            {
                _repository.Delete(Entity);
            }
        }
    }
}
