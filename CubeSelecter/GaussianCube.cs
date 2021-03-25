using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using InterfacesOfObjects.Interfaces;
using InterfacesOfObjects.DataInterfaces;
using PathLib;

namespace CubeSelecter
{
    public class GaussianCube : IProgramInterface
    {
        public string Path 
        { get ; set ; }
        public string InitCommand 
        { get ; set ; }

        public GaussianCube()
        {
            Path = "~/bin/";
            InitCommand = "wsl ~/bin/cubegen ";
        }

        public void GenerateCube(IMOCube mOCube, int orb1, int orb2 = 0)
        {
            var file = mOCube.AssotiatedFile;

            var localCommand = InitCommand;
            if (mOCube.Basis == BasisType.Nbo)
            {
                localCommand += " 1 MO=" + orb1 + " ";
                var splitedLine = mOCube.AssotiatedFile.Split("/");
                localCommand += splitedLine[splitedLine.Length - 1];
                localCommand += " " + " cube" + orb1 + ".cube";
                localCommand += " " + "-3 h";
                Process.Start(localCommand);

                localCommand = InitCommand;
                localCommand += " 1 MO=" + orb2 + " ";
                splitedLine = mOCube.AssotiatedFile.Split("/");
                localCommand += splitedLine[splitedLine.Length - 1];
                localCommand += " " + " cube" + orb2 + ".cube";
                localCommand += " " + "-3 h";
                Process.Start(localCommand);
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = "wsl ~/bin/cubeman";
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.RedirectStandardInput = true;

                    myProcess.Start();
                    StreamWriter streamWriter = myProcess.StandardInput;

                    streamWriter.WriteLine("A");
                    streamWriter.WriteLine("cube" + orb1 + ".cube");
                    System.Threading.Thread.Sleep(1000);
                    streamWriter.WriteLine("cube" + orb2 + ".cube");
                    System.Threading.Thread.Sleep(1000);
                    streamWriter.WriteLine("cube" + orb1 + "_" + orb2 + ".cube");
                    System.Threading.Thread.Sleep(1000);
                    streamWriter.WriteLine("y");
                    streamWriter.Close();
                    myProcess.WaitForExit();
                }
            }
        }
    }
}
