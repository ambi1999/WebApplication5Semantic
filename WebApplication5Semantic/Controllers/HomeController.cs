using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using VDS.RDF.Query;
using System.Diagnostics;
using VDS.RDF.Parsing;

namespace WebApplication5Semantic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ambi 2222 Your application description page.";

            string str1 = "";

            Debug.WriteLine("************ inside about");

            //Remote SPARQL endpoints query
            //Source: https://github.com/dotnetrdf/dotnetrdf/wiki/UserGuide-Querying-With-SPARQL


            //Define a remote endpoint
            //Use the DBPedia SPARQL endpoint with the default Graph set to DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");

            //Make a SELECT query against the Endpoint
            //SparqlResultSet results = endpoint.QueryWithResultSet("select distinct ?Concept where {[] a ?Concept} LIMIT 100");

            SparqlResultSet results = endpoint.QueryWithResultSet("select ?i where{?a <http://dbpedia.org/ontology/thumbnail> ?i} LIMIT 10");

            

            foreach (SparqlResult result in results)
            {
                Debug.WriteLine("********** " + result.ToString());
                str1 = str1 + "<img src='" + result.Value("i")+ "'> <BR> <BR>";

            }
            ViewBag.Message = "ambi " + str1;
            //@Html.Raw(str1);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}