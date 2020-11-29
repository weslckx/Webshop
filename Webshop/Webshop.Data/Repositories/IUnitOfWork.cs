using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Data.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        int Complete();
    }
}
