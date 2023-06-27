﻿namespace WebAppPlanner.Models
{
    public class MyTask
    {
            public MyTask()
            {
                PriorityTasks = new List<PriorityTask>();
            }
            public int Id { get; set; }
            public string Title { get; set; }
            public string? Description { get; set; }
            public int CategoryId { get; set; }
            public virtual Category Category { get; set; }
            public virtual ICollection<PriorityTask> PriorityTasks { get; set; }
        }
    }
