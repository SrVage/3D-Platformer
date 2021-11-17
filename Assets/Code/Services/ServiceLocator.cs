using Code.Loading.Abstraction;
using UnityEngine;

namespace Code.Services
{
    public class ServiceLocator
    {
        public static ServiceLocator Container => _instance ??= new ServiceLocator();
        private static ServiceLocator _instance;

        public TService Single<TService>() where TService:IService
        {
            return Implemential<TService>.Service;
        }

        public void RegisterService<TService>(TService service) where TService:IService
        {
            Implemential<TService>.Service = service;
        }

        private static class Implemential<TService> where TService:IService
        {
            public static TService Service;
        }
    }
}