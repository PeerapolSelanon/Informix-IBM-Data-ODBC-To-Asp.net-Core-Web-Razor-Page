using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;
using System.Data.Odbc;

namespace RazorPagesMovie.Pages.ERP
{
    public class SearchModel : PageModel
    {
        public List<SearchResult>? Results { get; set; }

        public void OnGet(string searchTerm, string searchItem)
        {
            if ((!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrEmpty(searchItem)))
            {
                string connectionString = "DSN=ds2;UID=is0028;PWD=2801";
                string query = $"SELECT pmn24, pmm04, pmn04, pmn041, pmn66 FROM pmn_file,pmm_file WHERE pmn01 = pmm01 AND pmn24 = '{searchTerm}' AND pmn04 = '{searchItem}' ORDER BY 2";

                Results = FetchDataFromDatabase(connectionString, query);
            }
            else if (!string.IsNullOrEmpty(searchTerm))
            {
                string connectionString = "DSN=ds2;UID=is0028;PWD=2801";
                string query = $"SELECT pmn24, pmm04, pmn04, pmn041, pmn66 FROM pmn_file,pmm_file WHERE pmn01 = pmm01 AND pmn24 = '{searchTerm}' ORDER BY 2";

                Results = FetchDataFromDatabase(connectionString, query);
            }
            else if (!string.IsNullOrEmpty(searchItem))
            {
                string connectionString = "DSN=ds2;UID=is0028;PWD=2801";
                string query = $"SELECT pmn24, pmm04, pmn04, pmn041, pmn66 FROM pmn_file,pmm_file WHERE pmn01 = pmm01 AND pmn04 = '{searchItem}' ORDER BY 2";

                Results = FetchDataFromDatabase(connectionString, query);
            }
        }
        private List<SearchResult> FetchDataFromDatabase(string connectionString, string query)
        {
            List<SearchResult> results = new List<SearchResult>();

            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        connection.Open();
                        using (OdbcDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new SearchResult
                                {
                                    Column1 = reader["pmn24"].ToString(),
                                    Column2 = reader["pmm04"].ToString(),
                                    Column3 = reader["pmn04"].ToString(),
                                    Column4 = reader["pmn041"].ToString(),
                                    Column5 = reader["pmn66"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
            }

            return results;
        }
    }

    public class SearchResult
    {
        public string? Column1 { get; set; }
        public string? Column2 { get; set; }
        public string? Column3 { get; set; }
        public string? Column4 { get; set; }
        public string? Column5 { get; set; }
        public string? Column6 { get; set; }
        // Add more properties if needed
    }
}
