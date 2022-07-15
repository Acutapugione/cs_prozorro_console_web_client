
using Prozorro.ClientExtentions;
using Prozorro.Models;
using Prozorro.Models.Enums;
using System.Text;

ClientExecutor Client = new(Mode.Prod, "https://catalog-api-staging.prozorro.gov.ua");
Console.OutputEncoding = Encoding.UTF8;

await LoadItems<OfferDTO>(Client, "offers");

await LoadItems<VendorDTO>(Client, "vendors");

await LoadItems<CategoryDTO>(Client, "categories");

await LoadItems<ProfileDTO>(Client, "profiles");

await LoadItems<ProductDTO>(Client, "products");

static async Task<HashSet<T>> LoadItems<T>(ClientExecutor client, string typeName = "products")
{
    try
    {
        HashSet<BaseItemDTO> indexes = await client
            .LoadIndexesByType(
            typeName: typeName,
            count: 100);

        var items = await client
            .LoadObjectsByType<T>(
            indexes,
            typeName: typeName,
            count: 100);

        return items;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return new();
    }
}
