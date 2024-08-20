using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using MyClassLibrary;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingButtons
{
    internal class MainViewViewModel

    {
        private ExternalCommandData _commandData;
        public DelegateCommand NumberPipesCommand { get; }
        public DelegateCommand VolumeWallsCommand { get; }
        public DelegateCommand NumberDoorsCommand { get; }
        MethodsForREVIT methodREVIT;



        public MainViewViewModel(ExternalCommandData commandData)
        {
            _commandData = commandData;
            NumberPipesCommand = new DelegateCommand(OnNumberPipesCommand);
            VolumeWallsCommand = new DelegateCommand(OnVolumeWallsCommand);
            NumberDoorsCommand = new DelegateCommand(OnNumberDoorsCommand);
           methodREVIT = new MethodsForREVIT(_commandData);
        }

        private void OnNumberPipesCommand()
        {
             methodREVIT.GetNumberPipes();
        }
        private void OnVolumeWallsCommand()
        {
            methodREVIT.GetVolumeWalls();
        }
        private void OnNumberDoorsCommand()
        {
            methodREVIT.GetNumberDoors();
        }


    }
}
