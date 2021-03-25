using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesOfObjects.Interfaces
{
    public interface IChemForm
    {
        public string Name
        { get; set; }

        public ExtremusType Type
        { get; }

        public string AssotiatedDir
        { get; set; }

        public List<IChemData> Datas
        { get; }

        public DateTime DateCreation
        { get; }
    }

    public enum ExtremusType
    {
        ES = 0,
        TS = 1
    }
}
