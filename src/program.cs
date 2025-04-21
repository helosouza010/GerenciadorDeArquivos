using System;
using System.IO;
using GerenciadorDeArquivos;

FileManager fileManager = new FileManager();
string? input;

do
{
    Console.Clear();
    Console.WriteLine("==== GERENCIADOR DE ARQUIVOS ====");
    Console.WriteLine("1 - Criar arquivo");
    Console.WriteLine("2 - Ler arquivo");
    Console.WriteLine("3 - Escrever em arquivo");
    Console.WriteLine("4 - Renomear arquivo");
    Console.WriteLine("5 - Copiar arquivo");
    Console.WriteLine("6 - Excluir arquivo");
    Console.WriteLine("7 - Mostrar informações do arquivo");
    Console.WriteLine("8 - Listar arquivos do diretório");
    Console.WriteLine("9 - Modificar atributos");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    
    input = Console.ReadLine(); // Não redeclare

    Console.Clear();

    if (!string.IsNullOrEmpty(input)) // Verificação para garantir que input não é nulo ou vazio
    {
        switch (input)
        {
            case "1":
                Console.Write("Nome do arquivo: ");
                string? createName = Console.ReadLine();
                if (!string.IsNullOrEmpty(createName))
                {
                    fileManager.CreateFile(createName!);
                    Console.WriteLine("Arquivo criado.");
                }
                break;

            case "2":
                Console.Write("Nome do arquivo: ");
                string? readName = Console.ReadLine();
                if (!string.IsNullOrEmpty(readName))
                {
                    string content = fileManager.ReadFromFile(readName!);
                    Console.WriteLine("Conteúdo:");
                    Console.WriteLine(content);
                }
                break;

            case "3":
                Console.Write("Nome do arquivo: ");
                string? writeName = Console.ReadLine();
                Console.Write("Conteúdo: ");
                string? text = Console.ReadLine();
                if (!string.IsNullOrEmpty(writeName) && text != null)
                {
                    File.WriteAllText(writeName!, text);
                    Console.WriteLine("Escrito com sucesso.");
                }
                break;

            case "4":
                Console.Write("Arquivo atual: ");
                string? oldName = Console.ReadLine();
                Console.Write("Novo nome: ");
                string? newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(oldName) && !string.IsNullOrEmpty(newName))
                {
                    fileManager.RenameFile(oldName!, newName!);
                    Console.WriteLine("Arquivo renomeado.");
                }
                break;

            case "5":
                Console.Write("Arquivo origem: ");
                string? source = Console.ReadLine();
                Console.Write("Arquivo destino: ");
                string? dest = Console.ReadLine();
                if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(dest))
                {
                    fileManager.CopyFile(source!, dest!);
                    Console.WriteLine("Arquivo copiado.");
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                }
                break;

            case "6":
                Console.Write("Nome do arquivo: ");
                string? deleteName = Console.ReadLine();
                if (!string.IsNullOrEmpty(deleteName))
                {
                    fileManager.DeleteFile(deleteName!);
                    Console.WriteLine("Arquivo deletado.");
                }
                break;

            case "7":
                Console.Write("Nome do arquivo: ");
                string? infoName = Console.ReadLine();
                if (!string.IsNullOrEmpty(infoName))
                {
                    fileManager.DisplayFileInfo(infoName!);
                }
                break;

            case "8":
                Console.Write("Caminho do diretório: ");
                string? dir = Console.ReadLine();
                if (!string.IsNullOrEmpty(dir))
                {
                    fileManager.ListFiles(dir!);
                }
                break;

            case "9":
                Console.Write("Nome do arquivo: ");
                string? attrFile = Console.ReadLine();
                Console.WriteLine("Escolha atributo (1=Oculto, 2=SomenteLeitura, 3=Normal): ");
                string? attrInput = Console.ReadLine();
                FileAttributes attr = FileAttributes.Normal;

                switch (attrInput)
                {
                    case "1": attr = FileAttributes.Hidden; break;
                    case "2": attr = FileAttributes.ReadOnly; break;
                    case "3": attr = FileAttributes.Normal; break;
                }

                if (!string.IsNullOrEmpty(attrFile))
                {
                    fileManager.ModifyAttributes(attrFile, attr);
                    Console.WriteLine("Atributo alterado.");
                }
                break;

            case "0":
                Console.WriteLine("Saindo...");
                break;

            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Entrada inválida.");
    }

    if (input != "0")
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (input != "0");
