using InterfacesOfObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesOfObjects.DataInterfaces
{
    public interface ICoord: IChemData
    {
        public List<float> Data
        { get; set; }
    }
}
