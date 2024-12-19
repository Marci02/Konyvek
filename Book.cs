using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CA_1219
{
    internal class Book
    {
        private int releaseYear;
        private int stock;
        private string title;
        private string language;
        private long iSBN;
        private int price;
        private List<Author> authors;

        public long ISBN
        {
            get => iSBN;
            set
            {
                if (value.ToString().Length != 10)
                    throw new Exception("invalid ISBN");
                iSBN = value;
            }
        }
        public List<Author> Authors
        {
            get => authors;
            set
            {
                if (value.Count < 1 || value.Count > 3)
                    throw new Exception("invalid author");
                authors = value;
            }
        }
        public string Title
        {

            get => title;
            set
            {
                if (value.Length < 3 || value.Length > 64)
                    throw new Exception("invalid title");
                title = value;
            }
        }
        public int ReleaseYear
        {
            get => releaseYear;
            set
            {
                if (value < 2007 || value > DateTime.Today.Year)
                    throw new Exception("invalid date");
                releaseYear = value;
            }
        }
        public string Language
        {
            get => language;
            set
            {
                if (value != "angol" && value != "magyar" && value != "német")
                    throw new Exception("invalid language");
                language = value;
            }
        }
        public int Stock
        {
            get => stock;
            set
            {
                if (value < 0)
                    throw new Exception("invalid stock");
                stock = value;
            }
        }
        public int Price
        {
            get => price;
            set
            {
                if (value < 1000 || value > 10000 || value % 100 != 0)
                    throw new Exception("invalid price");
                price = value;
            }
        }



        public Book(long _iSBN, List<Author> _authors, string _title, int _releaseYear, string _language, int _stock, int _price)
        {
            ISBN = _iSBN;
            Authors = _authors;
            Title = _title;
            ReleaseYear = _releaseYear;
            Language = _language;
            Stock = _stock;
            Price = _price;
        }

        public Book(string _title,params string[] _authorName)
        {
            Title = _title;

            List<Author> tempAuth = [];

            foreach (var item in _authorName)
                Authors = tempAuth;
                
            
            Stock = 0;
            Language = "magyar";
            Price = 4500;
            ISBN = Random.Shared.Next(1000000000, 2000000000);
            ReleaseYear = 2024;
        }

       
        public override string ToString()
        {
            string authorsLabel = (Authors.Count == 1) ? "szerző:" : "szerzők:";
            string stockLabel = (Stock == 0) ? "beszerzés alatt" : $"{Stock} db";

            return $"Cím: {Title}\n{authorsLabel} {string.Join(", ", Authors)}\nKiadás éve: {ReleaseYear}\nNyelv: {Language}\nISBN: {ISBN}\nKészlet: {stockLabel}\nÁr: {Price} Ft";
        }
        
    }
}
