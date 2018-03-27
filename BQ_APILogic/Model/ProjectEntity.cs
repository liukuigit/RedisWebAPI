using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Model
{
    public class ProjectEntity
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string DeptName { get; set; }
        public bool OnlyDX { get; set; }
        public string Jllb { get; set; }
        public string Jz { get; set; }
        public string Jldj { get; set; }
        public string Cglb { get; set; }
        public string Cgdjh { get; set; }
        public List<FileEntity> ListFile { get; set; }

    }
}
