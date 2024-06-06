using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class FeaturePostManager : IFeaturePostService
    {
        private readonly IFeaturePostDal _featurePostDal;

        public FeaturePostManager(IFeaturePostDal featurePostDal)
        {
            _featurePostDal = featurePostDal;
        }

        public void TDelete(int id)
        {
            _featurePostDal.Delete(id);
        }

        public FeaturePost TGetById(int id)
        {
            return _featurePostDal.GetById(id);
        }

        public List<FeaturePost> TGetListAll()
        {
           return _featurePostDal.GetListAll();
        }

        public void TInsert(FeaturePost entity)
        {
            _featurePostDal.Insert(entity);
        }

        public void TUpdate(FeaturePost entity)
        {
            _featurePostDal.Update(entity);
        }
    }
}
