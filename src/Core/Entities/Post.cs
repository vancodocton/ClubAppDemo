using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Core.Entities
{
    public class Post : EntityBase<int>
    {
        public string Title { get; set; }

        public Post(string title)
        {
            Title = title;
        }
    }
}
