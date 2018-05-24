using System;
using System.Collections.Generic;
using DataAccessHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Author> AuthorList = new List<Author>();
            AuthorList.Add(new Author("Mahesh Chand", 35, "A Prorammer's Guide to ADO.NET", true, new DateTime(2003, 7, 10)));
            AuthorList.Add(new Author("Neel Beniwal", 18, "Graphics Development with C#", false, new DateTime(2010, 2, 22)));
            AuthorList.Add(new Author("Praveen Kumar", 28, "Mastering WCF", true, new DateTime(2012, 01, 01)));
            AuthorList.Add(new Author("Mahesh Chand", 35, "Graphics Programming with GDI+", true, new DateTime(2008, 01, 20)));
            AuthorList.Add(new Author("Raj Kumar", 30, "Building Creative Systems", false, new DateTime(2011, 6, 3)));
            BulkInsertManager.ConvertToDataTable(AuthorList);
        }
    }
}