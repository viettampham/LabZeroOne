using System;
using System.Collections.Generic;

namespace LabZeroOne.Data;

public partial class Notion
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Contents { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Status { get; set; }

    public int? OwnerId { get; set; }

    public int? GroupId { get; set; }

    public DateTime? TimeDone { get; set; }

    public string? ZoneFinish { get; set; }

    public bool? Important { get; set; }

    public bool? IsDelete { get; set; }

    public int? AvatarId { get; set; }

    public int? CommandId { get; set; }

    public int? AssignId { get; set; }

    public string? MemberShip { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatorId { get; set; }

    public string? IconTypeNote { get; set; }
}
