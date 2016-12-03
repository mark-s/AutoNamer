using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Books.v1.Data;

namespace AutoNamer.Lookup.Google
{
    public interface IGetData
    {
        Task<IList<Volume>> FromISBN(string isbn);
    }
}