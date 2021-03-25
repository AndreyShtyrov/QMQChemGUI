using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesOfObjects.Interfaces
{
    public interface IChemCompound
    {
        public DateTime DateCreation
        { get; }

        public string AssotiatedDir
        { get; set; }

        public string Name
        { get; }

        public List<IChemForm> Forms
        { get; }

    }
}
