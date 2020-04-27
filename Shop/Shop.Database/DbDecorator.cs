using Shop.Database.Interfaces;

namespace Shop.Database
{
    public abstract class DbDecorator: DatabaseBase
    {
        protected DatabaseBase _databaseBase;

        public DbDecorator(DatabaseBase databaseBase)
        {
            _databaseBase = databaseBase;
        }

    }
}