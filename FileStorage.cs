using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace To_Do_list
{
    public class FileStorage
    {
        private static readonly string filePath = "tasks.json";

        // Save the list of tasks to a JSON file
        public static void SaveTasks(Dictionary<int, TaskModel> tasks)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true // Makes JSON human-readable
                };

                string jsonString = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tasks: {ex.Message}");
            }
        }

    }
}
