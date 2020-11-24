using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces.Services
{
    public interface ICheckDbService
    {
        Task<bool> CheckProductIdAsync(int productId, CancellationToken cancellationToken);
        Task<bool> CheckCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}
