using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
//in this example use PdfPig classes to read pdf file
namespace readPdf
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> documentList = new List<string>();
            using (var pdf = PdfDocument.Open(@"..\..\sample.pdf"))
            {
                foreach (var page in pdf.GetPages())
                {
                    // Either extract based on order in the underlying document with newlines and spaces.
                    var text = ContentOrderTextExtractor.GetText(page);

                    // Or based on grouping letters into words.
                    var otherText = string.Join(" ", page.GetWords());

                    // Or the raw text of the page's content stream.
                    var rawText = page.Text;
                    documentList.Add(otherText);
                   
                }

            }

           Console.WriteLine(documentList.First());
        }
    }
}