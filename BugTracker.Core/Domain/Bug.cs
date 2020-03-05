using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BugTracker.Common.Enums;

namespace BugTracker.Core.Domain
{
    public class Bug
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public long StatusId { get; set; }
    }
}
