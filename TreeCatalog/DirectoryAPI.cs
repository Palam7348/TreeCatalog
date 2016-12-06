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
                var levels = db.Levels.Where(e => e.Name.Contains(name)).ToList();

                list = db.SubLevels.Where(e => e.LevelId == levels.Last().Id).ToList();
                errorOccured = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                var subLevels = db.SubLevels.Where(e => e.Id == id).ToList();

                if (subLevels[0] != null && subLevels[0].Type.Equals("node"))
                {
                    list = db.SubSubLevels.Where(e => e.SubLevelId == subLevels[0].Id).ToList();
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
                var subLevels = db.SubLevels.Where(e => e.Name.Contains(name)).ToList();
                if (subLevels[0] != null && subLevels[0].Type.Equals("node"))
                {
                    list = db.SubSubLevels.Where(e => e.SubLevelId == subLevels[0].Id).ToList();
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
