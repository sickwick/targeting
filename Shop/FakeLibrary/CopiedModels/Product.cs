using System.Collections.Generic;

namespace FakeLibrary.CopiedModels
{
    public struct Product
    {
        public string Id;
        public long Article;
        public string Category;
        public string Title;
        public string Label;
        public string Season;
        public bool Gender;
        public string Photo;
        public IEnumerable<Sizes> SizesAvailable;
    }
}