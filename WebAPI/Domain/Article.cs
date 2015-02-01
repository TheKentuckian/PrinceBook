using System;

namespace PrinceBookWebAPI.Models
{
    public class Article
    {
        public Guid ID;
        public string Name;
        public string Title;
        public int IndustryID;
        public byte[] Image;
        public bool HasGroupChat;
        //public int AuthorID;
    }
}