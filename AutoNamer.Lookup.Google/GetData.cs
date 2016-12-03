using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;

namespace AutoNamer.Lookup.Google
{
    public class GetData : IGetData
    {
        public async Task<IList<Volume>> FromISBN(string isbn)
        {
            using (var booksService = new BooksService())
            {
                var volumes = await booksService.Volumes.List($"isbn:{isbn}").ExecuteAsync();
                return volumes.Items;
            }
        }
    }
}
