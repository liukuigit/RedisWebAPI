using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BQ_APILogic.Model
{
    public class FileEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDir { get; set; }

        public string FileURL { get; set; }
        public List<FileEntity> ListFile { get; set; }

    }
}
