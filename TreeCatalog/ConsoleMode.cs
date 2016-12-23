using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeCatalog;

namespace TreeCatalog
{
    class ConsoleMode : Mode
    {
        private const string node = "node";

        #region ShowElements
        public override void ShowElementsOfFirstLevel()
        {
            bool errorOccured;
            var list = api.GetElementsOfFirstLevel(out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public override void ShowElementsOfSecondLevel()
        {
            bool errorOccured;
            var list = api.GetElementsOfSecondLevel(out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public override void ShowElementsOfThirdLevel()
        {
            bool errorOccured;
            var list = api.GetElementsOfThirdLevel(out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }
        #endregion

        #region ShowElementsByLevelIdOrName
        public override void ShowElementsByFirstLevelId(int id)
        {
            bool errorOccured;
            var list = api.GetElementsByFirstLevelId(id, out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public override void ShowElementsByFirstLevelName(string name)
        {
            bool errorOccured;
            var list = api.GetElementsByFirstLevelName(name, out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
            }
        }

        public override void ShowElementsBySecondLevelId(int id)
        {
            bool errorOccured;
            var list = api.GetElementsBySecondLevelId(id, out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public override void ShowElementsBySecondLevelName(string name)
        {
            bool errorOccured;
            var list = api.GetElementsBySecondLevelName(name, out errorOccured);
            if (!errorOccured && list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
        #endregion

        #region AddElementToLevel

        public override void AddElementToFirstLevel(string value, out bool errorOccured)
        {
            api.AddElementToFirstLevel(value, out errorOccured);
        }

        public override void AddElementToSecondLevel(string value, int firstLevelId, bool allowToInsertElements, out bool errorOccured)
        {
            api.AddElementToSecondLevel(value, firstLevelId, allowToInsertElements, out errorOccured);
        }

        public override void AddElementToThirdLevel(string value, int secondLevelId, out bool errorOccured)
        {
            api.AddElementToThirdLevel(value, secondLevelId, out errorOccured);
        }

        public void AddElement(out bool errorOccured)
        {
            errorOccured = true;
            try
            {
                Console.Write("Введите значение: ");
                string enteredValue = Console.ReadLine();
                Console.Write("Введите номер уровня(1,2,3): ");
                int level = ReadAndParseToInt();
                switch (level)
                {
                    case 1:
                        AddElementToFirstLevel(enteredValue, out errorOccured);
                        break;
                    case 2:
                        Console.Write("Введите id или имя родительской сущности: ");
                        int firstLevelId;
                        string keyOfFirstLevelElements = Console.ReadLine();
                        bool isDigit = int.TryParse(keyOfFirstLevelElements, out firstLevelId);
                        if (isDigit)
                        {
                            var elementsOfSecondLevel = api.GetElementsByFirstLevelId(firstLevelId, out errorOccured);
                            if (!errorOccured)
                            {
                                if (elementsOfSecondLevel.Count == 0)
                                {
                                    Console.Write("Позволить добавлять елементы к этой записи(да - 1/нет - 0): ");
                                    int resultOfParsing = ReadAndParseToInt();
                                    bool allowAddingOfElements = resultOfParsing == 1 ? true : false;
                                    AddElementToSecondLevel(enteredValue, firstLevelId, allowAddingOfElements, out errorOccured);
                                }
                                else
                                {
                                    var secondLevelElement = elementsOfSecondLevel.First();
                                    bool allowAddingOfElements = secondLevelElement.Type.Equals(node) ? true : false;
                                    AddElementToSecondLevel(enteredValue, firstLevelId, allowAddingOfElements, out errorOccured);
                                }
                            }
                        }
                        else
                        {
                            var firstLevelElement = api.GetElementOfFirstLevelByName(keyOfFirstLevelElements, out errorOccured);
                            if (!errorOccured)
                            {
                                var elementsOfSecondLevel = api.GetElementsByFirstLevelId(firstLevelElement.Id, out errorOccured);
                                if (!errorOccured)
                                {
                                    if (elementsOfSecondLevel.Count == 0)
                                    {
                                        Console.Write("Позволить добавлять елементы к этой записи(да - 1/нет - 0): ");
                                        int resultOfParsing = ReadAndParseToInt();
                                        bool allowAddingOfElements = resultOfParsing == 1 ? true : false;
                                        AddElementToSecondLevel(enteredValue, firstLevelElement.Id, allowAddingOfElements, out errorOccured);
                                    }
                                    else
                                    {
                                        var secondLevelElement = elementsOfSecondLevel.First();
                                        bool allowAddingOfElements = secondLevelElement.Type.Equals(node) ? true : false;
                                        AddElementToSecondLevel(enteredValue, firstLevelElement.Id, allowAddingOfElements, out errorOccured);
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        Console.Write("Введите id или имя родительской сущности: ");
                        int secondLevelId;
                        string keyOfSecondLevelElements = Console.ReadLine();
                        isDigit = int.TryParse(keyOfSecondLevelElements, out secondLevelId);
                        if (isDigit)
                        {
                            AddElementToThirdLevel(enteredValue, secondLevelId, out errorOccured);
                        }
                        else
                        {
                            var secondLevelElement = api.GetElementOfSecondLevelByName(keyOfSecondLevelElements, out errorOccured);
                            if (!errorOccured)
                            {
                                AddElementToThirdLevel(enteredValue, secondLevelElement.Id, out errorOccured);
                            }
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Неправильно введен номер уровня!");
                        errorOccured = true;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла ошбика {e.GetType()}. Текст ошибки: {e.Message} ");
                errorOccured = true;
            }
        }
        #endregion

        public void ControlPanel()
        {
            string choise = "";
            try
            {
                Console.WriteLine("Доброго времени суток.");
                ShowMenu();
                do
                {
                    
                    Console.Write("Введите номер комманды: ");
                    choise = Console.ReadLine();
                    Console.WriteLine();
                    switch (choise)
                    {
                        case "show all":
                            ShowElementsOfFirstLevel();
                            break;
                        case "show by name -first":
                            Console.Write("Введите имя елемента из первого уровня: ");
                            string firstLevelName = Console.ReadLine();
                            ShowElementsByFirstLevelName(firstLevelName);
                            break;
                        case "show by name -second":
                            Console.Write("Введите имя елемента из второго уровня: ");
                            string secondLevelName = Console.ReadLine();
                            ShowElementsBySecondLevelName(secondLevelName);
                            break;
                        case "Add":
                            AddElement(out errorOccured);
                            if (!errorOccured) Console.WriteLine("Добавлено.");
                            if (errorOccured) Console.WriteLine("При добавлении возникла ошибка");
                            break;
                        case "help":
                            ShowMenu();
                            break;
                        case "exit":
                            Console.WriteLine("Выход");
                            Environment.Exit(0);
                            break;

                        default: Console.WriteLine("Комманда с таким номером отсутствует."); break;
                    }
                } while (choise != "0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Меню:");
            Console.WriteLine("show all - Вывод всех ключей первого уровня");
            Console.WriteLine("show by name -first - Вывод значения, по имени первого уровня");
            Console.WriteLine("show by name -second - Вывод значения по имени второго уровня");
            Console.WriteLine("Add - Добавление записи, с выбором кол-ва и имени  уровней");
            Console.WriteLine("help - Помощь");
            Console.WriteLine("exit - Выход");
            Console.WriteLine();
        }

        private int ReadAndParseToInt()
        {
            int integerNumber;
            while (!(int.TryParse(Console.ReadLine(), out integerNumber)))
            {
                Console.Write("Неверный формат ввода, повторите попытку: ");
            }
            return integerNumber;
        }
    }



}

