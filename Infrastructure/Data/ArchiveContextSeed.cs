
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class ArchiveContextSeed
    {
        public static async Task SeedAsync(ArchiveContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Boxes.Any())
                {
                    var boxesdata = System.IO.File.ReadAllText("../Infrastructure/Data/SeedData/Boxes.json");


                    var boxes = JsonSerializer.Deserialize<List<Box>>(boxesdata);

                    foreach (var item in boxes)
                    {
                        context.Boxes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Policies.Any())
                {
                    var policiesdata = System.IO.File.ReadAllText("../Infrastructure/Data/SeedData/Policies.json");


                    var policies = JsonSerializer.Deserialize<List<Policy>>(policiesdata);

                    foreach (var item in policies)
                    {
                        context.Policies.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ArchiveContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}