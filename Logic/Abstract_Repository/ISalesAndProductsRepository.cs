﻿using Entity.ConnectionEntity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface ISalesAndProductsRepository
    {
        HttpStatusCode Create(SalesAndProductsModel salesAndProducts);

        HttpStatusCode Update(SalesAndProductsModel salesAndProducts);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<SalesAndProductsModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<SalesAndProductsModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        SalesAndProductsModel GetById(int id);

        IEnumerable<SalesAndProductsModel> GetAll();

        int ExecuteRawSql(string command);
    }
}