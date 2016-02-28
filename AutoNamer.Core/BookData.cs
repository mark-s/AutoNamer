namespace AutoNamer.Core
{
    public class BookData
    {
        public SpineData Spine { get;  }

        public BookFileData FileData { get;  }

        public BookData(BookFileData fileData, SpineData spine)
        {
            FileData = fileData;
            Spine = spine;
        }
    }
}
