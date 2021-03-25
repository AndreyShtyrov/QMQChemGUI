using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesOfObjects.Interfaces;
using InterfacesOfObjects.DataInterfaces;
using PathLib;
using System.IO;
using System.ComponentModel;

namespace CubeSelecter
{
    public class MOCube: IMOCube
    { 
        
        public MOCube(IChemForm parent)
        {
            Parent = parent;
            var iterDirs = new WindowsPath(parent.AssotiatedDir);
            foreach (var file in iterDirs.ListDir())
            {
                if (file.Extension.Contains("out"))
                {
                    Basis = BasisType.MO;
                    using (var sr = new StreamReader(file.FileInfo.FullName))
                    {
                        
                        for (int i = 0; i < 30; i++)
                        {
                            var line = sr.ReadLine();
                            if (line.ToLower().Contains("savenbo"))
                            {
                                Basis = BasisType.Nbo;
                                break;
                            }

                        }
                        
                    }
                }
            }
            foreach (var file in iterDirs.ListDir())
            {
                if (file.Extension.Contains("chk"))
                {
                    AssotiatedFile = file.Basename;
                    break;
                }
            }
            Data = new Dictionary<(int, int), string>();
        }

        public BasisType Basis 
        { get ; set ; }

        public Dictionary<(int, int), string> Data
        { get; set ; }

        public QChemData QChem => QChemData.MOOrbitalCubes;
      
        public string AssotiatedFile 
        { get ; set; }

        public IChemForm Parent
        { get; set; }

        public string AdditionalFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GetFromFile()
        {
            throw new NotImplementedException();
        }
    }
}
