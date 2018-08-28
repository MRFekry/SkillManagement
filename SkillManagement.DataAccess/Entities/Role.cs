using SkillManagement.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Entities
{
    public class Role : AuditBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
