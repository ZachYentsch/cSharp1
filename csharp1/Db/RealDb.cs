using csharp1.Models;

namespace csharp1.Db
{
    public class RealDb
    {
        public static List<Artist> Artists { get; set; } = new List<Artist>()
    {
        new Artist("Michelangelo", "Painter or Ninja Turtle", "https://www.dhresource.com/0x0s/f2-albu-g10-M00-10-37-rBVaWVwjRMmAGyDKAAV96nGHKRM961.jpg/michelangelo-creation-of-adam-art-silk-print.jpg", "Creation of Adam", 1512),
        new Artist("Raphael", "Painter or Ninja Turtle", "https://th.bing.com/th/id/R.86566fad62f438639ae1962dc7ce6689?rik=Fha3UXiVv7dkSg&riu=http%3a%2f%2fupload.wikimedia.org%2fwikipedia%2fcommons%2f5%2f51%2fTransfiguration_Raphael.jpg&ehk=cPHnLm7UDtkwbuOqlpg9%2bhd9D0GvHADi%2bYFXOtIJvQQ%3d&risl=&pid=ImgRaw&r=0", "Transfiguration", 1520),
        new Artist("Leonardo", "Painter or Ninja Turtle", "https://th.bing.com/th/id/R.f2fdd829899cfc032b4e3586146d6111?rik=SD1LyXlo5p3c2g&riu=http%3a%2f%2fwww.kerrisdalegallery.com%2fboni%2fwp-content%2fuploads%2f2013%2f03%2fvd016pv-leonardo-da-vinci_mona-lisa.jpg&ehk=bYizxi7bg79yoKn%2fSQsqx03cp44zVRG6TS3UEOkoDNE%3d&risl=&pid=ImgRaw&r=0", "Mona Lisa", 1517)
    };
    }
}