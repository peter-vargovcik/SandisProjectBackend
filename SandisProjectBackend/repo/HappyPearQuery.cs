using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SandisProjectBackend.repo
{
    public class HappyPearQuery
    {
        public AppDb Db { get; }

        public HappyPearQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<List<DateTime>> WeeksListAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT DISTINCT product_sale_record.date FROM product_sale_record ORDER BY product_sale_record.date DESC;";
            return await getWeeksList(await cmd.ExecuteReaderAsync());
        }



        private async Task<List<DateTime>> getWeeksList(DbDataReader reader)
        {
            var dates = new List<DateTime>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    dates.Add(DateTime.Parse(reader.GetString(0)));
                }
            }
            return dates;
        }

    }
}
