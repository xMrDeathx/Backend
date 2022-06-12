﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace ScrumBoard
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }

        public Task(string title, string description, Priority priority)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
        }
    }
}
