
using Prozorro.ClientExtentions;
using Prozorro.Models;
using Prozorro.Models.Enums;
using System.Text;

ClientExecutor Client = new(Mode.Dev, "https://catalog-api-staging.prozorro.gov.ua");
Console.OutputEncoding = Encoding.UTF8;

HashSet<BaseItemDTO> containers = await Client.LoadContainers(typeName: "offers", count: 100);
HashSet<OfferDTO> offers = await Client.LoadObjects<OfferDTO>(containers, typeName: "offers", count: 100);