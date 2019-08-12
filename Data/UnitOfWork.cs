namespace Data
{
    public class UnitOfWork
    {
        private readonly SchoolContext _schoolContext;

        public UnitOfWork(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public void SaveChanges()
        {
            _schoolContext.SaveChanges();
        }
    }
}
