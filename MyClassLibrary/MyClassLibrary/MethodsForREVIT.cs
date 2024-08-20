using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyClassLibrary
{
    public class MethodsForREVIT
    {

        static UIApplication uiApp;
        static UIDocument uiDoc;
        static Document doc;



        public MethodsForREVIT(ExternalCommandData commandData)
        {
            uiApp = commandData.Application;
            uiDoc = uiApp.ActiveUIDocument;
            doc = uiDoc.Document;
        }

        public void GetNumberPipes()
        {

            List<Element> pipes = new FilteredElementCollector(doc)
               .OfCategory(BuiltInCategory.OST_PipeCurves)
               .WhereElementIsNotElementType()
               .Cast<Element>()
               .ToList();

            TaskDialog.Show("Количество труб=", $"{pipes.Count.ToString()}");

        }

        public void GetVolumeWalls()
        {
            List<Element> walls = new FilteredElementCollector(doc)
               .OfCategory(BuiltInCategory.OST_Walls)
               .WhereElementIsNotElementType()
               .Cast<Element>()
               .ToList();
            double sumVolume = 0;

            foreach (Element wall in walls)
            {
                Parameter volumeWalls = wall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
                double metreVolumeWalls = UnitUtils.ConvertFromInternalUnits(volumeWalls.AsDouble(), UnitTypeId.Meters);
                sumVolume = sumVolume + metreVolumeWalls;
            }
            TaskDialog.Show("Объем стен=", sumVolume.ToString());

        }

        public void GetNumberDoors()
        {
            List<Element> pipes = new FilteredElementCollector(doc)
            .OfCategory(BuiltInCategory.OST_Doors)
            .WhereElementIsNotElementType()
            .Cast<Element>()
            .ToList();

            TaskDialog.Show("Количество дверей=", $"{pipes.Count.ToString()}");

        }

    }
}
