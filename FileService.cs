using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeitorArquivo
{
    public static class FileService
    {
        /// <summary>
        /// Read lines from file 
        /// </summary>
        /// <param name="meuArquivo"></param>
        private static void ReadFiles(string meuArquivo)
        {
            using (StreamReader arquivo = File.OpenText(meuArquivo))
            {
                string linha;
                while ((linha = arquivo.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }
        }

        /// <summary>
        /// Get all repository names
        /// </summary>
        /// <param name="meuArquivo"></param>
        /// <returns></returns>
        public static List<string> GetAllNamesFiles(string meuArquivo)
        {
            var result = System.IO.Directory.EnumerateFiles(meuArquivo,
                      "*.*",
                      System.IO.SearchOption.AllDirectories)
                .Select(c =>
                       c.Split(new string[] { "\\" }, StringSplitOptions.None).Last())
                .ToArray();
            int fileCounter = result.Length;
            List<string> nameFiles = new List<string>();
            while (fileCounter > -1)
            {
                fileCounter--;
                if (fileCounter != -1)
                {
                    nameFiles.Add(result[fileCounter]);
                }

            }
            foreach (var files in nameFiles)
            {
                Console.WriteLine("\n Lista: " + files.Replace(".txt", "") + "\n");
                ReadFiles("C:\\Users\\User\\OneDrive\\Área de Trabalho\\Arquivo\\" + files + "");
            }

            return nameFiles;
        }
    }
}
