using InterfacesOfObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesOfObjects.DataInterfaces
{
    public interface IMOCube: IChemData
    {
        public Dictionary<(int orb1, int orb2), string> Data
        { get; set; }

        public BasisType Basis
        { get; }
    }

    public enum BasisType 
    {
        MO = 0, 
        Nbo = 1,
    }

}
