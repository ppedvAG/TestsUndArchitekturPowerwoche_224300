﻿namespace BooksManager.Common
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public IEnumerable<string> Authors { get; set; } = new List<string>();
    }
}