namespace Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SchoolContext _schoolContext;

        public UnitOfWork(SchoolContext schoolContext)
        {
            this._schoolContext = schoolContext;
        }

        public void SaveChanges()
        {
            _schoolContext.SaveChanges();
        }
    }

    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
