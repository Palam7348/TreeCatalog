using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCatalog
{
    class ConsoleMode
    {
        DirectoryAPI api = new DirectoryAPI();

        #region ShowElements
        public void ShowElementsOfFirstLevel()
        {
            bool errorOccured;
            var list = api.GetElementsOfFirstLevel(out errorOccured);
            if (!errorOccured)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public void ShowElementsOfSecondLevel()
        {
            bool errorOccured;
            var list = api.GetElementsOfSecondLevel(out errorOccured);
            if (!errorOccured)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public void ShowElementsOfThirdLevel()
        {
            bool errorOccured;
            var list = api.GetElementsOfThirdLevel(out errorOccured);
            if (!errorOccured)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }
        #endregion

        public void ShowElementsByFirstLevelId(int id)
        {
            bool errorOccured;
            var list = api.GetElementsByFirstLevelId(id, out errorOccured);
            if (!errorOccured)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public void ShowElementsByFirstLevelName(string name)
        {
            bool errorOccured;
            var list = api.GetElementsByFirstLevelName(name, out errorOccured);
            if (!errorOccured)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public void ShowElementsBySecondLevelId(int id)
        {
            bool errorOccured;
            var list = api.GetElementsBySecondLevelId(id, out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public void ShowElementsBySecondLevelName(string name)
        {
            bool errorOccured;
            var list = api.GetElementsBySecondLevelName(name, out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

    }
}
