using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Shop.Web
{
    public class CartoesService
    {
        private readonly ILogger logger;
        private int count = 0;

        public CartoesService(ILogger<CartoesService> logger)
        {
            this.logger = logger;
        }

        public int Salvar (string ccnumber, string cvv)
        {
            logger.LogInformation($"Cartao cadastrado. {ccnumber}:{cvv}");

            count++;

            return count;

        }
    }
}
