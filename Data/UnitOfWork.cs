using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UnitOfWork
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
}
