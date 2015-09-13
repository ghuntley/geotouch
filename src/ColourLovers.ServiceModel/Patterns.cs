using System;
using System.Collections.Generic;

//[
//    {
//        "id": 2205745,
//        "title": "Golden Lion",
//        "userName": "Gigglish",
//        "numViews": 10,
//        "numVotes": 0,
//        "numComments": 0,
//        "numHearts": 0,
//        "rank": 0,
//        "dateCreated": "2012-02-13 19:37:54",
//        "colors": [
//            "FFF2BF",
//            "DBB14E",
//            "FFCC00",
//            "333333"
//        ],
//        "description": "",
//        "url": "http://www.colourlovers.com/pattern/2205745/Golden_Lion",
//        "imageUrl": "http://colourlovers.com.s3.amazonaws.com/images/patterns/2205/2205745.png",
//        "badgeUrl": "http://www.colourlovers.com/images/badges/n/2205/2205745_Golden_Lion.png",
//        "apiUrl": "http://www.colourlovers.com/api/pattern/2205745",
//        "template": {
//            "title": "MJS Insanity 2",
//            "url": "http://www.colourlovers.com/pattern/template/129080/MJS_Insanity_2",
//            "author": {
//                "userName": "myjupiterstar",
//                "url": "http://www.colourlovers.com/lover/myjupiterstar"
//            }
//        }
//    }
//]
namespace ColourLovers.ServiceModel
{
    public class Author
    {
        public string url
        {
            get; set;
        }

        public string userName
        {
            get; set;
        }
    }

    public class Patterns
    {
        public string apiUrl
        {
            get; set;
        }

        public string badgeUrl
        {
            get; set;
        }

        public List<string> colors
        {
            get; set;
        }

        public DateTimeOffset dateCreated
        {
            get; set;
        }

        public string description
        {
            get; set;
        }

        public int id
        {
            get; set;
        }

        public string imageUrl
        {
            get; set;
        }

        public int numComments
        {
            get; set;
        }

        public int numHearts
        {
            get; set;
        }

        public int numViews
        {
            get; set;
        }

        public int numVotes
        {
            get; set;
        }

        public int rank
        {
            get; set;
        }

        public Template template
        {
            get; set;
        }

        public string title
        {
            get; set;
        }

        public string url
        {
            get; set;
        }

        public string userName
        {
            get; set;
        }
    }

    public class Template
    {
        public Author author
        {
            get; set;
        }

        public string title
        {
            get; set;
        }

        public string url
        {
            get; set;
        }
    }
}