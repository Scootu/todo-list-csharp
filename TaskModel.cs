using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_list
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        // how i can prevent default copy / assignment operator ?

        public int getId()
        {
            return Id;
        }
        // i will think how i can generate auto_increment ids
        public void SetId(int id)
        {
            Id = id;
        }
        public string GetTitle() 
        {
            return Title;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
        public string GetDescription()
        {
            return Description;
        }
        public void SetDescription(string des)
        {
            Description = des;
        }
        public bool IsTaskCompleted()
        {
            return IsCompleted;
        }
        public void SetIsCompleted(bool isCom)
        {
            IsCompleted = isCom;
        }
        public DateTime GetCreatedAt()
        {
            return CreatedAt;
        }
        public void SetCreatedAt()
        {
            CreatedAt = DateTime.Now;
        }
        public DateTime? GetCompletedAt()
        {
            return CompletedAt;
        }
        public void SetCompletedAt()
        {
            CompletedAt = DateTime.Now;
        }
        public override string ToString()
        {

            return $"{Id} | " +
                     $"{Title} | " +
                     $"{(IsCompleted ? "Completed" : "Pending")} | " +
                     $"{CreatedAt:yyyy/MM/dd}" +
                     (CompletedAt.HasValue ? $" {CompletedAt:yyyy/MM/dd}" : "");

        }
        public string GetAllTaskInformation()
        {
            return ToString() + $" |  Description : {Description}";
        }
        public void ReadTask(int id)
        {
            SetId(id);
            string str;
            Console.WriteLine("Enter task title : ");
            str = Console.ReadLine();
            SetTitle(str);
            Console.WriteLine("Enter task description:");
            str = Console.ReadLine();
            SetDescription(str);
            SetCreatedAt();
        }
        public void UpdateTaskData()
        {
            string str;
            Console.WriteLine("Enter Task title: ");
            str = Console.ReadLine();
            SetTitle(str);
            Console.WriteLine("Enter task description: ");
            str = Console.ReadLine();
            SetTitle(str);
            SetDescription(str);
        }


    }

}
