using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin_GoogleAuth.Models;

namespace Xamarin_GoogleAuth.Services.Order
{
    public interface IOrdersService
    {
        Task<IEnumerable<Orders>> GetPersonsAsync();
    }
}