using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public interface InterfaceDals
    {
        public void AddRow();
        public object GetById();
        public void Update();
        public void Delete();
    }
}
