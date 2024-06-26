﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeRun_App.Entities
{
    [Table("Goals")]
    public class Goal
    {
        public uint GoalId { get; set; }
        public string? GoalType { get; set; }
        public double? GoalValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAchieved { get; set; }

        // relationship
        public User User { get; set; }
        public uint UserId { get; set; }

    }
}