using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace WebApplication.Models
{
    public interface ICRUDCarRepository
    {
        Car Add(Car car);
        Car Update(Car car);
        void Delete(Car car);
        Car FindById(int id);
        IList<Car> FindPage(int page, int size);
    }

    public class EFCRUDCarRepository : ICRUDCarRepository
    {
        private CarDBContext context;

        public EFCRUDCarRepository(CarDBContext context)
        {
            this.context = context;
        }

        public Car Add(Car car)
        {

            Car entityEntry = context.Cars.Add(car);
            context.SaveChanges();
            return entityEntry;

        }

        public void Delete(Car car)
        {
            context.Cars.Remove(car);
            context.SaveChanges();

        }

        public Car FindById(int id)
        {
            return context.Cars.Find(id);
        }

        public IList<Car> FindPage(int page, int size)
        {
            return (from car in context.Cars orderby car.Make select car).Skip(page * size).Take(size).ToList();
        }

        public Car Update(Car car)
        {
            throw new NotImplementedException();

        }
    }
}
