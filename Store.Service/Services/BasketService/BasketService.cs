using AutoMapper;
using Store.Repository.Basket;
using Store.Repository.Basket.Models;
using Store.Service.Services.BasketService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        => await _basketRepository.DeleteBasketAsync(basketId);

        public async Task<CustomerBasketDto> GetBasketAsync(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            if(basket == null)
            {
                return new CustomerBasketDto();
            }
            else
            {
                var MappedBasket = _mapper.Map<CustomerBasketDto>(basket);
                return MappedBasket;
            }
        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto customerBasket)
        {
            if(customerBasket.Id is null)
            {
                customerBasket.Id = GenerateRandomId();
            }
            var custBasket = _mapper.Map<CustomerBasket>(customerBasket);
            var updatedBasket = await _basketRepository.UpdateBasketAsync(custBasket);
            var mappedUpdatedBasket = _mapper.Map<CustomerBasketDto>(updatedBasket);
            return mappedUpdatedBasket;
        }
        private string GenerateRandomId()
        {
            Random random = new Random();
            int RandomDigit = random.Next(1000, 10000);
            return $"BS-{RandomDigit}";
        }

    }
}
