using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Dashboard
{
    public class NewsFarm: IFarm
    {
        private readonly Dictionary<string, object> _collectionNews;



        public NewsFarm()
        {
            _collectionNews = new Dictionary<string, object>();
        }



        public void Add(string name, Func<object> factory)
        {
            _collectionNews.Add(name, factory);
        }



        public void Remove(string name)
        {
            _collectionNews.Remove(name);
        }



        public void GetUp(string name)
        {
           
        }
    }
}
