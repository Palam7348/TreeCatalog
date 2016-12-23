using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCatalog
{
    abstract class Mode 
    {
        protected DirectoryAPI api = new DirectoryAPI();
        protected bool errorOccured;

        public abstract void ShowElementsOfFirstLevel();
        public abstract void ShowElementsOfSecondLevel();
        public abstract void ShowElementsOfThirdLevel();
        public abstract void ShowElementsByFirstLevelId(int id);
        public abstract void ShowElementsByFirstLevelName(string name);
        public abstract void ShowElementsBySecondLevelId(int id);
        public abstract void ShowElementsBySecondLevelName(string name);
        public abstract void AddElementToFirstLevel(string value, out bool errorOccured);
        public abstract void AddElementToSecondLevel(string value, int firstLevelId, bool allowToInsertElements, out bool errorOccured);
        public abstract void AddElementToThirdLevel(string value, int secondLevelId, out bool errorOccured);
    }
}
