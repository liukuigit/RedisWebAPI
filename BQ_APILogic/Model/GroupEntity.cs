using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Model
{
    public class GroupEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<PersonEntity> ListPerson { get; set; }
    }
}
