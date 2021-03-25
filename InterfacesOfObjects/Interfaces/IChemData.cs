using System.ComponentModel;

namespace InterfacesOfObjects.Interfaces
{
    public interface IChemData: INotifyPropertyChanged
    {
        public IChemForm Parent
        { get; set; }

        public string AssotiatedFile
        { get; set; }

        public QChemData QChem
        { get; }

        public void GetFromFile();

    }

    public enum QChemData
    {
        Energy = 0,
        Coords = 1,
        MOOrbitalCubes = 2,
    }

}