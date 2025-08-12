using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace To_Do_list
{
    public class TaskManager
    {

       Dictionary<int, TaskModel> taskIdToTaskObj = new Dictionary<int, TaskModel>();
       public int last_id;

       public TaskManager()
        {
           taskIdToTaskObj = LoadDataBase();
            if (taskIdToTaskObj.Count > 0)
                last_id = taskIdToTaskObj.Keys.Max();

        }
       public void AddTask()
        {
            last_id++;
            var task = new TaskModel();
            task.ReadTask(last_id);
            taskIdToTaskObj[last_id] = task;
            Console.WriteLine($"Task id {last_id} Added!");
            SaveTasks();
        }
        public Dictionary<int,TaskModel> GetAllTasks()
        {
            return taskIdToTaskObj;
        }
        public void UpdateTask(int id)
        {
            if (!taskIdToTaskObj.ContainsKey(id))
            {
                Console.WriteLine("Task id don't exist!");
                return;
            }
            TaskModel task = taskIdToTaskObj[id];
            task.UpdateTaskData();
            taskIdToTaskObj[id] = task; // update tasks
            Console.WriteLine($"Task id {id} updated!");
            SaveTasks();
        }
        public void MarkTaskAsCompleted(int id)
        {
            if (!taskIdToTaskObj.ContainsKey(id))
            {
                Console.WriteLine("Task id don't exist!");
                return;
            }
            TaskModel task = taskIdToTaskObj[id];
            task.SetIsCompleted(true);
            task.SetCompletedAt();
            taskIdToTaskObj[id] = task;
            Console.WriteLine($"Task id {id} marked as complete!");
            SaveTasks();
        }
        public void DeleteTask(int id)
        {
            if (!taskIdToTaskObj.ContainsKey(id))
            {
                Console.WriteLine("Task id don't exist!");
                return;
            }
            taskIdToTaskObj.Remove(id); // removed
            Console.WriteLine($"Task id {id} removed succusfully!");
            SaveTasks();
        }
        public Dictionary<int, TaskModel> SearchTasks(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new Dictionary<int, TaskModel>(); // No keyword → empty result
            }

            keyword = keyword.ToLower();

            // Filter dictionary entries where Title or Description contains the keyword
            var results = taskIdToTaskObj
                .Where(pair =>
                    (!string.IsNullOrEmpty(pair.Value.GetTitle()) && pair.Value.GetTitle().ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(pair.Value.GetDescription()) && pair.Value.GetDescription().ToLower().Contains(keyword))
                )
                .ToDictionary(pair => pair.Key, pair => pair.Value); // Keep key-value structure

            return results;
        }

        public void SaveTasks()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(taskIdToTaskObj, options);
                File.WriteAllText("task.json", jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tasks: {ex.Message}");
            }
        }

        public  Dictionary<int, TaskModel> LoadDataBase()
        {
            try
            {
                if (!File.Exists("task.json"))
                    return new Dictionary<int, TaskModel>();

                string jsonString = File.ReadAllText("task.json");

                if (string.IsNullOrWhiteSpace(jsonString))
                    return new Dictionary<int, TaskModel>();

                var tasks = JsonSerializer.Deserialize<Dictionary<int, TaskModel>>(jsonString);
                return tasks ?? new Dictionary<int, TaskModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
                return new Dictionary<int, TaskModel>();
            }
        }

    }
}
