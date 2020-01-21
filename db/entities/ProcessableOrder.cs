using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace db.entities
{
    public class ProcessableOrder
    {
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage="OrderId max length exceeded.")]
        public string OrderId { get; set; }
    }
}