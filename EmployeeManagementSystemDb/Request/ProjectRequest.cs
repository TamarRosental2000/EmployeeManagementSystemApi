﻿using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemDb.Request;

public partial class ProjectRequest
{
    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

  }
