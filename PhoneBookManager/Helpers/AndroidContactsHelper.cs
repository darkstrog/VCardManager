using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PhoneBookManager.Helpers
{
    public static class AndroidContactsHelper
    {
        /// <summary>
        /// Убирает переносы строк в для каждого тега используя временный файл, затем переписывает исходный
        /// В кодировке "QUOTED-PRINTABLE" Android в качестве обозначения переноса строки использует знак "=".
        /// Метод склеивает строки до тех пор пока на конце знак "=".
        /// Склеивая убирает лишний знак "=".
        /// если на конце строки в BASE64STRING окажется знак "=" данные будут повреждены
        /// поэтому метод подойдет только для склеивания строк "QUOTED-PRINTABLE"
        /// </summary>
        /// <param name="sourcePath"></param>
        public static void MergeStringQPRewrite(string sourcePath)
        {
            var tempPath = @"vcardtemp.vcf";
            using (StreamWriter ws = new StreamWriter(tempPath, false, System.Text.Encoding.UTF8))
            {
                ws.Write("");
            }
            using (StreamWriter ws = new StreamWriter(tempPath, true, System.Text.Encoding.UTF8))
            using (StreamReader fs = new StreamReader(sourcePath))
            {

                string line = "";
                string concatline = "";
                while (line != null)
                {

                    do
                    {
                        line = fs.ReadLine();
                        concatline += line?.TrimEnd('=');
                    }
                    while (!(String.IsNullOrEmpty(line)) && line.EndsWith('='));
                    if (!String.IsNullOrEmpty(concatline)) ws.WriteLine(concatline);
                    concatline = "";
                }

            }
            var Encode = new UTF8Encoding(false);
            using (StreamWriter wws = new StreamWriter(sourcePath, false, Encode))
            using (StreamReader ffs = new StreamReader(tempPath))
            {
                var tempfile = ffs.ReadToEnd();
                wws.Write(tempfile);
            }
        }

        public static string MergeStringQP(string sourcePath)
        {
            StringBuilder data = new StringBuilder();
            using (StreamReader fs = new StreamReader(sourcePath))
            {
                string line = "";
                string concatline = "";
                while (line != null)
                {
                    do
                    {
                        line = fs.ReadLine();
                        concatline += line?.TrimEnd('=');
                    }
                    while (!(String.IsNullOrEmpty(line)) && line.EndsWith('='));
                    if (!String.IsNullOrEmpty(concatline)) data.Append(concatline + "\n");
                    concatline = "";
                }

            }
            return data.ToString();
        }
        public static void NormalizeRewrite(string sourcePath)
        {
            var data = NormalizeTagTrigger(sourcePath);
            //для того что бы кодировка была UTF8 whithout BOM используем конструктор экземпляра кодировки.
            //конструктор по умолчанию не включает BOM так же как и перегрузка UTF8Encoding(false)
            var Encode = new UTF8Encoding();
            using (StreamWriter wws = new StreamWriter(sourcePath, false, Encode))
            {
                wws.Write(data);
                wws.Close();
            }
        }
        /// <summary>
        /// Склеивает строки начинающиеся не с тэга к последнему найденому тэгу
        /// Убирает знаки переноса "=" в "QUOTED-PRINTABLE" строках их добавляет андроид
        /// Удирает знаки табуляции и пробелы в начале строки
        /// </summary>
        /// <param name="sourcePath">Путь к файлу</param>
        /// <returns>Нормализованный файл string</returns>
        public static string NormalizeTagTrigger(string sourcePath)
        {
            var taglistpath = @"default.taglist";
            StringBuilder data = new StringBuilder();
            var tagcollection= new string[] { "VERSION","N","FN","BDAY","ADR","LABEL","REV","TEL","EMAIL","MAILER","TITLE","ROLE","TZ","LOGO","PHOTO",
                                              "NOTE","URL","UID","ORG","GEO","X-","item*","NICKNAME","CATEGORIES","SORT-STRING","SOUND","KEY","CLASS",
                                              "SOURCE","KIND","ANNIVERSARY","GENDER","IMPP","LANG","RELATED","CALURI","CALADRURI","BEGIN","END"};

            var tagList = File.Exists(taglistpath) ? File.ReadAllLines(taglistpath).Union(tagcollection) : tagcollection;
            
            using (StreamReader fs = new StreamReader(sourcePath))
            {
                string line = "";
                bool x;
                bool qp = false;
                data.Append(fs.ReadLine().TrimEnd('\n'));
                while ((line = fs.ReadLine()) != null)
                {
                    line = line.TrimStart(' ', '\t');
                    x = false;

                    foreach (var tag in tagList)
                    {
                        if (line != null && line.StartsWith(tag))
                        {
                            qp = line.Contains("QUOTED-PRINTABLE");
                            if (qp)
                            {
                                line = line.TrimEnd('=');
                            }
                            else { qp = false; }
                            data.Append("\n" + line.TrimEnd('\n').TrimStart(' '));
                            x = true;
                        }
                    }
                    if (line != null && !x)
                    {
                        if (qp) line = line.TrimEnd('=');
                        data.Append(line.TrimEnd('\n').TrimStart(' '));
                    }
                }
                fs.Close();
            }

            return data.ToString();
        }
    }
}
