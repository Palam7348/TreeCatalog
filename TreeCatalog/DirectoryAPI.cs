using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeCatalog.Models;


namespace TreeCatalog
{
    class DirectoryAPI
    {
        private LevelContext db;
        private const string node = "node";
        private const string leaf = "leaf";

        public DirectoryAPI()
        {
            db = new LevelContext();
        }

        #region Get elements of different levels
        public List<Level> GetElementsOfFirstLevel(out bool errocOccured)
        {
            List<Level> listToReturn = new List<Level>();
            errocOccured = true;
            try
            {
                listToReturn = (from item in db.Levels
                                select item).ToList();
                errocOccured = false;

            }
            catch
            {
                errocOccured = true;
            }
            return listToReturn;
        }

        public List<SubLevel> GetElementsOfSecondLevel(out bool errocOccured)
        {
            List<SubLevel> listToReturn = new List<SubLevel>();
            errocOccured = true;
            try
            {
                listToReturn = (from item in db.SubLevels
                                select item).ToList();
                errocOccured = false;

            }
            catch
            {
                errocOccured = true;
            }
            return listToReturn;
        }
        public List<SubSubLevel> GetElementsOfThirdLevel(out bool errocOccured)
        {
            List<SubSubLevel> listToReturn = new List<SubSubLevel>();
            errocOccured = true;
            try
            {
                listToReturn = (from item in db.SubSubLevels
                                select item).ToList();
                errocOccured = false;

            }
            catch
            {
                errocOccured = true;
            }
            return listToReturn;
        }
        #endregion

        #region GetElementsByLevelId

        public List<SubLevel> GetElementsByFirstLevelId(int id, out bool errorOccured)
        {
            List<SubLevel> list = new List<SubLevel>();
            errorOccured = true;

            try
            {
                list = db.SubLevels.Where(e => e.LevelId == id).ToList();
                errorOccured = false;
            }
            catch
            {
                errorOccured = true;
            }
            return list;
        }

        public List<SubLevel> GetElementsByFirstLevelName(string name, out bool errorOccured)
        {
            List<SubLevel> list = new List<SubLevel>();
            errorOccured = true;

            try
            {
                var level = db.Levels.Single(e => e.Name.Contains(name));

                list = db.SubLevels.Where(e => e.LevelId == level.Id).ToList();
                errorOccured = false;
            }
            catch
            {

                errorOccured = true;
            }
            return list;
        }

        public List<SubSubLevel> GetElementsBySecondLevelId(int id, out bool errorOccured)
        {
            List<SubSubLevel> list = new List<SubSubLevel>();
            errorOccured = true;
            try
            {
                var subLevel = db.SubLevels.Single(e => e.Id == id);

                if (subLevel != null && subLevel.Type.Equals("node"))
                {
                    list = db.SubSubLevels.Where(e => e.SubLevelId == subLevel.Id).ToList();
                    errorOccured = false;
                }
            }
            catch
            {
                errorOccured = true;
            }
            return list;
        }
        public List<SubSubLevel> GetElementsBySecondLevelName(string name, out bool errorOccured)
        {
            List<SubSubLevel> list = new List<SubSubLevel>();
            errorOccured = true;
            try
            {
                var subLevel = db.SubLevels.Single(e => e.Name.Contains(name));

                if (subLevel != null && subLevel.Type.Equals("node"))
                {
                    list = db.SubSubLevels.Where(e => e.SubLevelId == subLevel.Id).ToList();
                    errorOccured = false;
                }
            }
            catch
            {
                errorOccured = true;
            }
            return list;
        }


        #endregion

        #region AddElements

        //public bool AddElement(int firstLevelId, )
        //{

        //}

        #endregion

    }
}
