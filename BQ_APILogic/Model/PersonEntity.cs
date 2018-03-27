using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Model
{
    public class PersonEntity
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Tel { get; set; }
        public string Dept { get; set; }
        public string Title { get; set; }

        public List<GroupEntity> groups { get; set; }

    }
}
