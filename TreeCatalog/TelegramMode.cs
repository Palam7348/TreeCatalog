using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCatalog
{
    class TelegramMode : Mode
    {
        public override void AddElementToFirstLevel(string value, out bool errorOccured)
        {
            throw new NotImplementedException();
        }

        public override void AddElementToSecondLevel(string value, int firstLevelId, bool allowToInsertElements, out bool errorOccured)
        {
            throw new NotImplementedException();
        }

        public override void AddElementToThirdLevel(string value, int secondLevelId, out bool errorOccured)
        {
            throw new NotImplementedException();
        }

        public override void ShowElementsByFirstLevelId(int id)
        {
            throw new NotImplementedException();
        }

        public override void ShowElementsByFirstLevelName(string name)
        {
            throw new NotImplementedException();
        }

        public override void ShowElementsBySecondLevelId(int id)
        {
            throw new NotImplementedException();
        }

        public override void ShowElementsBySecondLevelName(string name)
        {
            throw new NotImplementedException();
        }

        public override void ShowElementsOfFirstLevel()
        {
            throw new NotImplementedException();
        }

        public override void ShowElementsOfSecondLevel()
        {
            throw new NotImplementedException();
        }

        public override void ShowElementsOfThirdLevel()
        {
            throw new NotImplementedException();
        }
    }
}
