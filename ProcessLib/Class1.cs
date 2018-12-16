using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;


namespace ProcessLib
{
    [Serializable]
    public struct DBaseSettings
    {
        public bool fileMode;
        public string dir;
        public string serverName;
        public string name;
        public string userName;
        public string userPass;
    }

    public static class Class1
    {
        public static string TestMethod3(string path)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            string PathV8Unpack = @"G:\_WorkD\Обработки\V8Unpack20\V8Unpack20\bin\V8Unpack.exe111111111";
            string EpfFilePath = @"G:\_WorkD\Обработки\CDev\ВнешняяОбработка1.epf";
            //string TxtFilePath = @"G:\_WorkD\Обработки\ВнешняяОбработка1.txt";
            string DirTxtFilePath = @"G:\_WorkD\Обработки\CDev";

            psi.Arguments = $"/K {PathV8Unpack} -PARSE {EpfFilePath} {DirTxtFilePath}";

            Process.Start(psi);

            return "fff";
        }

        public static string TestMethod4(DBaseSettings dBaseSettings,
            DBaseSettings dBaseProtecetdSettings,
            string enterprisePath,
            string cfFileDir,
            string keySeries,
            string epfSrcDir,
            string v8UnpackPath,
            string epfFileDir,
            string[] moduleNames,
            string licenceEditDir)
        {
            //Выгрузка файлов конфигурации
            DumpConfigFiles(enterprisePath, dBaseSettings, cfFileDir);

            //Определение имени файла загаловка из root
            string headerFileName = HeaderFileName(epfSrcDir);
            string epfSrcDir1 = $@"{epfSrcDir}1";

            foreach (var epfFileName in moduleNames)
            {
                //Копирование исходников для сборки обработки
                CopyDirectory(epfSrcDir, epfSrcDir1);

                //Изменение файлов обработки
                ChangeEpfFiles(epfSrcDir1, epfFileName, headerFileName, cfFileDir);

                //Cборка обработки
                string epfFilePath = $@"{epfFileDir}\{epfFileName}.epf";
                BuildEpf(v8UnpackPath, epfSrcDir1, epfFilePath);

                //Удаление копии каталога исходников для сборки обработки
                DeleteDirectiry(epfSrcDir1);
            }

            //Создание зашифрованного файла
            CreateEncryptedFile(licenceEditDir, keySeries, epfFileDir);

            //Копирование зашифрованного файла в папку с выгруженными файлами модулей
            CopyEncryptedFile(epfFileDir, keySeries, cfFileDir);

            //Загрузка зашифрованного файла в защищенную конфигурацию в макет
            LoadTemplateFiles(enterprisePath, dBaseProtecetdSettings, cfFileDir);

            foreach (var moduleName in moduleNames)
            {
                //Изменение файлов модулей
                ChangeModuleFile(cfFileDir, moduleName);
            }

            //Загрузка измененных модулей в защищенную конфигурацию
            LoadModuleFiles(enterprisePath, dBaseProtecetdSettings, cfFileDir);

            return "fff";
        }

        public static string DumpConfigFiles(string enterprisePath, DBaseSettings dBaseSettings, string cfFileDir)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = $"\"{enterprisePath}\"";

            if (dBaseSettings.userName != "")
            {
                dBaseSettings.userName = $" /N\"{dBaseSettings.userName}\"";
            }
            if (dBaseSettings.userPass != "")
            {
                dBaseSettings.userPass = $" /P\"{dBaseSettings.userPass}\"";
            }
            if (dBaseSettings.fileMode)
            {
                psi.Arguments = $"DESIGNER /F\"{dBaseSettings.dir}\"{dBaseSettings.userName}{dBaseSettings.userPass} /DumpConfigFiles \"{cfFileDir}\" -Module";
            }
            else
            {
                psi.Arguments = $"DESIGNER /S{dBaseSettings.serverName}\\{dBaseSettings.name}{dBaseSettings.userName}{dBaseSettings.userPass} /DumpConfigFiles \"{cfFileDir}\" -Module";
            }
            
            //  /c - после выполнения команды консоль закроется
            //  /к - не закрывать консоль после выполнения команды
            Process cmd = Process.Start(psi);
            cmd.EnableRaisingEvents = true;
            cmd.WaitForExit();

            return "fff";
        }

        public static string HeaderFileName(string epfSrcDir)
        {
            string rootFilePath = $@"{epfSrcDir}\root";
            string[] rootFile = File.ReadAllLines(rootFilePath);

            //В файле только одна строка
            if (rootFile.Length == 0)
            {
                return "";
            }

            Regex regex = new Regex(@",([\w-]*),");
            MatchCollection matches = regex.Matches(rootFile[0]);

            if (matches.Count == 0)
            {
                return "";
            }

            return matches[0].Groups[1].Value;
        }

        public static string CopyDirectory(string epfSrcDir, string epfSrcDir1)
        {
            //Создать идентичную структуру папок
            foreach (string dirPath in Directory.GetDirectories(epfSrcDir, "*",
                SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(epfSrcDir, epfSrcDir1));
                }
                catch (Exception e)
                {
                    //здесь обрабатывай ошибки
                }
            }

            //Копировать все файлы и перезаписать файлы с идентичным именем
            foreach (string newPath in Directory.GetFiles(epfSrcDir, "*.*",
                SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(newPath, newPath.Replace(epfSrcDir, epfSrcDir1), true);
                }
                catch (Exception e)
                {
                    //здесь обрабатывай ошибки
                }
            }

            return "fff";
        }

        public static string ChangeEpfFiles(string epfSrcDir1, string epfFileName, string headerFileName, string cfFileDir)
        {
            string headerFilePath = $@"{epfSrcDir1}\{headerFileName}";
            string headerFileText;

            string epfModuleDirName;
            string epfModuleFilePath;

            string cfModuleFilePath = $@"{cfFileDir}\ОбщийМодуль.{epfFileName}.Модуль.txt";
            string cfModuleFileText;

            //Читаем текст файла-заголовока
            using (StreamReader srHeaderFile = new StreamReader(headerFilePath, System.Text.Encoding.UTF8))
            {
                headerFileText = srHeaderFile.ReadToEnd();
            }

            //Определяем имя каталога, где лежит файл модуля обработки
            epfModuleDirName = EpfModuleDirName(headerFileText);

            //Записываем файл-заголовок с измененным именем
            using (StreamWriter swHeaderFile = new StreamWriter(headerFilePath, false, System.Text.Encoding.UTF8))
            {
                headerFileText = headerFileText.Replace("ВнешняяОбработка0", epfFileName);
                swHeaderFile.WriteLine(headerFileText);
            }

            //Читаем текст файла общего модуля конфигурации
            using (StreamReader srCfModuleFile = new StreamReader(cfModuleFilePath, System.Text.Encoding.UTF8))
            {
                cfModuleFileText = srCfModuleFile.ReadToEnd();
            }

            //Записываем текст файла общего модуля конфигурации в файл модуля обработки
            epfModuleFilePath = $@"{epfSrcDir1}\{epfModuleDirName}\text";
            using (StreamWriter swEpfModuleFile = new StreamWriter(epfModuleFilePath, true, System.Text.Encoding.UTF8))
            {
                swEpfModuleFile.WriteLine(cfModuleFileText);
            }

            return "fff";
        }

        public static string EpfModuleDirName(string headerFileText)
        {
            Regex regex = new Regex(@"([\w-]*)},""ВнешняяОбработка0""");
            MatchCollection matches = regex.Matches(headerFileText);

            if (matches.Count == 0)
            {
                return "fff";
            }

            return matches[0].Groups[1].Value + ".0";

        }

        public static string DeleteDirectiry(string epfSrcDir1)
        {
            try
            {
                Directory.Delete(epfSrcDir1, true);
            }
            catch (Exception ex)
            {
                return "fff";
            }

            return "fff";
        }

        public static string BuildEpf(string pathV8Unpack, string epfSrcDir1, string epfFilePath)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = pathV8Unpack;
            psi.Arguments = $"-build \"{epfSrcDir1}\" \"{epfFilePath}\"";
            Process cmd = Process.Start(psi);
            cmd.EnableRaisingEvents = true;
            cmd.WaitForExit();

            return "fff";
        }

        public static string CreateEncryptedFile(string licenceEditDir, string keySeries, string epfFileDir)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = $"\"{licenceEditDir}\\licenceedit.exe\"";
            psi.Arguments = $"c \"{epfFileDir}\\{keySeries}.datafile\" \"{epfFileDir}\\*.epf\" -y --serie={keySeries} --cryptkey=\"{licenceEditDir}\\{keySeries}.cryptkey\"";
            Process cmd = Process.Start(psi);
            cmd.EnableRaisingEvents = true;
            cmd.WaitForExit();

            return "fff";
        }

        public static string CopyEncryptedFile(string epfFileDir, string keySeries, string cfFileDir)
        {
            string pathEncryptedFile = $@"{epfFileDir}\{keySeries}.datafile";
            string newPathEncryptedFile = $@"{cfFileDir}\ОбщийМакет.ДанныеСЛК.Макет.bin";

            FileInfo fileInf = new FileInfo(pathEncryptedFile);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPathEncryptedFile, true);
            }

            return "fff";
        }

        public static string LoadTemplateFiles(string enterprisePath, DBaseSettings dBaseProtectedSettings, string cfFileDir)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = $"\"{enterprisePath}\"";

            if (dBaseProtectedSettings.userName != "")
            {
                dBaseProtectedSettings.userName = $" /N\"{dBaseProtectedSettings.userName}\"";
            }
            if (dBaseProtectedSettings.userPass != "")
            {
                dBaseProtectedSettings.userPass = $" /P\"{dBaseProtectedSettings.userPass}\"";
            }
            if (dBaseProtectedSettings.fileMode)
            {
                psi.Arguments = $"DESIGNER /F\"{dBaseProtectedSettings.dir}\"{dBaseProtectedSettings.userName}{dBaseProtectedSettings.userPass} /LoadConfigFiles \"{cfFileDir}\" -Template";
            }
            else
            {
                psi.Arguments = $"DESIGNER /S{dBaseProtectedSettings.serverName}\\{dBaseProtectedSettings.name}{dBaseProtectedSettings.userName}{dBaseProtectedSettings.userPass} /LoadConfigFiles \"{cfFileDir}\" -Template";
            }

            Process cmd = Process.Start(psi);
            cmd.EnableRaisingEvents = true;
            cmd.WaitForExit();

            return "fff";
        }

        public static string ChangeModuleFile(string cfFileDir, string moduleName)
        {
            string cfModuleFilePathNew = $@"{cfFileDir}\ОбщийМодуль.{moduleName}1.Модуль.txt";
            string cfModuleFilePath = $@"{cfFileDir}\ОбщийМодуль.{moduleName}.Модуль.txt";
            string cfModuleFileText;

            //Читаем текст файла общего модуля конфигурации
            using (StreamReader srCfModuleFile = new StreamReader(cfModuleFilePath, System.Text.Encoding.UTF8))
            {
                cfModuleFileText = srCfModuleFile.ReadToEnd();
            }

            int endIndex = cfModuleFileText.Length - 1;

            //Отбираем области экспортных процедур и функций 
            List<RegionContainer> Regionlines = new List<RegionContainer>();
            ParseRegions(cfModuleFileText, Regionlines, 0, endIndex);
            
            //Отбираем эксортные процедуры и функции
            List<PFContainer> PFlines = new List<PFContainer>();
            ParseCFModuleFileText(cfModuleFileText, PFlines, 0, endIndex);

            //Заисываем данные в новый модуль
            using (StreamWriter srCfModuleFileNew = new StreamWriter(cfModuleFilePath, false, System.Text.Encoding.UTF8))
            {
                //Здесь будем хранить список областей записанных в файл
                List<RegionContainer> writeRegionlines = new List<RegionContainer>();

                //Здесь будем хранить список закрытых областей записанных в файл
                List<RegionContainer> writeEndRegionlines = new List<RegionContainer>();

                foreach (PFContainer line in PFlines)
                {
                    string subStringParameters = "";
                    if (line.Parameters != null)
                    {
                        foreach (string parameter in line.Parameters)
                        {
                            subStringParameters = subStringParameters + ((subStringParameters == "") ? subStringParameters : ", ") + parameter;
                        }
                    }

                    //вставляем области
                    if (Regionlines.Count != 0)
                    {

                        //Найдем список областей до текущей процедуры/функции, их нужно закрыть
                        List<RegionContainer> findEndRegionlines = Regionlines.FindAll(x => x.EndIndex < line.Index);
                        foreach (RegionContainer findEndRegionline in findEndRegionlines)
                        {
                            //Поищем в списке записанных областей текущую найденную закрытую область
                            //Ее может не быть, потому что в ней могло не оказаться экспортных процедур/функций, тогда закрыать нечего
                            RegionContainer writeRegionline = writeRegionlines.Find(x => x.StartIndex == findEndRegionline.StartIndex && x.EndIndex == findEndRegionline.EndIndex);

                            if (writeRegionline != null)//Область, которую нужно закрыть, должна быть записана в файл
                            {
                                //Поищем в списке записанных закрытых областей текущую найденную закрытую область, может оказаться уже закрытой
                                RegionContainer writeEndRegionline = writeEndRegionlines.Find(x => x.StartIndex == findEndRegionline.StartIndex && x.EndIndex == findEndRegionline.EndIndex);
                                if (writeEndRegionline == null)
                                {
                                    srCfModuleFileNew.WriteLine();
                                    srCfModuleFileNew.WriteLine($"#КонецОбласти");
                                    writeEndRegionlines.Add(findEndRegionline);

                                }
                            }
                        }

                        //Найдем список областей для текущей процедуры/функции
                        List<RegionContainer> findRegionlines = Regionlines.FindAll(x => x.StartIndex < line.Index && x.EndIndex > line.Index);
                        foreach (RegionContainer findRegionline in findRegionlines)
                        {
                            //Поищем в списке записанных областей текущую найденную область
                            RegionContainer writeRegionline = writeRegionlines.Find(x => x.StartIndex == findRegionline.StartIndex && x.EndIndex == findRegionline.EndIndex);
                            if (writeRegionline == null)
                            {
                                srCfModuleFileNew.WriteLine();
                                srCfModuleFileNew.WriteLine($"#Область {findRegionline.Name}");
                                writeRegionlines.Add(findRegionline);

                            }
                        }

                    }

                    if (line.Type == TypePF.Function)
                    {
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine(line.Text);
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine($"\tОбъектСЛК = ОбщегоНазначенияУВССервер.СоздатьОбъектСЛК(\"{moduleName}\");");
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine($"\tЕсли Не ОбъектСЛК = Неопределено Тогда");
                        srCfModuleFileNew.WriteLine($"\t\tВозврат ОбъектСЛК.{line.Name}({subStringParameters});");
                        srCfModuleFileNew.WriteLine($"\tИначе");
                        srCfModuleFileNew.WriteLine($"\t\tВозврат Неопределено;");
                        srCfModuleFileNew.WriteLine($"\tКонецЕсли;");
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine($"КонецФункции");
                    }
                    else if (line.Type == TypePF.Procedure)
                    {
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine(line.Text);
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine($"\tОбъектСЛК = ОбщегоНазначенияУВССервер.СоздатьОбъектСЛК(\"{moduleName}\");");
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine($"\tЕсли Не ОбъектСЛК = Неопределено Тогда");
                        srCfModuleFileNew.WriteLine($"\t\tОбъектСЛК.{line.Name}({subStringParameters});");
                        srCfModuleFileNew.WriteLine($"\tКонецЕсли;");
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine($"КонецПроцедуры");
                    }
                   
                }

                if (Regionlines.Count != 0)
                {
                    int countWriteNotEndRegionlines = writeRegionlines.Count - writeEndRegionlines.Count;
                    while (countWriteNotEndRegionlines != 0)
                    {
                        srCfModuleFileNew.WriteLine();
                        srCfModuleFileNew.WriteLine($"#КонецОбласти");
                        countWriteNotEndRegionlines--;
                    }
                }

            }

            return "fff";
        }

        public static string ParseRegions(string cfModuleFileText, List<RegionContainer> linesNew, int startIndex, int endIndex)
        {
            string subStringRegion = "#Область";
            string subStringEndRegion = "#КонецОбласти";

            int lastListRegionIndex = -1;

            while (true)
            {
                int indexOfSubStringRegion = cfModuleFileText.IndexOf(subStringRegion, startIndex, StringComparison.CurrentCultureIgnoreCase);
                int indexOfSubStringEndRegion = cfModuleFileText.IndexOf(subStringEndRegion, startIndex, StringComparison.CurrentCultureIgnoreCase);

                int startIndexNameRegion;
                int endIndexNameRegion;
                string subStringSpace;

                if (indexOfSubStringRegion >= 0 && indexOfSubStringEndRegion >= 0)
                {
                    if (indexOfSubStringRegion < indexOfSubStringEndRegion)
                    {
                        //Получаем индекс первого символа имени области
                        startIndexNameRegion = indexOfSubStringRegion + 7;
                        do
                        {
                            startIndexNameRegion++;
                            subStringSpace = cfModuleFileText.Substring(startIndexNameRegion, 1);
                            subStringSpace = subStringSpace.Trim(new char[] { ' ', '\r', '\n', '\t' });

                        }
                        while (subStringSpace.Length == 0);

                        //Получаем индекс последнего символа имени области
                        endIndexNameRegion = startIndexNameRegion;
                        while (subStringSpace.Length != 0)
                        {
                            endIndexNameRegion++;
                            subStringSpace = cfModuleFileText.Substring(endIndexNameRegion, 1);
                            subStringSpace = subStringSpace.Trim(new char[] { ' ', '\r', '\n', '\t' });

                        }

                        RegionContainer lineNew = new RegionContainer();
                        lineNew.Name = cfModuleFileText.Substring(startIndexNameRegion, endIndexNameRegion - startIndexNameRegion);
                        lineNew.StartIndex = indexOfSubStringRegion;
                        linesNew.Add(lineNew);

                        lastListRegionIndex++;

                        startIndex = endIndexNameRegion + 1;
                    }
                    else
                    {
                        for (int listRegionIndex = lastListRegionIndex; listRegionIndex >= 0; listRegionIndex--)
                        {
                            RegionContainer lineNew = linesNew[listRegionIndex];
                            if (lineNew.EndIndex == 0)
                            {
                                lineNew.EndIndex = indexOfSubStringEndRegion;
                                startIndex = indexOfSubStringEndRegion + 13;
                                break;
                            }
                        }
                    }

                }
                else if (indexOfSubStringRegion >= 0)
                {
                    //Такого быть не может. 
                    //Начало области не может быть без конца области, потому что строку мы обрезаем слева.
                    break;
                }
                else if (indexOfSubStringEndRegion >= 0)
                {
                    for (int listRegionIndex = lastListRegionIndex; listRegionIndex >= 0; listRegionIndex--)
                    {
                        RegionContainer lineNew = linesNew[listRegionIndex];
                        if (lineNew.EndIndex == 0)
                        {
                            lineNew.EndIndex = indexOfSubStringEndRegion;
                            startIndex = indexOfSubStringEndRegion + 13;
                            break;
                        }
                    }
                }
                else//Либо ничего не нашли, либо дошли до конца - прерываем цикл
                {
                    break;
                }

            }

            return "fff";
        }

        public static string ParseCFModuleFileText(string cfModuleFileText, List<PFContainer> linesNew, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return "fff";
            }

            string subStringFunction = "Функция";
            string subStringProcedure = "Процедура";
            string subStringLeftBracket = "(";
            string subStringRightBracket = ")";
            string subStringExport = "Экспорт";

            PFContainer lineNew = new PFContainer();

            int indexOfSubStringFunctionOrProcedure = -1;

            int indexOfSubStringFunction = cfModuleFileText.IndexOf(subStringFunction, startIndex, StringComparison.CurrentCultureIgnoreCase);
            int indexOfSubStringProcedure = cfModuleFileText.IndexOf(subStringProcedure, startIndex, StringComparison.CurrentCultureIgnoreCase);

            if (indexOfSubStringFunction >= 0 && indexOfSubStringProcedure >= 0)
            {
                if (indexOfSubStringFunction < indexOfSubStringProcedure)
                {
                    indexOfSubStringFunctionOrProcedure = indexOfSubStringFunction;
                    lineNew.Type = TypePF.Function;
                    startIndex = indexOfSubStringFunction + 7;
                }
                else
                {
                    indexOfSubStringFunctionOrProcedure = indexOfSubStringProcedure;
                    lineNew.Type = TypePF.Procedure;
                    startIndex = indexOfSubStringProcedure + 9;
                }
            }
            else if (indexOfSubStringFunction >= 0)
            {
                indexOfSubStringFunctionOrProcedure = indexOfSubStringFunction;
                lineNew.Type = TypePF.Function;
                startIndex = indexOfSubStringFunction + 7;
            }
            else if (indexOfSubStringProcedure >= 0)
            {
                indexOfSubStringFunctionOrProcedure = indexOfSubStringProcedure;
                lineNew.Type = TypePF.Procedure;
                startIndex = indexOfSubStringProcedure + 9;
            }

            //Процедура/функция
            if (indexOfSubStringFunctionOrProcedure >= 0)
            {
                int indexOfSubStringLeftBracket = cfModuleFileText.IndexOf(subStringLeftBracket, startIndex, StringComparison.CurrentCultureIgnoreCase);

                //Левая скобка
                if (indexOfSubStringLeftBracket >= 0)
                {
                    string subStringName = cfModuleFileText.Substring(startIndex, indexOfSubStringLeftBracket - startIndex);
                    subStringName = subStringName.Trim(new char[] { ' ', '\r', '\n', '\t' });
                    if (subStringName.IndexOf(" ") < 0)//В имени процедуры/функции не должно быть пробелов
                    {
                        //Получаем наименование процедуры/функции
                        lineNew.Name = subStringName;
                        startIndex = indexOfSubStringLeftBracket + 1;

                        int indexOfSubStringRightBracket = cfModuleFileText.IndexOf(subStringRightBracket, startIndex, StringComparison.CurrentCultureIgnoreCase);

                        //Правая скобка
                        if (indexOfSubStringRightBracket >= 0)
                        {

                            //Получаем параметры
                            if (startIndex + 1 < indexOfSubStringRightBracket)
                            {
                                string subStringParameters = cfModuleFileText.Substring(startIndex, indexOfSubStringRightBracket - startIndex);
                                ParseParameters(subStringParameters, lineNew);
                            }

                            startIndex = indexOfSubStringRightBracket + 1;
                            int indexOfSubStringExport = cfModuleFileText.IndexOf(subStringExport, startIndex, StringComparison.CurrentCultureIgnoreCase);

                            //Экспорт
                            if (indexOfSubStringExport >= 0)
                            {
                                if (indexOfSubStringRightBracket + 1 == indexOfSubStringExport)//Между правой скобкой и экпсорт нет символов
                                {
                                    lineNew.Text = cfModuleFileText.Substring(indexOfSubStringFunctionOrProcedure, indexOfSubStringExport - indexOfSubStringFunctionOrProcedure + 7);
                                    lineNew.Index = indexOfSubStringFunctionOrProcedure;
                                    linesNew.Add(lineNew);
                                    startIndex = indexOfSubStringExport + 8;
                                }
                                else
                                {
                                    string subStringBetweenRightBracketAndExport = cfModuleFileText.Substring(indexOfSubStringRightBracket + 1, indexOfSubStringExport - 1 - indexOfSubStringRightBracket);
                                    string TrimString = subStringBetweenRightBracketAndExport.Trim(new char[] { ' ', '\r', '\n', '\t' });
                                    if (TrimString.Length == 0)
                                    {
                                        lineNew.Text = cfModuleFileText.Substring(indexOfSubStringFunctionOrProcedure, indexOfSubStringExport - indexOfSubStringFunctionOrProcedure + 7);
                                        lineNew.Index = indexOfSubStringFunctionOrProcedure;
                                        linesNew.Add(lineNew);
                                        startIndex = indexOfSubStringExport + 8;

                                    }
                                }

                            }
                        }
                    }

                    ParseCFModuleFileText(cfModuleFileText, linesNew, startIndex, endIndex);

                }

                else
                {
                    return "fff";
                }

            }

            return "fff";
        }

        public static string ParseParameters(string subStringParameters, PFContainer lineNew)
        {
            string[] separator = { "," };
            string[] linesParameters = subStringParameters.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (linesParameters.Length > 0)
            {
                lineNew.Parameters = new List<string>();
                foreach (string line in linesParameters)
                {
                    string parameterName = line.Replace("Знач ", "");
                    int indexOfSubStringEquel = parameterName.IndexOf("=");
                    if (indexOfSubStringEquel >= 0)
                    {
                        parameterName = parameterName.Substring(0, indexOfSubStringEquel);
                    }
                    parameterName = parameterName.Trim(new char[] { ' ', '\r', '\n', '\t' });
                    lineNew.Parameters.Add(parameterName);
                }
            }

            return "fff";
        }
        
        public static string LoadModuleFiles(string enterprisePath, DBaseSettings dBaseProtectedSettings, string cfFileDir)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = $"\"{enterprisePath}\"";

            if (dBaseProtectedSettings.userName != "")
            {
                dBaseProtectedSettings.userName = $" /N\"{dBaseProtectedSettings.userName}\"";
            }
            if (dBaseProtectedSettings.userPass != "")
            {
                dBaseProtectedSettings.userPass = $" /P\"{dBaseProtectedSettings.userPass}\"";
            }
            if (dBaseProtectedSettings.fileMode)
            {
                psi.Arguments = $"DESIGNER /F\"{dBaseProtectedSettings.dir}\"{dBaseProtectedSettings.userName}{dBaseProtectedSettings.userPass} /LoadConfigFiles \"{cfFileDir}\" -Module";
            }
            else
            {
                psi.Arguments = $"DESIGNER /S{dBaseProtectedSettings.serverName}\\{dBaseProtectedSettings.name}{dBaseProtectedSettings.userName}{dBaseProtectedSettings.userPass} /LoadConfigFiles \"{cfFileDir}\" -Module";
            }
            
            Process cmd = Process.Start(psi);
            cmd.EnableRaisingEvents = true;
            cmd.WaitForExit();

            return "fff";
        }
    }
}