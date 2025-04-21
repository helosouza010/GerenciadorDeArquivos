using System.IO;
using System;

namespace GerenciadorDeArquivos
{
    public class FileManager
    {


        public void CreateFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                // arquivo criado
            }
        }


        public void OpenFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                // arquivo aberto
            }
        }

        public void CloseFile(string fileName)
        {
            // Closing a file is handled automatically by the using statement
            // No explicit close needed
        }

        public void RenameFile(string oldFileName, string newFileName)
        {
            if (File.Exists(oldFileName))
            {
                File.Move(oldFileName, newFileName);
            }
        }

        public void CopyFile(string sourceFileName, string destFileName)
        {
            if (File.Exists(sourceFileName))
            {
                File.Copy(sourceFileName, destFileName, true);
            }
        }


        public void DisplayFileInfo(string fileName)
        {
            if (File.Exists(fileName))
            {
                FileInfo fileInfo = new FileInfo(fileName);
                Console.WriteLine($"File Name: {fileInfo.Name}");
                Console.WriteLine($"File Size: {fileInfo.Length} bytes");
                Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
                Console.WriteLine($"Last Modified Time: {fileInfo.LastWriteTime}");
            }
            else
            {
                Console.WriteLine("Arquivo nao existe.");
            }
        }

        public void ListFile (string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Diretorio nao existe.");
            }
        }

        public void ModifyAtributes(string fileName, FileAttributes attributes)
        {
            if (File.Exists(fileName))
            {
                File.SetAttributes(fileName, attributes);
            }
        }


        public string ReadFromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }



        public void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        internal void ListFiles(string dir)
        {
            throw new NotImplementedException();
        }


        internal void ModifyAttributes(string attrFile, FileAttributes attr)
        {
            throw new NotImplementedException();
        }

        internal void WriteToFile(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}