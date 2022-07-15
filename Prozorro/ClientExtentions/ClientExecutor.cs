using Prozorro.Models;
using Prozorro.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.ClientExtentions
{
    public class ClientExecutor
    {
        private readonly RestClient _client;
        private readonly bool _isDebugging;
        public ClientExecutor(Mode mode = Mode.Dev, string baseUrl = "")
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                _client = new RestClient();
            }
            else
            {
                _client = new RestClient(baseUrl);
            }
            switch (mode)
            {
                case Mode.Dev:
                    _isDebugging = true; break;
                case Mode.Test:
                    _isDebugging = true; break;
                case Mode.Prod:
                    _isDebugging = false; break;
                default:
                    _isDebugging = false; break;
            }
        }

        private async Task<T> GetBaseContainerDTOAsync<T>(string type = "/api/offers", string param = "")
        {
            return await _client.GetAsync<T>(type, param);
        }

        public async Task<HashSet<BaseItemDTO>> LoadContainers( string typeName = "", int count = 0)
        {
            HashSet<BaseItemDTO> items = new();
            var startPoint = await this.GetBaseContainerDTOAsync<BaseContainerDTO<BaseItemDTO>>($"/api/{typeName}");
            string path = startPoint.NextPage.Path;
            int cntr = 0;
            do
            {

                foreach (var item in startPoint.Data)
                {
                    try
                    {
                        items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        if(_isDebugging) Console.WriteLine(ex);
                    }
                }
                if (_isDebugging) Console.WriteLine(path);
                startPoint = await this.GetBaseContainerDTOAsync<BaseContainerDTO<BaseItemDTO>>(path);
                if (path == startPoint.NextPage.Path)
                {
                    break;
                }
                path = startPoint.NextPage.Path;
                cntr++;
                if (cntr >= count)
                {
                    break;
                }
                if (cntr % 10 == 0)
                {
                    if (_isDebugging) Console.Clear();
                }
            }
            while (path != null);
            if (_isDebugging) Console.Clear();
            return items;
        }

        public async Task<HashSet<T>> LoadObjects<T>( HashSet<BaseItemDTO> containers, string typeName = "", int count = 0)
        {
            var list = containers.ToList();

            HashSet<T> offers = new();
            int cntr = 0;
            foreach (var item in containers)
            {

                if (_isDebugging) Console.WriteLine($"Завантаження офферів {cntr}/{containers.Count}...");
                var offer = await this.GetBaseContainerDTOAsync<T>($"/api/{typeName}/{item.Id}", "data");

                offers.Add(offer);

                cntr++;
                if (cntr % 10 == 0)
                {
                    if (_isDebugging) Console.Clear();
                }
                if (cntr >= count)
                {
                    break;
                }
            }
            if (_isDebugging) Console.WriteLine($"Завантаження {offers.Count} офферів завершилось успішно.");
            return offers;

        }

        

    }

}
