using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTracker.Data.Entities
{
    public class Bug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public long StatusId { get; set; }
        [ForeignKey("StatusId")] public Status Status { get; set; }
    }
}
