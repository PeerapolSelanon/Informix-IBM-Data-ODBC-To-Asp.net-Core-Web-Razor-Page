using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.Odbc;

namespace RazorPagesMovie.Pages.ERP
{
    public class MemoModel : PageModel
    {
        public List<MemoData>? MemoList { get; set; }

        public void OnGet(string id)
        {
            MemoList = new List<MemoData>();

            if (!string.IsNullOrEmpty(id))
            {
                string connectionString = "DSN=ds2;UID=is0028;PWD=2801";
                string query = $"SELECT pmp03, pmp04, pmp05 FROM pmn_file, pmp_file WHERE pmn24 = '{id}' AND pmn01 = pmp01";

                FetchDataFromDatabase(connectionString, query);
            }
        }

        private void FetchDataFromDatabase(string connectionString, string query)
        {
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
                                MemoList.Add(new MemoData
                                {
                                    Pmp03 = reader["pmp03"].ToString(),
                                    Pmp04 = reader["pmp04"].ToString(),
                                    Pmp05 = reader["pmp05"].ToString()
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
        }
    }

    public class MemoData
    {
        public string? Pmp03 { get; set; }
        public string? Pmp04 { get; set; }
        public string? Pmp05 { get; set; }
    }
}
