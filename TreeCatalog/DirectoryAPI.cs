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

        #region GetElementsByLevelIdOrName
        public Level GetElementOfFirstLevelById(int id, out bool errorOccured)
        {
            Level level = null;
            errorOccured = true;

            try
            {
                level = db.Levels.Single(e => e.Id == id);
                if (level != null)
                {
                    errorOccured = false;
                }
                
            }
            catch
            {
                errorOccured = true;
            }
            return level;
        }

        public Level GetElementOfFirstLevelByName(string name, out bool errorOccured)
        {
            Level level = null;
            errorOccured = true;

            try
            {
                level = db.Levels.Single(e => e.Name.ToLower().Contains(name.ToLower()));
                if (level != null)
                {
                    errorOccured = false;
                }   
            }
            catch
            {

                errorOccured = true;
            }
            return level;
        }

        public SubLevel GetElementOfSecondLevelById(int id, out bool errorOccured)
        {
            SubLevel subLevel = null;
            errorOccured = true;

            try
            {
                subLevel = db.SubLevels.Single(e => e.Id == id);
                if (subLevel != null)
                {
                    errorOccured = false;
                }

            }
            catch
            {
                errorOccured = true;
            }
            return subLevel;
        }

        public SubLevel GetElementOfSecondLevelByName(string name, out bool errorOccured)
        {
            SubLevel subLevel = null;
            errorOccured = true;

            try
            {
                subLevel = db.SubLevels.Single(e => e.Name.ToLower().Contains(name.ToLower()));
                if (subLevel != null)
                {
                    errorOccured = false;
                }
            }
            catch
            {

                errorOccured = true;
            }
            return subLevel;
        }

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
                var level = db.Levels.Single(e => e.Name.ToLower().Contains(name.ToLower()));

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
                var subLevel = db.SubLevels.Single(e => e.Name.ToLower().Contains(name.ToLower()));

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

        public void AddElementToFirstLevel(string value, out bool errorOccured)
        {
            errorOccured = true;
            try
            {
                db.Levels.Add(new Level { Name = value });
                db.SaveChanges();
                errorOccured = false;
            }
            catch
            {
                errorOccured = true;
            }
        }

        public void AddElementToSecondLevel(string value, int firstLevelId, bool allowToInsertElements, out bool errorOccured)
        {
            errorOccured = true;
            try
            {
                var level = db.Levels.Single(e => e.Id == firstLevelId);
                if (level != null)
                {
                    string type = allowToInsertElements ? node : leaf;
                    db.SubLevels.Add(new SubLevel { Name = value, LevelId = firstLevelId, Type = type });
                    db.SaveChanges();
                    errorOccured = false;
                }                
            }
            catch
            {
                errorOccured = true;
            }
        }

        public void AddElementToThirdLevel(string value, int secondLevelId, out bool errorOccured)
        {
            errorOccured = true;
            try
            {
                var subLevel = db.SubLevels.Single(e => e.Id == secondLevelId);
                if (subLevel != null && subLevel.Type.Equals(node))
                {
                    db.SubSubLevels.Add(new SubSubLevel { Name = value, SubLevelId = secondLevelId });
                    db.SaveChanges();
                    errorOccured = false;
                }                               
            }
            catch
            {
                errorOccured = true;
            }
        }

        #endregion

    }
}
