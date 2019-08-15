using MarvelComicsLibrary.Integration.Model;

namespace MarvelComicsLibrary.Integration.Interface
{
    public interface IMarvelApi
    {
        MarvelComic GetComicByUpc(string upc);
        MarvelComic GetComicByTitle(string title);
    }
}
