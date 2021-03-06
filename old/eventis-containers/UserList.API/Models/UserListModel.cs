﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserList.API.Models
{
    public class UserListModel
    {   
        public Guid UserId { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public string FacebookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImageURL { get; set; }
    }
}
