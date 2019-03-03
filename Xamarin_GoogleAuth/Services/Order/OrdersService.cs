using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_GoogleAuth.Services.Requests;
using Xamarin_GoogleAuth.Models;
using Android.Telephony.Data;
using Android.App;

namespace Xamarin_GoogleAuth.Services.Order
{
    public class OrdersService:IOrdersService
    {
        private readonly IRequestsService _requestService;

        public OrdersService(IRequestsService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Orders>> GetPersonsAsync()
        {
            UriBuilder builder = new UriBuilder("http://test.com");

            var url = builder.ToString();

            return await _requestService.GetAsync<IEnumerable<Orders>>(url);
        }
    }
}
