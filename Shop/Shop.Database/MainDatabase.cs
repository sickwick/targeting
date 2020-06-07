using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Database.Stubs;
using Shop.Storage.Models;

namespace Shop.Database
{
    public class MainDatabase : DatabaseBase

    {
    public override  Task<List<TModel>> GetDatabaseList<TModel>()
    {
        throw new NotImplementedException();
    }

    public override void AddInDatabase<TModel>(TModel model)
    {
        throw new NotImplementedException();
    }

    public override void ChangeModelInDatabase<TModel>(TModel model, TModel newModel)
    {
        throw new NotImplementedException();
    }

    public override void DeleteModelFromDatabase<TModel>(TModel model)
    {
        throw new NotImplementedException();
    }
    }
}