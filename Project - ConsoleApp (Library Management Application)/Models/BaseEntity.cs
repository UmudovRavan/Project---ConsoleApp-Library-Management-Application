﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
}
