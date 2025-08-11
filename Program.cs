using System;

using static To_Do_list.UserInterface;
namespace To_Do_list
{
    class TaskTodoListApp
    {

        TaskManager taskManager = new TaskManager();

        public void LoadDatabase()
        {
            taskManager.LoadDataBase();
        }
        void Display()
        {
            string[] menu = { "Add Task", "View All Task", "Edit Task", "Mark Task as Completed", "Delete Task", "Search tasks" };
            while (true)
            {
                int choice = ShowReadMenu(menu, "==== TO-DO LIST ====");
                if (choice == 1)
                {
                    AddTask();

                }
                else if (choice == 2)
                {
                    ViewAllTask();

                }
                else if (choice == 3)
                {
                    EditTask();

                }
                else if (choice == 4)
                {
                    MarkTaskAsComplete();

                }
                else if (choice == 5)
                {
                    DeleteTask();

                }
                else if (choice == 6)
                {
                    SearchTask();

                }
                else
                {
                    break;
                }
            }
        }

        void AddTask()
        {
            taskManager.AddTask();
        }
        void ViewAllTask()
        {
            Console.WriteLine("ID | Title       | Status    | Created At");
            Console.WriteLine("------------------------------------------");
            var tasks = taskManager.GetAllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
        void EditTask()
        {
            Console.WriteLine("Enter task id: ");
            string sid = Console.ReadLine();
            int id = int.Parse(sid);
            taskManager.UpdateTask(id);
        }
        void MarkTaskAsComplete()
        {
            Console.WriteLine("Enter task id: ");
            string sid = Console.ReadLine();
            int id = int.Parse(sid);
            taskManager.MarkTaskAsCompleted(id);
        }
        void DeleteTask()
        {
            Console.WriteLine("Enter task id: ");
            string sid = Console.ReadLine();
            int id = int.Parse(sid);
            taskManager.DeleteTask(id);
        }
        void SearchTask()
        {
            Console.WriteLine("Enter keyword: ");
            string keyword = Console.ReadLine();
            Dictionary<int, TaskModel> tasks = taskManager.SearchTasks(keyword);
            if (Convert.ToBoolean(tasks.Count))
            {
                Console.WriteLine("Search Results: ");
                foreach (var task in tasks)
                {
                    Console.WriteLine(task.ToString());
                }
            }
            else
            {
                Console.WriteLine("There is no element found");
            }
        }
        public void Run()
        {
            LoadDatabase();
            Display();

        }
    }
    class program
    {
        public static void Main()
        {
            TaskTodoListApp taskSystem = new TaskTodoListApp();
            taskSystem.Run();
        }
    }
}