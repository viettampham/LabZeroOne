﻿using System;
using System.Collections.Generic;

namespace LabZeroOne.Data;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? AvatarId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int? RoleId { get; set; }
}
